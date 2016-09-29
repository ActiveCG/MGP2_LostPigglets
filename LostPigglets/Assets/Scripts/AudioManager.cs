using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	[Header ("-- Player --")]
	[SerializeField]
	private string playerSwimStart;
	[SerializeField]
	private string playerSwimStop,
		playerDamaged,
		playerChargeHit,
		playerPickUp,
		playerDeath,
		playerLightStart,
		playerLightStop,
		playerSpawn;

	[Header ("-- Pigglet --")]
	[SerializeField]
	private string oink;

	[Header ("-- Monster --")]
	[SerializeField]
	private string monsterSwimStart;
	[SerializeField]
	private string monsterSwimStop,
		monsterAttack,
		monsterAggro,
		monsterGrowlAmbStart,
		monsterGrowlAmbStop,
		monsterStun,
		monsterDeath;

	[Header ("-- Environment --")]
	[SerializeField]
	private string ambienceStart;
	[SerializeField]
	private string ambienceStop,
		lightFlower,
		caveObject,
		collision,
		ambienceBuildUp;

	[Header ("-- Menu --")]
	[SerializeField]
	private string menuButton;
	[SerializeField]
	private string menuStateGroup;

	//script variables
	private bool isPlayerSwimming = false;

	//*********** Player ****************
	void PlayerSwimPlay(Vector3 position){
		if (isPlayerSwimming == true)
			return;
		PlaySound (playerSwimStart, GameManager.instance.player);
		isPlayerSwimming = true;
	}

	void PlayerSwimStop(Vector3 position){
		if (isPlayerSwimming == false)
			return;
		PlaySound (playerSwimStop, GameManager.instance.player);
		isPlayerSwimming = false;
	}

	void PickUpObject(GameObject pickedObject) {
		PlaySound (playerPickUp, pickedObject);
	}

	//*********** Monster ****************
	void MonsterSwimPlay(GameObject monster){
		PlaySound (monsterSwimStart, monster);
	}

	void MonsterSwimStop(GameObject monster){
		PlaySound (monsterSwimStop, monster);
	}
	void MonsterAttackPlay(GameObject monster){
		PlaySound (monsterAttack, monster);
	}
	void MonsterAggroPlay(GameObject monster){
		PlaySound (monsterAggro, monster);
	}
	void MonsterGrowlAmbPlay(GameObject monster){
		PlaySound (monsterGrowlAmbStart, monster);
	}
	void MonsterGrowlAmbStop(GameObject monster){
		PlaySound (monsterGrowlAmbStop, monster);
	}
	void MonsterStunPlay(GameObject monster){
		PlaySound (monsterStun, monster);
	}
	void MonsterDeathPlay(GameObject monster){
		PlaySound (monsterDeath, monster);
	}

	//Subscribing and unsubscribing to delegate events
	void OnEnable () {
		isPlayerSwimming = false;
		//player events
		GameManager.instance.OnPlayerMove += PlayerSwimPlay;
		GameManager.instance.OnPlayerNotMoving += PlayerSwimStop;
		GameManager.instance.OnPickUp += PickUpObject;

		//monster events
		GameManager.instance.OnMonsterAttack += MonsterAttackPlay;
	}

	void OnDisable() {
		//player events
		GameManager.instance.OnPlayerMove -= PlayerSwimPlay;
		GameManager.instance.OnPlayerNotMoving -= PlayerSwimStop;
		GameManager.instance.OnPickUp -= PickUpObject;

		//monster events
		GameManager.instance.OnMonsterAttack -= MonsterAttackPlay;
	}

	private void PlaySound(string eventName, GameObject obj) {
		if (eventName == null || eventName == "")
			return;
		AkSoundEngine.PostEvent (eventName, obj);
		AkSoundEngine.RenderAudio ();
	}
}
