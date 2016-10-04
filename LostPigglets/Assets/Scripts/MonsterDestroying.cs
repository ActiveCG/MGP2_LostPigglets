using UnityEngine;
using System.Collections;

public class MonsterDestroying : MonoBehaviour {

    public static MonsterDestroying current;

    void Awake()
    {
        current = this;
    }

 //   //Only for testing purposes the enemies are going to be destroyed after 2 seconds
	//void OnEnable()
 //   {
 //       Invoke("Destroy", 100f);
 //   }

    void OnEnable()
    {
        GameManager.instance.OnMonsterDeath += Destroy;
    }

    void OnDisable()
    {
        GameManager.instance.OnMonsterDeath -= Destroy;
    }

    public void Destroy(GameObject obj)
    {
		GameManager.instance.monsterNotMoving (obj); //monster stops swimming
        obj.transform.SetParent(SpawnEnemies.current.poolParent.transform);
		obj.SetActive(false);
        Intro.instance.stopPlayerMove = false;
        Intro.instance.stopPlayerRotate = false;
        Intro.instance.letPlayerCharge = false;
        Intro.instance.introRotationMonster = false;
        Intro.instance.makeTheMonsterStatic = false;
        Intro.instance.makeMonsterJump = false;
        MoveEnemies.instance.isSearching = false;
        MoveEnemies.instance.canJump = true;
        PlayerStats.instance.spotlight.intensity = 2;
        PlayerStats.instance.playerSpeed = Intro.instance.initialSpeed;
        PlayerStats.instance.acceleration = Intro.instance.initialAcc;
        PlayerStats.instance.spotlight.intensity = Intro.instance.initialIntensity;
        MonsterStun.current.monsterStunned = false;
        GameManager.instance.monsterMove(obj); //monster starts swimming
        GameManager.instance.MonsterRecoil(obj);
        //MonsterStun.current.particleStunned.Stop();
		MonsterStun.current.particleStunned.SetActive(false);
    }

    //void OnDestroy()
    //{
    //    print("Destroyed");
    //}

    //void OnDisable()
    //{
    //    print("Disabled");
    //}
}
