﻿using UnityEngine;
using System.Collections;

public class MonsterStun : MonoBehaviour
{

    public static MonsterStun current;
    public ParticleSystem particleStunned;
  

    [HideInInspector]
    public bool monsterStunned = false;
    private bool monsterNewDes = false;
    private bool canStun;


    void Awake()
    {
        current = this;
    }


    void Start()
    {
        canStun = true;
    }


    public void Stun(GameObject obj)
    {
        if (!Intro.instance.stopPlayerMove)
        {
            if (canStun == true && MoveEnemies.instance.isSearching == true)
            {
                canStun = false;
                obj.GetComponent<NavMeshAgent>().Stop();
                GameManager.instance.monsterNotMoving(obj); //monster stops swimming
                GameManager.instance.MonsterStun(obj);
                monsterStunned = true;
                particleStunned = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ParticleSystem>();
                particleStunned.Play();
                PlayerStats.instance.spotlight.intensity = 8;
                StartCoroutine("LightCooldown");
                StartCoroutine("Cooldown");
                StartCoroutine(MonsterCooldown(obj));
            }
        }
        else
        {
            print("I am on this fucking stun");
            GameManager.instance.monsterNotMoving(obj); //monster stops swimming
            GameManager.instance.MonsterStun(obj);
            monsterStunned = true;
            particleStunned = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ParticleSystem>();
            particleStunned.Play();
            PlayerStats.instance.spotlight.intensity = 8;
        }
    }

    //void Update()
    //{
    //    print(canStun);
    //    print(MoveEnemies.instance.canJump);
    //}

    IEnumerator LightCooldown()
    {
        yield return new WaitForSeconds(MonsterStats.instance.BlindingTimer);
        PlayerStats.instance.spotlight.intensity = 2;
    }


    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(MonsterStats.instance.cooldownTimer);
        canStun = true;
    }


    IEnumerator MonsterCooldown(GameObject obj)
    {
        yield return new WaitForSeconds(MonsterStats.instance.monsterStunTime);
        obj.GetComponent<NavMeshAgent>().Resume();
        monsterStunned = false;
        particleStunned.Stop();
        GameManager.instance.monsterMove (obj); //monster starts swimming
        //Debug.Log(monsterStunned);
        GameManager.instance.MonsterRecoil(obj);
    }
}

