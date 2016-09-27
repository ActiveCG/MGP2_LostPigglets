using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour {
	public delegate void MonsterAttacks();
	public static event MonsterAttacks monsterAttacks;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Attack ();
		}
	}

	//attack player
	void Attack(){
		monsterAttacks ();
	}
}
