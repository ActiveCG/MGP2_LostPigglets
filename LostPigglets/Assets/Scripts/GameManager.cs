using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager {

	private static string START_SCENE = "IntroScene";
	private static string GAME_SCENE = "Development";
    private static string MENU_SCENE = "MainMenu";

	private static GameManager _instance;

    private GameObject _monster;
	private GameObject _player;
	private AudioManager _audioManager;
    private AnimatorManager _animManager;

	public bool cinematicCut = false;
    public bool isPaused = false;

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

    public AnimatorManager animManager
    {
        get
        {
            if (_animManager == null)
                _animManager = Object.FindObjectOfType(typeof(AnimatorManager)) as AnimatorManager;
            return _animManager;
        }
    }

    //scene management:
    public void PauseGame() {
		//to be filled later
        if(isPaused) {
            Time.timeScale = 0;
        }
        if (!isPaused) {
            Time.timeScale = 1;
        }
	}

	public void StartGame() {
		_instance = null;
		menuStateChanged("In_Game");
		SceneManager.LoadScene (GAME_SCENE);
		cinematicCut = false;
	}

	public void RestartGame() {
		_instance = null;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		menuStateChanged("In_Game");
        Time.timeScale = 1;
		cinematicCut = false;
}
    public void LoadMainMenu() {
        _instance = null;
        SceneManager.LoadScene(MENU_SCENE);
    }

	public void Win(){
		menuStateChanged("In_Menu");
		SceneManager.LoadScene ("Win");

	}

	public void GameOver(){
		menuStateChanged("In_Menu");
		SceneManager.LoadScene ("GameOver");
	}

	public void QuitGame() {
		_instance = null;
		ambienceStop (audioManager.gameObject);
		Application.Quit ();
	}

	//delegates
	//**** player ****
	public delegate void MovementInput(Vector3 position);
	public event MovementInput OnPlayerMove;
	public event MovementInput OnPlayerRotate;
	public event MovementInput OnPlayerNotMoving;
	public void move(Vector3 position) {
		if(OnPlayerMove != null)
			OnPlayerMove (position);
	}
	public void rotate(Vector3 position) {
		if(OnPlayerRotate != null)
			OnPlayerRotate (position);
	}
	public void notMoving(Vector3 position) {
		if(OnPlayerNotMoving != null)
			OnPlayerNotMoving (position);
	}

	public delegate void HealthAction(int amount);
	//public event HealthAction OnPlayerDamage;
	public event HealthAction OnPlayerDeath;
	public event HealthAction OnPlayerSpawn;
	/*public void playerDamaged(int damageAmount) {
		if(OnPlayerDamage != null)
			OnPlayerDamage (damageAmount);
	}*/
	public void playerDies(int healthAmount) {
		if(OnPlayerDeath != null)
			OnPlayerDeath (healthAmount);
	}
	public void playerSpawn(int healthAmount) {
		if(OnPlayerSpawn != null)
			OnPlayerSpawn (healthAmount);
	}

	public delegate void PickUpAction(GameObject pickedObj);
	public event PickUpAction OnPickUp;
	public event PickUpAction OnPickUpEnd;
	public void pickUpPigglet(GameObject pickedObj) {
		cinematicCut = true;
		Debug.Log ("cinematicCut " + cinematicCut);
		if(OnPickUp != null)
			OnPickUp (pickedObj);
	}
	public void pickUpPiggletEnd(GameObject pickedObj) {
		cinematicCut = false;
		Debug.Log ("cinematicCut " + cinematicCut);
		if(OnPickUpEnd != null)
			OnPickUpEnd (pickedObj);
	}

	public delegate void FightingAction();
	public event FightingAction OnLight;
	public event FightingAction OnChargeHit;
	public void light() {
		if(OnLight != null)
			OnLight ();
	}
	public void chargeHit() {
		if(OnChargeHit != null)
			OnChargeHit ();
	}

	//**** pigglet****
	public delegate void PigletAction(GameObject piglet);
	public event PigletAction OnPigletOink;
	public void oink(GameObject piglet) {
		if(OnPigletOink != null)
			OnPigletOink (piglet);
	}

	//**** monsters ****
	public delegate void MonsterAction(GameObject monster);
	public event MonsterAction OnMonsterMove;
	public event MonsterAction OnMonsterNotMoving;
    public event MonsterAction OnMonsterOutOfRange;
    public event MonsterAction OnMonsterJump;
    public event MonsterAction OnMonsterAttack;
	public event MonsterAction OnMonsterAggro;
	public event MonsterAction OnMonsterGrowlAmb;
	public event MonsterAction OnMonsterGrowlAmbStop;
	public event MonsterAction OnMonsterStun;
    public event MonsterAction OnMonsterRecoil;
	public event MonsterAction OnMonsterDeath;
	public void monsterMove(GameObject monster) {
		if(OnMonsterMove != null)
			OnMonsterMove (monster);
	}
	public void monsterNotMoving(GameObject monster) {
		if(OnMonsterNotMoving != null)
			OnMonsterNotMoving (monster);
	}
    public void MonsterRecoil(GameObject monster)
    {
        if (OnMonsterRecoil != null)
            OnMonsterRecoil(monster);
    }
    public void MonsterOutRange(GameObject monster)
    {
        if (OnMonsterOutOfRange != null)
            OnMonsterOutOfRange(monster);
    }
    public void MonsterJump(GameObject monster) {
        if (OnMonsterJump != null)
            OnMonsterJump(monster);
    }
	public void MonsterAttacks(GameObject monster) {
		if(OnMonsterAttack != null)
			OnMonsterAttack (monster);
	}
	public void MonsterAggro(GameObject monster) {
		if(OnMonsterAggro != null)
			OnMonsterAggro (monster);
	}
	public void MonsterGrowlAmb(GameObject monster) {
		if(OnMonsterGrowlAmb != null)
			OnMonsterGrowlAmb (monster);
	}
	public void MonsterGrowlAmbStop(GameObject monster) {
		if(OnMonsterGrowlAmbStop != null)
			OnMonsterGrowlAmbStop (monster);
	}
	public void MonsterStun(GameObject monster) {
		if(OnMonsterStun != null)
        {
			OnMonsterStun (monster);
        }
	}
	public void MonsterDies(GameObject monster) {
		if(OnMonsterDeath != null)
			OnMonsterDeath (monster);
	}

	//**** environment ****
	public delegate void EnvironmentAction(GameObject obj);
	public event EnvironmentAction OnAmbience;
	public event EnvironmentAction OnAmbienceStop;
	public event EnvironmentAction OnCollision;
	public event EnvironmentAction OnLightFlower;
	public event EnvironmentAction OnCaveObject;
	public void ambience(GameObject obj) {
		if(OnAmbience != null)
			OnAmbience (obj);
	}
	public void ambienceStop(GameObject obj) {
		if(OnAmbienceStop != null)
			OnAmbienceStop (obj);
	}
	public void collideOnEnvironment(GameObject obj) {
		if(OnCollision != null)
			OnCollision (obj);
	}
	public void lightFlower(GameObject obj) {
		if(OnLightFlower != null)
			OnLightFlower (obj);
	}
	public void caveObjectHit(GameObject obj) {
		if(OnCaveObject != null)
			OnCaveObject (obj);
	}

	//**** menu ****
	public delegate void MenuAction(string element);
	public event MenuAction OnMenuButton;
	public event MenuAction OnmenuStates;
	public void buttonPressed(string element) {
		if(OnMenuButton != null)
			OnMenuButton (element);
	}
	public void menuStateChanged(string state) {
		if(OnmenuStates != null)
			OnmenuStates (state);
	}

    //**** charging ****
    //public delegate void ChargeAction(Collider col);
    //public event ChargeAction OnChargeOnStun;

    //public void ChargeOnStun(Collider col)
    //{
    //    if(OnChargeOnStun != null)
    //    {
    //        OnChargeOnStun(col);
    //    }
    //}
}
