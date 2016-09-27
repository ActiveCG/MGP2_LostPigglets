using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {

    int spawnPoint;

    //These are for testing purposes and they are going to be deleted
    float time = 2f;
    float repeatRate = 0.5f;
    ///////

    public GameObject enemy;

    List<GameObject> enemies;

    void Start()
    {
        enemies = new List<GameObject>();
        spawnPoint = Random.Range(0, MonsterStats.current.spawnPlaces.Count);
        for(int i=0; i<MonsterStats.current.pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy, MonsterStats.current.spawnPlaces[spawnPoint].position, MonsterStats.current.spawnPlaces[spawnPoint].rotation);
            obj.SetActive(false);
            enemies.Add(obj);
        }

        InvokeRepeating("Spawn", time, repeatRate);
    }

    void Spawn()
    {
        spawnPoint = Random.Range(0, MonsterStats.current.spawnPlaces.Count);
        for (int i=0; i<enemies.Count; i++)
        {
            if(!enemies[i].activeInHierarchy)
            {
                enemies[i].transform.position = MonsterStats.current.spawnPlaces[spawnPoint].position;
                enemies[i].transform.rotation = MonsterStats.current.spawnPlaces[spawnPoint].rotation;
                enemies[i].SetActive(true);
                break;

            }
        }
    }
}
