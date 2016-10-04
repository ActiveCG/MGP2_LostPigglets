﻿using UnityEngine;
using System.Collections;

public class MoveEnemies : MonoBehaviour
{
    public static MoveEnemies instance;

    //private GameObject pig;
    private Animator animEnemy;
    private NavMeshAgent nav;
    public bool canJump = true;
    public bool canAttack = false;
    public bool canResume = false;
    public bool canSearch = true;
    public bool isSearching = false;
    public float timer;
    private ParticleSystem particles;

    [HideInInspector]
    public bool isSwimming;
    [Tooltip("The duration time the player has to be in range before dying")]
    public float timeToDeath = 8f;
    [Tooltip("The frequency of jumps for the monster")]
    public int jumpingCooldownTimer;
    [Tooltip("The range where the monster should be attacking")]
    public int attackRange;
    [Tooltip("The range where the monster should be searching")]
    public int visibilityRange;
    [Tooltip("How often should the monster jump (This value is excluded as in jumping-1)")]
    public int jumping;

    [HideInInspector]
    public Transform target;


    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        MonsterDestroying.current.stopHandAnim = false;
        GameManager.instance.OnMonsterJump += Jump;
        GameManager.instance.OnMonsterAttack += Attack;
        GameManager.instance.OnMonsterAggro += Search;
        //GetComponent<EnemyRubberBanding>().enabled = true;
        //particles.Play();
    }

    void OnDisable()
    {
        GameManager.instance.OnMonsterJump -= Jump;
        GameManager.instance.OnMonsterAttack -= Attack;
        GameManager.instance.OnMonsterAggro -= Search;
        //particles.Stop();
    }

    void Start()
    {
        //pig = GameObject.FindGameObjectWithTag("Player");
        particles = GetComponentInChildren<ParticleSystem>();
        target = GameManager.instance.player.transform;
        animEnemy = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!Intro.instance.stopPlayerMove)
        {
            if (Intro.instance.introRotationMonster)
            {
                nav.SetDestination(OldTouchInput.instance.hit.point);
            }
            else
            {
                nav.SetDestination(target.position); //move towards target
            }
        }

        // If the monster can jump and the value between 1 and jumping-1 it will jump
        if(!Intro.instance.makeMonsterJump)
        {
            if (!Intro.instance.makeTheMonsterStatic)
            {
                if (Random.Range(1, jumping) == 1 && canJump == true)
                {
                    print("Jump");
                    GameManager.instance.MonsterJump(gameObject);
                }
            }
            else
            {
                GameManager.instance.MonsterAggro(gameObject);
            }
            
        }
        else if(Intro.instance.makeMonsterJump)
        {
            GameManager.instance.MonsterJump(gameObject);
        }

        // If the monster is inside the attackRange and canAttack is true the monster can kill the player
        if (Vector3.Distance(transform.position, target.transform.position) < attackRange && canAttack == true && MonsterStun.current.monsterStunned == false && !Intro.instance.stopPlayerMove)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            isSearching = true;
            if (timer > timeToDeath)
            {
                GameManager.instance.MonsterAttacks(gameObject);
                canSearch = true;
                canResume = false;
                canAttack = false;
                timer = 0;
            }
        }

        // If the monster is outside the attackRange it resumes chasing
        if (Vector3.Distance(transform.position, target.transform.position) > attackRange && canResume == true)
        {
            GameManager.instance.MonsterRecoil(gameObject);
            GameManager.instance.MonsterOutRange(gameObject);
            nav.Resume();
            isSearching = false;
            canAttack = false;
            canResume = false;
            canSearch = true;
            timer = 0;
            particles.Play();
        }
        // If the monster is inside the visibilityRange it starts searching
        if (!Intro.instance.stopPlayerMove)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < visibilityRange && canSearch == true && MonsterStun.current.monsterStunned == false)
            {
                GameManager.instance.MonsterAggro(gameObject);
                isSearching = false;
                canSearch = false;
                canAttack = true;
                canResume = true;
                particles.Stop();
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, target.transform.position) < visibilityRange)
            {
                print("I am inside new");
                isSearching = true;
            }
        }


        if (MonsterStun.current.monsterStunned == true)
        {
            timer = 0;
            canJump = false;
        }
    }

    void Jump(GameObject monster)
    {
            //print("CAME INTO THAT");
        canJump = false;
        StartCoroutine("AnimationCD");
    }

    void Search(GameObject monster)
    {
        canJump = false;
        nav.Stop();
    }

    void Attack(GameObject monster)
    {
        canJump = false;
    }

    IEnumerator AnimationCD()
    {
        yield return new WaitForSeconds(jumpingCooldownTimer);
        canJump = true;
    }
}


