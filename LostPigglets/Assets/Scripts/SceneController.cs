using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	public static SceneController current;

	void Start(){
		current = this;
	}

	//to happen when player wins
	public void Win(){
		SceneManager.LoadScene ("Win");
	}

	//to happen when player dies
	public void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}
}
