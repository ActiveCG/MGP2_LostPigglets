using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterStats : MonoBehaviour {

    public static MonsterStats instance;

    Transform spawnList;

    [HideInInspector]
    public List<Transform> spawnPlaces = new List<Transform>();

    public int pooledAmount;
	public int damageAmount = 100;

    void Awake()
    {
        instance = this;
        spawnList = GameObject.FindGameObjectWithTag("SpawnList").transform;
        for(int i=0; i<spawnList.childCount; i++)
        {
            spawnPlaces.Add(spawnList.GetChild(i));
        }
    }

}
