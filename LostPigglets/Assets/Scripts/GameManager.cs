using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager {

	private static string START_SCENE = "IntroScene";
	private static string GAME_SCENE = "Development";

	private static GameManager _instance;

	private GameObject _player;
	private AudioManager _audioManager;

	//getters:
	public static GameManager instance{
		get {
			if (_instance == null)
				_instance = new GameManager ();
			return _instance;
		}
	}

	public GameObject player{
		get {
			if (_player == null)
				_player = GameObject.FindGameObjectWithTag("Player");
			return _player;
		}
	}

	public AudioManager audioManager{
		get {
			if (_audioManager == null)
				_audioManager = Object.FindObjectOfType(typeof(AudioManager)) as AudioManager;
			return _audioManager;
		}
	}

	//scene management:
	public void PauseGame() {
		//to be filled later
	}

	public void StartGame() {
		SceneManager.LoadScene (GAME_SCENE);
	}

	public void RestartGame() {
		_instance = null;
		SceneManager.LoadScene (GAME_SCENE);
	}

	public void Win(){
		SceneManager.LoadScene ("Win");
	}

	public void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}

	//delegates
	//**** player ****
	public delegate void MovementInput(Vector3 position);
	public event MovementInput OnPlayerMove;
	public event MovementInput OnPlayerRotate;
	public event MovementInput OnPlayerNotMoving;
	public void move(Vector3 position) {
		OnPlayerMove (position);
	}
	public void rotate(Vector3 position) {
		OnPlayerRotate (position);
	}
	public void notMoving(Vector3 position) {
		OnPlayerNotMoving (position);
	}

	public delegate void HealthAction(int amount);
	public event HealthAction OnPlayerDamage;
	public event HealthAction OnPlayerDeath;
	public event HealthAction OnPlayerSpawn;
	public void playerDamaged(int damageAmount) {
		OnPlayerDamage (damageAmount);
	}
	public void playerDies(int healthAmount) {
		OnPlayerDeath (healthAmount);
	}
	public void playerSpawn(int healthAmount) {
		OnPlayerSpawn (healthAmount);
	}

	public delegate void PickUpAction();
	public event PickUpAction OnPickUp;
	public void pickUpPigglet() {
		OnPickUp ();
	}

	public delegate void FightingAction();
	public event FightingAction OnLight;
	public event FightingAction OnChargeHit;
	public void light() {
		OnLight ();
	}
	public void chargeHit() {
		OnChargeHit ();
	}

	//**** pigglet****
	public delegate void PigletAction();
	public event PigletAction OnPigletOink;
	public void oink() {
		OnPigletOink ();
	}

	//**** monsters ****
	public delegate void MonsterAction(GameObject monster);
	public event MonsterAction OnMonsterMove;
	public event MonsterAction OnMonsterNotMoving;
	public event MonsterAction OnMonsterAttack;
	public event MonsterAction OnMonsterAggro;
	public event MonsterAction OnMonsterGrowlAmb;
	public event MonsterAction OnMonsterGrowlAmbStop;
	public event MonsterAction OnMonsterStun;
	public event MonsterAction OnMonsterDeath;
	public void monsterMove(GameObject monster) {
		OnMonsterMove (monster);
	}
	public void monsterNotMoving(GameObject monster) {
        OnMonsterNotMoving (monster);
	}
	public void MonsterAttacks(GameObject monster) {
		OnMonsterAttack (monster);
	}
	public void MonsterAggros(GameObject monster) {
		OnMonsterAggro (monster);
	}
	public void MonsterGrowlAmb(GameObject monster) {
		OnMonsterGrowlAmb (monster);
	}
	public void MonsterGrowlAmbStop(GameObject monster) {
		OnMonsterGrowlAmbStop (monster);
	}
	public void MonsterStun(GameObject monster) {
        if (OnMonsterStun != null)
        {
            OnMonsterStun(monster);
        }
	}
	public void MonsterDies(GameObject monster) {
		OnMonsterDeath (monster);
	}

	//**** environment ****
	public delegate void EnvironmentAction();
	public event EnvironmentAction OnAmbience;
	public event EnvironmentAction OnAmbienceStop;
	public event EnvironmentAction OnCollision;
	public event EnvironmentAction OnLightFlower;
	public event EnvironmentAction OnCaveObject;
	public void ambience() {
		OnAmbience ();
	}
	public void ambienceStop() {
		OnAmbienceStop ();
	}
	public void collideOnEnvironment() {
		OnCollision ();
	}
	public void lightFlower() {
		OnLightFlower ();
	}
	public void caveObjectHit() {
		OnCaveObject ();
	}

	//**** menu ****
	public delegate void MenuAction(string element);
	public event MenuAction OnMenuButton;
	public event MenuAction OnmenuStates;
	public void buttonPressed(string element) {
		OnMenuButton (element);
	}
	public void menuStateChanged(string element) {
		OnmenuStates (element);
	}

    //**** charging ****
    public delegate void ChargeAction(Collider col);
    public event ChargeAction OnChargeOnStun;

    public void ChargeOnStun(Collider col)
    {
        if(OnChargeOnStun != null)
        {
            OnChargeOnStun(col);
        }
    }
}
