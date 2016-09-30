using UnityEngine;
using System.Collections;

public class MonsterStun : MonoBehaviour
{

    public static MonsterStun current;
  

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
        if (canStun == true)
        {
            canStun = false;
            obj.GetComponent<NavMeshAgent>().Stop();
			GameManager.instance.monsterNotMoving (obj); //monster stops swimming
            monsterStunned = true;
            PlayerStats.instance.spotlight.intensity = 8;
            StartCoroutine("LightCooldown");
            StartCoroutine("Cooldown");
            StartCoroutine(MonsterCooldown(obj));
        }
    }


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
		GameManager.instance.monsterMove (obj); //monster starts swimming
    }
}

