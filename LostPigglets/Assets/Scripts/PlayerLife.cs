using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	void OnEnable () {
		MonsterAttack.monsterAttacks += TakeDamage;
	}
	
	void OnDisable() {
		MonsterAttack.monsterAttacks -= TakeDamage;
	}

	//recieve damage from monsters
	void TakeDamage(){
		Die ();
	}

	void Die(){
		SceneController.current.GameOver ();
	}
}
