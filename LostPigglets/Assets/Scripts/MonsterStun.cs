using UnityEngine;
using System.Collections;

public class MonsterStun : MonoBehaviour
{

    public static MonsterStun current;

    public float lightTimer = 1f;
    public float cdTimer = 8f;
    public float monsterStunTime = 2f;

    bool monsterNewDes = false;
    bool canStun;

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
            Fighting.spotlight.intensity = 8;
            StartCoroutine("LightCooldown");
            StartCoroutine("Cooldown");
            StartCoroutine(MonsterCooldown(obj));
        }
    }
    IEnumerator LightCooldown()
    {
        yield return new WaitForSeconds(lightTimer);
        Fighting.spotlight.intensity = 2;
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cdTimer);
        canStun = true;
    }
    IEnumerator MonsterCooldown(GameObject obj)
    {
        yield return new WaitForSeconds(monsterStunTime);
        Debug.Log(canStun);
        obj.GetComponent<NavMeshAgent>().Resume();
    }
}

