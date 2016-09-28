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
	public void move(Vector3 position) {
		OnPlayerMove (position);
	}
	public event MovementInput OnPlayerRotate;
	public void rotate(Vector3 position) {
		OnPlayerRotate (position);
	}

	public delegate void PlayerNotMoving();
	public event PlayerNotMoving OnPlayerNotMoving;
	public void notMoving() {
		OnPlayerNotMoving ();
	}

	//**** monsters ****
	public delegate void MonsterAttackAction(GameObject monster);
	public event MonsterAttackAction OnMonsterAttack;
	public void MonsterAttacks(GameObject monster) {
		OnMonsterAttack (monster);
	}
}
