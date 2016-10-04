using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PigletManager : MonoBehaviour {

    //public delegate void FireOink();
    //public static event FireOink fireOink;

    public static PigletManager current;

    GameObject player;

    public float minDelay;
    public float maxDelay;

    float delay;
    public float counter;
    //[HideInInspector]
    public List<GameObject> pigletList = new List<GameObject>(); //List for the piglets
    GameObject[] tempArray;
    [HideInInspector]
    public List<bool> pigletActiveOink = new List<bool>(); //List to check if the piglet has fired an Oink
    [HideInInspector]
    public List<bool> pigletPickedUp = new List<bool>();
    [HideInInspector]
    public List<float> delayList = new List<float>();
    [HideInInspector]
    public List<bool> canSpawn = new List<bool>();

    bool preventReset = false;

    void Awake() {
        if (current == null) {
            current = this;
        }

    }
    // Use this for initialization
    void Start () {

        
        tempArray = GameObject.FindGameObjectsWithTag("Pigglet");

        player = GameManager.instance.player;

        for (int i = 0; i < tempArray.Length; i++)
        {
            delay = Random.Range(minDelay, maxDelay); //Delays the oink
            pigletList.Add(tempArray[i]);
            pigletActiveOink.Add(false);
            pigletPickedUp.Add(tempArray[i].GetComponent<PigletScript>().amIPickedUp);
            tempArray[i].GetComponent<PigletScript>().id = i;
            delayList.Add(delay);
            canSpawn.Add(true);

        }

        OinkPool.current.CreatePool(pigletList);
        OinkPool.current.isCreated = true;
        counter = 0f;

	}
	
	// Update is called once per frame
	void Update () {

        DistanceCanSpawn();
        SpawnOink();
        counter += Time.deltaTime;

        //Reset the counter and create new delay if both oinks have been fired.
       /* if((pigletActiveOink.All(c => c == true) && preventReset == false) ||
            (pigletActiveOink.Any(c => c == true) && preventReset == false && pigletPickedUp.Any(c => c == true))) {
            counter = 0f;
            CreateNewDelay();
        }

        //Reset the prevent reset boolean, so we can reset again. Wtf ?
        if (pigletActiveOink.All(c => c == false) && pigletPickedUp.All(c => c == false) ||
            pigletActiveOink.All(c => c == false) && pigletPickedUp.Any(c => c == true)) {
            preventReset = false;
        }*/

    }

    //Function to Spawn the oinks
    void SpawnOink()
    {
        for (int i = 0; i < pigletList.Count; i++)
        {         
            if (pigletActiveOink[i] == false
                && counter > delayList[i]
                && pigletPickedUp[i] == false
                && canSpawn[i] == true)
            {  
                pigletActiveOink[i] = true;
                OinkPool.current.SpawnOink(i, pigletList[i]);
                GameManager.instance.oink(pigletList[i]); 
            }
        }      
    }

    //Find a new delay for the oinks
    void CreateNewDelay() {     
            for (int i = 0; i < delayList.Count; i++) {
            delay = Random.Range(minDelay, maxDelay); //Delays the oink
            delayList[i] = delay;
        }
        preventReset = true;
    }

    // Prevent pickedup piglets from making oinks
    public void SetMeFalse (int id) {
        pigletPickedUp[id] = true;
    }

    void DistanceCanSpawn() {
        float dist1 = Vector3.Distance(player.transform.position, pigletList[0].transform.position);
        float dist2 = Vector3.Distance(player.transform.position, pigletList[1].transform.position); ;


        if (dist1 < dist2 && pigletPickedUp[0] == false) {
            canSpawn[0] = true;
            canSpawn[1] = false;
        }
        if(dist2 < dist1 && pigletPickedUp[1] == false) {
            canSpawn[1] = true;
        }

        if (pigletPickedUp[0] == true) {
            canSpawn[1] = true;
        }
    }
}
