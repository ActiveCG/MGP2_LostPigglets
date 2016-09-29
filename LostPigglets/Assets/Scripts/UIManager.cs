using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public void restartGame(){
		GameManager.instance.RestartGame ();
	}
}
