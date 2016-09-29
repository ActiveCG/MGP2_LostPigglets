using UnityEngine;
using System.Collections;

public class AnimatorManager : MonoBehaviour {

	//script variables
	private bool isPlayerSwimming = false;

	//*********** Player ****************
	void AM_PlayerSwim(Vector3 position){
		if (isPlayerSwimming == true)
			return;
		PlaySound (playerSwimStart, GameManager.instance.player);
		isPlayerSwimming = true;
	}
}
