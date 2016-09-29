using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PigletManager : MonoBehaviour {

    //public delegate void FireOink();
    //public static event FireOink fireOink;

    public static PigletManager current;

    public GameObject player;

    public float minDelay;
    public float maxDelay;

    float delay;
    float counter;
    public List<GameObject> pigletList = new List<GameObject>(); //List for the piglets
    GameObject[] tempArray;
    public List<bool> pigletActiveOink = new List<bool>(); //List to check if the piglet has fired an Oink

    void Awake() {
        if (current == null) {
            current = this;
        }

    }
    // Use this for initialization
    void Start () {

        
        tempArray = GameObject.FindGameObjectsWithTag("Pigglet");


        for(int i = 0; i < tempArray.Length; i++)
        {
            Debug.Log(i);
            pigletList.Add(tempArray[i]);
            pigletActiveOink.Add(false);
        }

        OinkPool.current.CreatePool(pigletList);
        OinkPool.current.isCreated = true;
        counter = 0f;

	}
	
	// Update is called once per frame
	void Update () {

        SpawnOink();
        counter += Time.deltaTime;

	}

    void SpawnOink()
    {
        delay = Random.Range(minDelay, maxDelay); //Delays the oink
        for (int i = 0; i < pigletList.Count; i++)
        {     
            if (pigletActiveOink[i] == false && counter > delay)
            {  
                pigletActiveOink[i] = true;
                OinkPool.current.SpawnOink(i, pigletList[i].transform.position);
                counter = 0f;            
            }
        }
    }
}
