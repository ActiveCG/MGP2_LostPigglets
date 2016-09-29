using UnityEngine;
using System.Collections;

public class MoveEnemies : MonoBehaviour
{
    //private GameObject pig;
    private NavMeshAgent nav;
    private bool isInRange = true;
    private bool canJump = true;
    private float timer;

    public bool isSwimming;
    [Tooltip("The duration time the player has to be in range before dying")]
    public float timeToDeath = 8f;
    [Tooltip("The frequency of jumps for the monster")]
    public int jumpingCooldownTimer;
    [Tooltip("The duration of the death animation")]
    public int deathAnimTime = 3;
    [Tooltip("The range where the monster should be attacking")]
    public int attackRange;
    [Tooltip("This value is exclusive")]
    public int jumping;
   
    [HideInInspector]
    public Transform target;

    /*void OnEnable()
    {
        GameManager.instance.OnMonsterJump += Jump;
    }

    void OnDisable()
    {
        GameManager.instance.OnMonsterJump -= Jump;
    }*/

    void Start()
    {
        //pig = GameObject.FindGameObjectWithTag("Player");
        target = GameManager.instance.player.transform;
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        nav.SetDestination(target.position); //move towards target
        if (Random.Range(1, jumping) == 1 && canJump == true)
        {
            Jump();
        }
        if (Vector3.Distance(transform.position, target.transform.position) < attackRange)
        {
            isInRange = true;
            timer += Time.deltaTime;
            if (timer > timeToDeath)
            {
                Attack();
            }
        }
        else isInRange = false;
    }

    void Jump()
    {
        canJump = false;
        StartCoroutine("AnimationCD");
    }

    void Attack()
    {
        StartCoroutine("DeathAnimationTime");
    }

    IEnumerator AnimationCD()
    {
        yield return new WaitForSeconds(jumpingCooldownTimer);
        canJump = true;
    }

    IEnumerator DeathAnimationTime()
    {
        yield return new WaitForSeconds(deathAnimTime);
        GameManager.instance.GameOver();
    }
}
