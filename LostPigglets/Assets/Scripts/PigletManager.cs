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
    float counter;
    public List<GameObject> pigletList = new List<GameObject>(); //List for the piglets
    GameObject[] tempArray;
    public List<bool> pigletActiveOink = new List<bool>(); //List to check if the piglet has fired an Oink
    public List<bool> pigletPickedUp = new List<bool>();
    public List<float> delayList = new List<float>();
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

        }

        OinkPool.current.CreatePool(pigletList);
        OinkPool.current.isCreated = true;
        counter = 0f;

	}
	
	// Update is called once per frame
	void Update () {

        SpawnOink();
        counter += Time.deltaTime;

        if((pigletActiveOink.All(c => c == true) && preventReset == false) ||
            (pigletActiveOink.Any(c => c == true) && preventReset == false && pigletPickedUp.Any(c => c == true))) {
            counter = 0f;
            CreateNewDelay();
        }

        if (pigletActiveOink.All(c => c == false) && pigletPickedUp.All(c => c == false) ||
            pigletActiveOink.All(c => c == false) && pigletPickedUp.Any(c => c == true)) {
            preventReset = false;
        }

    }

    void SpawnOink()
    {
        for (int i = 0; i < pigletList.Count; i++)
        {         
            if (pigletActiveOink[i] == false
                && counter > delayList[i]
                && pigletPickedUp[i] == false)
            {  
                pigletActiveOink[i] = true;
                OinkPool.current.SpawnOink(i, pigletList[i].transform.position);
                GameManager.instance.oink(pigletList[i]);
            }
        }      
    }

    void CreateNewDelay() {     
            for (int i = 0; i < delayList.Count; i++) {
            delay = Random.Range(minDelay, maxDelay); //Delays the oink
            delayList[i] = delay;
        }
        preventReset = true;
    }

    public void SetMeFalse (int id) {
        pigletPickedUp[id] = true;
    }
}
