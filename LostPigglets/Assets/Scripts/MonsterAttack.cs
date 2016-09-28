using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour {
	//public delegate void MonsterAttacks(GameObject monster);
	//public static event MonsterAttacks monsterAttacks;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			GameManager.instance.MonsterAttacks (gameObject);
		}
	}

	//attack player
	void Attack(){
		
	}
}
