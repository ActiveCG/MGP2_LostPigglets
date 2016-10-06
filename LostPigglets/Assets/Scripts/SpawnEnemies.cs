using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour {

    public static SpawnEnemies current;



    [HideInInspector]
    public List<GameObject> enemies;
    [HideInInspector]
    public int spawnPoint;
    [HideInInspector]
    public GameObject poolParent;

    public GameObject monsterMesh;



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
        for(int i=0; i<MonsterStats.instance.poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(MonsterStats.instance.enemy, MonsterStats.instance.spawnPlaces[spawnPoint].position, MonsterStats.instance.spawnPlaces[spawnPoint].rotation);
            //obj.GetComponent<EnemyRubberBanding>().enabled = false;
            obj.transform.SetParent(poolParent.transform);
			MonsterStun.current.particleStunned = GameObject.FindGameObjectWithTag ("StunParticle");
			MonsterStun.current.particleStunned.SetActive (false);
            MoveEnemies.instance.particles = GameObject.FindGameObjectWithTag("Bubbles");
            monsterMesh = GameObject.FindGameObjectWithTag("MonsterMesh");
            //MoveEnemies.instance.particles.SetActive(false);
            obj.SetActive(false);
            enemies.Add(obj);
			obj.GetComponent<MoveEnemies> ().isSwimming = false;
			GameManager.instance.monsterMove (obj); //monster starts swimming
        }

        //InvokeRepeating("Spawn", MonsterStats.instance.Time1stSpawnMonster, MonsterStats.instance.repeatTimeSpawn);
    }


    //void Spawn()
    //{
    //    spawnPoint = Random.Range(0, MonsterStats.instance.spawnPlaces.Count);
    //    for (int i = 0; i < enemies.Count; i++)
    //    {
    //        if (!enemies[i].activeInHierarchy)
    //        {
    //            enemies[i].transform.position = MonsterStats.instance.spawnPlaces[spawnPoint].position;
    //            enemies[i].transform.rotation = MonsterStats.instance.spawnPlaces[spawnPoint].rotation;
    //            enemies[i].SetActive(true);
    //            enemies[i].transform.SetParent(null);
    //            break;

    //        }
    //    }
    //}

}
