using UnityEngine;
using System.Collections;

public class MonsterStun : MonoBehaviour
{

    public static MonsterStun current;
    //public ParticleSystem particleStunned;
	public GameObject particleStunned;
  

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
		//particleStunned = GameObject.FindGameObjectWithTag ("StunParticle");
		//particleStunned.SetActive (false);
    }


    public void Stun(GameObject obj)
    {
        if (!Intro.instance.stopPlayerMove)
        {
            if (canStun == true && MoveEnemies.instance.isSearching == true)
            {
                print("I am on Nicolaj's Stun");
                canStun = false;
                obj.GetComponent<NavMeshAgent>().Stop();
                GameManager.instance.monsterNotMoving(obj); //monster stops swimming
                GameManager.instance.MonsterStun(obj);
                monsterStunned = true;
                //particleStunned = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ParticleSystem>();
                //particleStunned.Play();
				particleStunned.SetActive(true);
                PlayerStats.instance.spotlight.intensity = 8;
                StartCoroutine("LightCooldown");
                StartCoroutine("Cooldown");
                StartCoroutine(MonsterCooldown(obj));
            }
        }
        else
        {
            print("I am on this fucking stun");
            //particleStunned = GameObject.FindGameObjectWithTag("Enemy").GetComponent<ParticleSystem>();
            //particleStunned.Play();
            GameManager.instance.monsterNotMoving(obj); //monster stops swimming
            GameManager.instance.MonsterStun(obj);
            monsterStunned = true;
			particleStunned.SetActive(true);
            PlayerStats.instance.spotlight.intensity = 8;
            //print(PlayerStats.instance.spotlight.intensity);
            GameManager.instance.player.transform.LookAt(obj.transform.position);
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
        //particleStunned.Stop();
		particleStunned.SetActive(false);
        GameManager.instance.monsterMove (obj); //monster starts swimming
        //Debug.Log(monsterStunned);
        GameManager.instance.MonsterRecoil(obj);
    }
}

