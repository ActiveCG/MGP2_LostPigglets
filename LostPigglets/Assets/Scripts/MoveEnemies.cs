using UnityEngine;
using System.Collections;

public class MoveEnemies : MonoBehaviour
{
    //private GameObject pig;
    private Animator animEnemy;
    private NavMeshAgent nav;
    private bool canJump = true;
    private bool canAttack = false;
    private bool canResume = false;
    private bool canSearch = true;
    private float timer;

    [HideInInspector]
    public bool isSwimming;
    [Tooltip("The duration time the player has to be in range before dying")]
    public float timeToDeath = 8f;
    [Tooltip("The frequency of jumps for the monster")]
    public int jumpingCooldownTimer;
    [Tooltip("The duration of the death animation")]
    public int deathAnimTime = 3;
    [Tooltip("The range where the monster should be attacking")]
    public int attackRange;
    [Tooltip("The range where the monster should be searching")]
    public int visibilityRange;
    [Tooltip("How often should the monster jump (This value is excluded as in jumping-1)")]
    public int jumping;

    [HideInInspector]
    public Transform target;

    void OnEnable()
    {
        GameManager.instance.OnMonsterJump += Jump;
        GameManager.instance.OnMonsterAttack += Attack;
        GameManager.instance.OnMonsterAggro += Search;
    }

    void OnDisable()
    {
        GameManager.instance.OnMonsterJump -= Jump;
        GameManager.instance.OnMonsterAttack -= Attack;
        GameManager.instance.OnMonsterAggro -= Search;
    }

    void Start()
    {
        //pig = GameObject.FindGameObjectWithTag("Player");
        target = GameManager.instance.player.transform;
        animEnemy = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        nav.SetDestination(target.position); //move towards target
        // If the monster can jump and the value between 1 and jumping-1 it will jump
        if (Random.Range(1, jumping) == 1 && canJump == true)
        {
            GameManager.instance.MonsterJump(gameObject);
        }
        // If the monster is inside the attackRange and canAttack is true the monster can kill the player
        if (Vector3.Distance(transform.position, target.transform.position) < attackRange && canAttack == true && MonsterStun.current.monsterStunned == false)
        {
            timer += Time.deltaTime;
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
            GameManager.instance.MonsterOutRange(gameObject);
            nav.Resume();
            canAttack = false;
            canResume = false;
            canSearch = true;
            timer = 0;
        }
        // If the monster is inside the visibilityRange it starts searching
        if (Vector3.Distance(transform.position, target.transform.position) < visibilityRange == canSearch == true && MonsterStun.current.monsterStunned == false)
        {
            GameManager.instance.MonsterAggro(gameObject);
            canSearch = false;
            canAttack = true;
            canResume = true;
        }
    }

    void Jump(GameObject monster)
    {
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


