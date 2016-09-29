using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	void OnEnable () {
		//set player's start health to 100
		PlayerStats.instance.playerHealth = 100;

		GameManager.instance.OnMonsterAttack += TakeDamage;
		GameManager.instance.OnPlayerDeath += Die;

	}
	
	void OnDisable() {
		GameManager.instance.OnMonsterAttack -= TakeDamage;
		GameManager.instance.OnPlayerDeath -= Die;
	}

	//recieve damage from monsters
	void TakeDamage(GameObject monster){
		int damage = MonsterStats.instance.damageAmount;
		PlayerStats.instance.playerHealth -= damage; //die immediatelly after getting hit

		//check whether out of life:
		if (PlayerStats.instance.playerHealth > 0) {
			GameManager.instance.playerDamaged (damage);
		} else {
			GameManager.instance.playerDies (0);
		}
	}

	//to happen when player dies
	void Die(int playerHealth) {
		GameManager.instance.notMoving (transform.position);
		GameManager.instance.GameOver ();
	}
}
