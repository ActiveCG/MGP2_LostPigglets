using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterStats : MonoBehaviour {

    public static MonsterStats instance;

    [HideInInspector]
    public List<Transform> spawnPlaces = new List<Transform>();
    public float Time1stSpawnMonster = 2f;
    public float repeatTimeSpawn = 0.5f;
    public float BlindingTimer = 1f;
    public float cooldownTimer = 8f;
    public float monsterStunTime = 2f;
    public float destroyTimeAfterHit = 0;
    public int poolAmount;
    public GameObject enemy;
    private Transform spawnList;


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
