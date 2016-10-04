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

    public void Destroy(GameObject obj)
    {
		GameManager.instance.monsterNotMoving (obj); //monster stops swimming
        obj.transform.SetParent(SpawnEnemies.current.poolParent.transform);
		obj.SetActive(false);
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
