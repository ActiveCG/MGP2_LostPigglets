using UnityEngine;
using System.Collections;

public class AnimatorManager : MonoBehaviour {

	//script variables
	private bool isPlayerSwimming = false;
	private Animator playerAnim, cameraAnim;

	//*********** Player ****************
	void AM_PlayerSwim(Vector3 position){
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
	public void AM_PickUpSequence(GameObject Piglet){
		cameraAnim.SetTrigger ("pickupSequence");
	}
	void OnEnable () {
		isPlayerSwimming = false;
		playerAnim = GameManager.instance.player.GetComponentInChildren<Animator> () as Animator;
		cameraAnim = Camera.main.gameObject.GetComponent<Animator>();
		//player events
		GameManager.instance.OnPlayerMove += AM_PlayerSwim;
		GameManager.instance.OnPlayerNotMoving += AM_PlayerSwimStop;
		GameManager.instance.OnChargeHit += AM_Charge;

		//key cinematic moments
		GameManager.instance.OnPickUp += AM_PickUpSequence;
	}
	void OnDisable () {
		//player events
		GameManager.instance.OnPlayerMove -= AM_PlayerSwim;
		GameManager.instance.OnPlayerNotMoving -= AM_PlayerSwimStop;
		GameManager.instance.OnChargeHit -= AM_Charge;

		//key cinematic moments
		GameManager.instance.OnPickUp -= AM_PickUpSequence;
	}
}
