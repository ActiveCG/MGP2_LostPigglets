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
        PlayerStats.instance.playerSpeed = Intro.instance.initialSpeed;
        PlayerStats.instance.acceleration = Intro.instance.initialAcc;
        PlayerStats.instance.spotlight.intensity = Intro.instance.initialIntensity;
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
