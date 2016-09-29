using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	void OnEnable () {
		GameManager.instance.OnMonsterAttack += TakeDamage;

	}
	
	void OnDisable() {
		GameManager.instance.OnMonsterAttack -= TakeDamage;
	}

	//recieve damage from monsters
	void TakeDamage(GameObject monster){
		Die ();
	}

	void Die(){
		GameManager.instance.notMoving (transform.position);
		GameManager.instance.GameOver ();
	}
}
