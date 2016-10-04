﻿using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

    public static Intro instance;

	public enum InvisibleColliders {MonsterIntro,  PigletIntro, MonsterFighting, StartGame};
    [HideInInspector]
    public InvisibleColliders identity;
    [HideInInspector]
    public bool stopPlayerMove = false;
    [HideInInspector]
    public bool letPlayerCharge = false;
    [HideInInspector]
    public bool stopPlayerRotate = false;

    private GameObject introEnemy;
    private bool monsterIntroTriggered = false;
    private bool pigletIntroTriggered = false;
    private bool monsterFightTriggered = false;
    private bool startGameTriggered = false;

    [HideInInspector]
    public float initialSpeed, initialAcc, initialBlindTime, initialStunTime, initialIntensity;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        initialSpeed = PlayerStats.instance.playerSpeed;
        initialAcc = PlayerStats.instance.acceleration;
        initialBlindTime = MonsterStats.instance.BlindingTimer;
        initialStunTime = MonsterStats.instance.monsterStunTime;
    }


    void OnTriggerExit(Collider col)
    {
        //print("Impact");
        if(col.tag == "MonsterIntro")
        {
            initialIntensity = PlayerStats.instance.spotlight.intensity;
            //print("Into MonsterIntro");

            //GameManager.instance.MonsterJump(introEnemy);
            if (!monsterIntroTriggered)
            {
                //print("spawn");
                for (int i = 0; i < SpawnEnemies.current.enemies.Count; i++)
                {
                    if (!SpawnEnemies.current.enemies[i].activeInHierarchy)
                    {
                        //SpawnEnemies.current.enemies[i].GetComponent<NavMeshAgent>().Stop();
                        SpawnEnemies.current.enemies[i].transform.position = GameObject.FindGameObjectWithTag("MonsterIntroPos").transform.position;
                        SpawnEnemies.current.enemies[i].transform.rotation = GameObject.FindGameObjectWithTag("MonsterIntroPos").transform.rotation;
                        SpawnEnemies.current.enemies[i].SetActive(true);
                        SpawnEnemies.current.enemies[i].transform.SetParent(null);
                        introEnemy = SpawnEnemies.current.enemies[i];
                        break;
                    }
                }
                StartCoroutine(DisableMonster(introEnemy));
            }
            monsterIntroTriggered = true;

        }
        else if(col.tag == "PigletIntro")
        {
            //print("Into PigletIntro");
            
        }
        else if (col.tag == "MonsterFight")
        {
            //print("Into MonsterFight");
            if (!monsterFightTriggered)
            {
                //print("spawn");
                for (int i = 0; i < SpawnEnemies.current.enemies.Count; i++)
                {
                    if (!SpawnEnemies.current.enemies[i].activeInHierarchy)
                    {
                        SpawnEnemies.current.enemies[i].transform.position = GameObject.FindGameObjectWithTag("MonsterFightPos").transform.position;
                        SpawnEnemies.current.enemies[i].transform.rotation = GameObject.FindGameObjectWithTag("MonsterFightPos").transform.rotation;
                        SpawnEnemies.current.enemies[i].SetActive(true);
                        SpawnEnemies.current.enemies[i].transform.SetParent(null);
                        introEnemy = SpawnEnemies.current.enemies[i];
                        break;
                    }
                }
                //StartCoroutine(DisableMonster(introEnemy));
                stopPlayerMove = true;
                PlayerStats.instance.playerSpeed = 0f;
                PlayerStats.instance.acceleration = 0f;
                MonsterStats.instance.BlindingTimer = 100f;
                MonsterStats.instance.monsterStunTime = 100f;
                //Debug.Log(stopPlayerMove);
            }
            monsterFightTriggered = true;
        }
        else if (col.tag == "StartGame")
        {
            //print("Into StartGame");
            //stopPlayerMove = false;
            if (!startGameTriggered)
            {
                MonsterStats.instance.BlindingTimer = initialBlindTime;
                MonsterStats.instance.monsterStunTime = initialStunTime;
                InvokeRepeating("Spawn", MonsterStats.instance.Time1stSpawnMonster, MonsterStats.instance.repeatTimeSpawn);
            }
            startGameTriggered = true;
        }
    }


    void Spawn()
    {
        SpawnEnemies.current.spawnPoint = Random.Range(0, MonsterStats.instance.spawnPlaces.Count);
        for (int i = 0; i < SpawnEnemies.current.enemies.Count; i++)
        {
            if (!SpawnEnemies.current.enemies[i].activeInHierarchy)
            {
                SpawnEnemies.current.enemies[i].transform.position = MonsterStats.instance.spawnPlaces[SpawnEnemies.current.spawnPoint].position;
                SpawnEnemies.current.enemies[i].transform.rotation = MonsterStats.instance.spawnPlaces[SpawnEnemies.current.spawnPoint].rotation;
                SpawnEnemies.current.enemies[i].SetActive(true);
                SpawnEnemies.current.enemies[i].transform.SetParent(null);
                break;

            }
        }
    }


    IEnumerator DisableMonster(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        MonsterDestroying.current.Destroy(obj);
    }

}
