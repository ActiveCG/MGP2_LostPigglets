using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	[Header ("-- Player --")]
	[SerializeField]
	private string playerSwim;
	[SerializeField]
	private string //playerSwimStop,
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
		monsterSlinky,
		monsterAttack,
		monsterStun,
		monsterStunnedStart,
		monsterStunnedStop,
		monsterSearchingEmerge,
		monsterSearchingStart,
		monsterSearchingStop,
		monsterSearchingSubmerge,
		monsterSearchingTap,
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
	void PlayerSwim(Vector3 position){
		PlaySound (playerSwim, GameManager.instance.player);
	}
	/*void PlayerSwimPlay(Vector3 position){
		if (isPlayerSwimming == true)
			return;
		PlaySound (playerSwim, GameManager.instance.player);
		isPlayerSwimming = true;
	}*/
	/*void PlayerSwimStop(Vector3 position){
		if (isPlayerSwimming == false)
			return;
		PlaySound (playerSwimStop, GameManager.instance.player);
		isPlayerSwimming = false;
	}*/
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
	void MonsterSlinkyPlay(GameObject monster){
		PlaySound (monsterSlinky, monster);
	}
	void MonsterAttackPlay(GameObject monster){
		PlaySound (monsterAttack, monster);
	}
	void MonsterStunPlay(GameObject monster){
		PlaySound (monsterStun, monster);
	}
	void MonsterStunnedPlay(GameObject monster){
		PlaySound (monsterStunnedStart, monster);
	}
	void MonsterStunnedStop(GameObject monster){
		PlaySound (monsterStunnedStop, monster);
	}
	void MonsterSearchingEmergePlay(GameObject monster){
		PlaySound (monsterSearchingEmerge, monster);
	}
	void MonsterSearchingStartPlay(GameObject monster){
		PlaySound (monsterSearchingStart, monster);
	}
	void MonsterSearchingStop(GameObject monster){
		PlaySound (monsterSearchingStop, monster);
	}
	void MonsterSearchingSubmergePlay(GameObject monster){
		PlaySound (monsterSearchingSubmerge, monster);
	}
	void MonsterSearchingTapPlay(GameObject monster){
		PlaySound (monsterSearchingTap, monster);
	}
	void MonsterDeathPlay(GameObject monster){
		PlaySound (monsterDeath, monster);
	}

	//*********** Environment ****************
	void AmbiencePlay(GameObject obj) {
		PlaySound (ambienceStart, transform.gameObject);
	}
	void AmbienceStop(GameObject obj) {
		PlaySound (ambienceStop, transform.gameObject);
	}

	//*********** Menu ****************
	void MenuButtonPlay(string element) {
		PlaySound (menuButton, transform.gameObject);
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
		GameManager.instance.OnPlayerSwim += PlayerSwim;
		//GameManager.instance.OnPlayerMove += PlayerSwimPlay;
		//GameManager.instance.OnPlayerNotMoving += PlayerSwimStop;
		//GameManager.instance.OnPlayerDamage += PlayerDamagedPlay;
		GameManager.instance.OnPlayerDeath += PlayerDeathPlay;
		GameManager.instance.OnPickUp += PickUpObjectPlay;

		//piglet events
		GameManager.instance.OnPigletOink += PiggletOinkPlay;

		//monster events
		GameManager.instance.OnMonsterMove += MonsterSwimPlay;
		GameManager.instance.OnMonsterNotMoving += MonsterSwimStop;
		GameManager.instance.OnMonsterJump += MonsterSlinkyPlay;
		GameManager.instance.OnMonsterAttack += MonsterAttackPlay;
		GameManager.instance.OnMonsterStun += MonsterStunPlay;
		GameManager.instance.OnMonsterAggro += MonsterSearchingEmergePlay;
		GameManager.instance.OnMonsterAggro += MonsterSearchingStartPlay;
		GameManager.instance.OnMonsterSubmerge += MonsterSearchingSubmergePlay;
		GameManager.instance.OnMonsterSubmerge += MonsterSearchingStop;
		GameManager.instance.OnMonsterWaterTap += MonsterSearchingTapPlay;
		GameManager.instance.OnMonsterDeath += MonsterDeathPlay;

		//environment events
		GameManager.instance.OnAmbience += AmbiencePlay;
		GameManager.instance.OnAmbienceStop += AmbienceStop;

		//menu events
		GameManager.instance.OnmenuStates += SetMenuState;
		GameManager.instance.OnMenuButton += MenuButtonPlay;
    }

    void Start()
    {
        //INITIATE SOUNDS
        GameManager.instance.ambience(gameObject);
        if (GameManager.instance.IsInGameScene() == true)
        {
            GameManager.instance.menuStateChanged("In_Game");
        }
        else
        {
            GameManager.instance.menuStateChanged("In_Menu");
        }
    }

	void OnDisable() {
		//player events
		GameManager.instance.OnPlayerSwim -= PlayerSwim;
		//GameManager.instance.OnPlayerMove -= PlayerSwimPlay;
		//GameManager.instance.OnPlayerNotMoving -= PlayerSwimStop;
		//GameManager.instance.OnPlayerDamage -= PlayerDamagedPlay;
		GameManager.instance.OnPlayerDeath -= PlayerDeathPlay;
		GameManager.instance.OnPickUp -= PickUpObjectPlay;

		//piglet events
		GameManager.instance.OnPigletOink -= PiggletOinkPlay;

		//monster events
		GameManager.instance.OnMonsterMove -= MonsterSwimPlay;
		GameManager.instance.OnMonsterNotMoving -= MonsterSwimStop;
		GameManager.instance.OnMonsterJump -= MonsterSlinkyPlay;
		GameManager.instance.OnMonsterAttack -= MonsterAttackPlay;
		GameManager.instance.OnMonsterStun -= MonsterStunPlay;
		GameManager.instance.OnMonsterAggro -= MonsterSearchingEmergePlay;
		GameManager.instance.OnMonsterAggro -= MonsterSearchingStartPlay;
		GameManager.instance.OnMonsterSubmerge -= MonsterSearchingSubmergePlay;
		GameManager.instance.OnMonsterSubmerge -= MonsterSearchingStop;
		GameManager.instance.OnMonsterWaterTap -= MonsterSearchingTapPlay;
		GameManager.instance.OnMonsterDeath -= MonsterDeathPlay;

		//environment events
		GameManager.instance.OnAmbience -= AmbiencePlay;
		GameManager.instance.OnAmbienceStop -= AmbienceStop;

		//menu events
		GameManager.instance.OnmenuStates -= SetMenuState;
		GameManager.instance.OnMenuButton -= MenuButtonPlay;

        //DEINITIATE SOUNDS
        GameManager.instance.ambienceStop(gameObject);
    }

	private void PlaySound(string eventName, GameObject obj) {
		if (eventName == null || eventName == "")
			return;
		AkSoundEngine.PostEvent (eventName, obj);
		AkSoundEngine.RenderAudio ();
	}
}
