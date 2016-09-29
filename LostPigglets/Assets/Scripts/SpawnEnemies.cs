using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {

    public static SpawnEnemies current;

    int spawnPoint;

    //These are for testing purposes and they are going to be deleted
    float time = 2f;
    float repeatRate = 0.5f;
    ///////

    public GameObject enemy;

    [HideInInspector]
    public GameObject poolParent;

    List<GameObject> enemies;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        poolParent = new GameObject(); //spawn an empty gameobject at 0,0,0
        poolParent.name = "EnemyPool";
        enemies = new List<GameObject>();
        spawnPoint = Random.Range(0, MonsterStats.instance.spawnPlaces.Count);
        for(int i=0; i<MonsterStats.instance.pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy, MonsterStats.instance.spawnPlaces[spawnPoint].position, MonsterStats.instance.spawnPlaces[spawnPoint].rotation);
            obj.transform.SetParent(poolParent.transform);
            obj.SetActive(false);
            enemies.Add(obj);
			obj.GetComponent<MoveEnemies> ().isSwimming = false;
			GameManager.instance.monsterMove (obj); //monster starts swimming
        }

        InvokeRepeating("Spawn", time, repeatRate);
    }

    void Spawn()
    {
        spawnPoint = Random.Range(0, MonsterStats.instance.spawnPlaces.Count);
        for (int i=0; i<enemies.Count; i++)
        {
            if(!enemies[i].activeInHierarchy)
            {
                enemies[i].transform.position = MonsterStats.instance.spawnPlaces[spawnPoint].position;
                enemies[i].transform.rotation = MonsterStats.instance.spawnPlaces[spawnPoint].rotation;
                enemies[i].SetActive(true);
                enemies[i].transform.SetParent(null);
                break;

            }
        }
    }
}
