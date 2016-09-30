using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class OinkPool : MonoBehaviour {

    public static OinkPool current;

    int poolSize;

    public GameObject oinkImg;

    public bool isCreated = false;

    [HideInInspector]
    public List<GameObject> oinks;
    [HideInInspector]
    public GameObject oinkPoolParent;


    void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }

	// Create the pool for the oinks
	public void CreatePool (List<GameObject> pigletList) {

        poolSize = pigletList.Count;
        oinkPoolParent = new GameObject();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject img = Instantiate(oinkImg);
            img.name = i.ToString();
            img.GetComponent<OinkScript>().pigletPos = pigletList[i];
            img.transform.SetParent(GameObject.FindGameObjectWithTag("GUI").transform, false);
            img.SetActive(false);
            oinks.Add(img);
        }
    }

    //Spawn the oinks
    public void SpawnOink(int id, GameObject pigletPos)
    {
        for(int i = 0; i < oinks.Count; i++)
        {
            if (!oinks[i].activeInHierarchy)
            {
                oinks[i].SetActive(true);
                oinks[i].GetComponent<OinkScript>().id = id;
                oinks[i].GetComponent<OinkScript>().pigletPos = pigletPos;
                break;
            }
        }
    }
}
