using UnityEngine;
using System.Collections;

public class ChargedOnMonster : MonoBehaviour {

    public static ChargedOnMonster instance;
    

    void Awake()
    {
        instance = this;
    }

	void OnEnable()
    {
        GameManager.instance.OnChargeOnStun += OnTriggerEnter;
    }

    void OnDisable()
    {
        GameManager.instance.OnChargeOnStun -= OnTriggerEnter;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy" && MonsterStun.current.monsterStunned)
        {
            //Debug.Log("Hit the enemy");
            ///////PLAY ANIMATION/////////
            StartCoroutine(MonsterPushedBack(MonsterStats.instance.destroyTimeAfterHit, col));
        }
    }

    IEnumerator MonsterPushedBack(float time, Collider enemyCol)
    {
        yield return new WaitForSeconds(time);
        MonsterDestroying.current.Destroy(enemyCol.gameObject);
    }
}
