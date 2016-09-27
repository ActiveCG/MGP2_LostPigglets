using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterStats : MonoBehaviour {

    public static MonsterStats current;

    Transform spawnList;

    [HideInInspector]
    public List<Transform> spawnPlaces = new List<Transform>();

    public int pooledAmount;

    void Awake()
    {
        current = this;
        spawnList = GameObject.FindGameObjectWithTag("SpawnList").transform;
        for(int i=0; i<spawnList.childCount; i++)
        {
            spawnPlaces.Add(spawnList.GetChild(i));
        }
    }

}
