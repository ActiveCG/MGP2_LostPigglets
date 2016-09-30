using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	[Header ("-- Player --")]
	[SerializeField]
	private string playerSwimStart;
	[SerializeField]
	private string playerSwimStop,
		//playerDamaged,
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
	/*void PlayerDamagedPlay(int health) {
		PlaySound (playerDamaged, GameManager.instance.player);
	}*/
	void PlayerDeathPlay(int health) {
		PlaySound (playerDeath, GameManager.instance.player);
	}
	void PickUpObjectPlay(GameObject pickedObject) {
		PlaySound (playerPickUp, pickedObject);
	}

	//*********** Pigglet ****************
	void PiggletOinkPlay(GameObject pigglet){
		PlaySound (oink, pigglet);
	}

	//*********** Monster ****************
	void MonsterSwimPlay(GameObject monster){
		if (monster.GetComponent<MoveEnemies>().isSwimming == true)
			return;
		PlaySound (monsterSwimStart, monster);
		monster.GetComponent<MoveEnemies> ().isSwimming = true;
	}
	void MonsterSwimStop(GameObject monster){
		if (monster.GetComponent<MoveEnemies>().isSwimming == false)
			return;
		PlaySound (monsterSwimStop, monster);
		monster.GetComponent<MoveEnemies> ().isSwimming = false;
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

	//*********** Menu ****************
	void MenuButtonPlay() {

	}
	void SetMenuState(string state) {
		if (menuStateGroup == null || menuStateGroup == "")
			return;
		AkSoundEngine.SetState (menuStateGroup, state);
	}

	//Subscribing and unsubscribing to delegate events
	void OnEnable () {
		isPlayerSwimming = false;
		//player events
		GameManager.instance.OnPlayerMove += PlayerSwimPlay;
		GameManager.instance.OnPlayerNotMoving += PlayerSwimStop;
		//GameManager.instance.OnPlayerDamage += PlayerDamagedPlay;
		GameManager.instance.OnPlayerDeath += PlayerDeathPlay;
		GameManager.instance.OnPickUp += PickUpObjectPlay;

		//piglet events
		GameManager.instance.OnPigletOink += PiggletOinkPlay;

		//monster events
		GameManager.instance.OnMonsterMove += MonsterSwimPlay;
		GameManager.instance.OnMonsterNotMoving += MonsterSwimStop;
		GameManager.instance.OnMonsterAttack += MonsterAttackPlay;

		//menu events
		GameManager.instance.OnmenuStates += SetMenuState;
	}

	void OnDisable() {
		//player events
		GameManager.instance.OnPlayerMove -= PlayerSwimPlay;
		GameManager.instance.OnPlayerNotMoving -= PlayerSwimStop;
		//GameManager.instance.OnPlayerDamage -= PlayerDamagedPlay;
		GameManager.instance.OnPlayerDeath -= PlayerDeathPlay;
		GameManager.instance.OnPickUp -= PickUpObjectPlay;

		//piglet events
		GameManager.instance.OnPigletOink -= PiggletOinkPlay;

		//monster events
		GameManager.instance.OnMonsterMove -= MonsterSwimPlay;
		GameManager.instance.OnMonsterNotMoving -= MonsterSwimStop;
		GameManager.instance.OnMonsterAttack -= MonsterAttackPlay;

		//menu events
		GameManager.instance.OnmenuStates -= SetMenuState;
	}

	private void PlaySound(string eventName, GameObject obj) {
		if (eventName == null || eventName == "")
			return;
		AkSoundEngine.PostEvent (eventName, obj);
		AkSoundEngine.RenderAudio ();
	}
}
