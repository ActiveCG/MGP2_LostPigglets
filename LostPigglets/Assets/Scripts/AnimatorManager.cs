using UnityEngine;
using System.Collections;

public class AnimatorManager : MonoBehaviour {

	//script variables
	private bool isPlayerSwimming = false;
	private Animator playerAnim;

	//*********** Player ****************
	void AM_PlayerSwim(Vector3 position){
        Debug.Log("I am in");
		if (isPlayerSwimming == true)
			return;
		playerAnim.SetBool ("isPigSwimming", true);
		isPlayerSwimming = true;
	}
	void AM_PlayerSwimStop(Vector3 position){
		if (isPlayerSwimming == false)
			return;
		playerAnim.SetBool ("isPigSwimming", false);
		isPlayerSwimming = false;
	}

	void AM_Charge(){
		playerAnim.SetTrigger ("pigAttackTrig");
	}
	public void AM_ResetCharge(){
		playerAnim.ResetTrigger ("pigAttackTrig");
	}
	void OnEnable () {
		isPlayerSwimming = false;
		playerAnim = GameManager.instance.player.GetComponentInChildren<Animator> () as Animator;
		//player events
		GameManager.instance.OnPlayerMove += AM_PlayerSwim;
		GameManager.instance.OnPlayerNotMoving += AM_PlayerSwimStop;
		GameManager.instance.OnChargeHit += AM_Charge;
	}
	void OnDisable () {
		//player events
		GameManager.instance.OnPlayerMove -= AM_PlayerSwim;
		GameManager.instance.OnPlayerNotMoving -= AM_PlayerSwimStop;
		GameManager.instance.OnChargeHit -= AM_Charge;
	}
}
