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

	// Use this for initialization
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

    public void SpawnOink(int id, Vector3 pigletPos)
    {
        for(int i = 0; i < oinks.Count; i++)
        {
            if (!oinks[i].activeInHierarchy)
            {
                oinks[i].SetActive(true);
                oinks[i].GetComponent<OinkScript>().id = id;
                break;
            }
        }
    }
}
