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
		AkSoundEngine.PostEvent (playerSwimStart, GameManager.instance.player);
		isPlayerSwimming = true;
		AkSoundEngine.RenderAudio ();
	}

	void PlayerSwimStop(Vector3 position){
		if (isPlayerSwimming == false)
			return;
		AkSoundEngine.PostEvent (playerSwimStop, GameManager.instance.player);
		isPlayerSwimming = false;
		AkSoundEngine.RenderAudio ();
	}

	//*********** Monster ****************
	void MonsterSwimPlay(GameObject monster){
		AkSoundEngine.PostEvent (monsterSwimStart, monster);
		AkSoundEngine.RenderAudio ();
	}

	void MonsterSwimStop(GameObject monster){
		AkSoundEngine.PostEvent (monsterSwimStop, monster);
		AkSoundEngine.RenderAudio ();
	}
	void MonsterAttackPlay(GameObject monster){
		AkSoundEngine.PostEvent (monsterAttack, monster);
		AkSoundEngine.RenderAudio ();
	}
	void MonsterAggroPlay(GameObject monster){
		AkSoundEngine.PostEvent (monsterAggro, monster);
		AkSoundEngine.RenderAudio ();
	}
	void MonsterGrowlAmbPlay(GameObject monster){
		AkSoundEngine.PostEvent (monsterGrowlAmbStart, monster);
		AkSoundEngine.RenderAudio ();
	}
	void MonsterGrowlAmbStop(GameObject monster){
		AkSoundEngine.PostEvent (monsterGrowlAmbStop, monster);
		AkSoundEngine.RenderAudio ();
	}
	void MonsterStunPlay(GameObject monster){
		AkSoundEngine.PostEvent (monsterStun, monster);
		AkSoundEngine.RenderAudio ();
	}
	void MonsterDeathPlay(GameObject monster){
		AkSoundEngine.PostEvent (monsterDeath, monster);
		AkSoundEngine.RenderAudio ();
	}

	//Subscribing and unsubscribing to delegate events
	void OnEnable () {
		isPlayerSwimming = false;
		//player events
		GameManager.instance.OnPlayerMove += PlayerSwimPlay;
		GameManager.instance.OnPlayerNotMoving += PlayerSwimStop;

		//monster events
		GameManager.instance.OnMonsterAttack += MonsterAttackPlay;
	}

	void OnDisable() {
		//player events
		GameManager.instance.OnPlayerMove -= PlayerSwimPlay;
		GameManager.instance.OnPlayerNotMoving -= PlayerSwimStop;

		//monster events
		GameManager.instance.OnMonsterAttack -= MonsterAttackPlay;
	}
}
