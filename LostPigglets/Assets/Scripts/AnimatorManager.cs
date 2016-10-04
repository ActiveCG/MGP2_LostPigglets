using UnityEngine;
using System.Collections;

public class AnimatorManager : MonoBehaviour
{

    //script variables
    private bool isMonsterSearching = false;
    private bool isPlayerSwimming = false;
    private bool canJump = true;
    private Animator playerAnim, pigletAnim, cameraAnim, monsterAnim, panelTopAnim, panelBtnAnim, pigRippleAnim;

    //*********** Player ****************
    void AM_PlayerSwim(Vector3 position)
    {
        if (isPlayerSwimming == true)
            return;
        playerAnim.SetBool("isPigSwimming", true);
		Debug.Log (pigRippleAnim + " RIPPLESa");
		pigRippleAnim.SetBool("swim", true);
		//pigRippleAnim.SetTrigger("swimTrig");
		Debug.Log (pigRippleAnim.GetBool("swim") + " RIPPLES");
        isPlayerSwimming = true;
    }
    void AM_PlayerSwimStop(Vector3 position)
    {
        if (isPlayerSwimming == false)
            return;
        playerAnim.SetBool("isPigSwimming", false);
		pigRippleAnim.SetBool("swim", false);
		Debug.Log (pigRippleAnim.GetBool("swim") + " RIPPLES");
        isPlayerSwimming = false;
    }
    void AM_Charge()
    {
        playerAnim.SetTrigger("pigAttackTrig");
    }
    public void AM_ResetCharge()
    {
        playerAnim.ResetTrigger("pigAttackTrig");
    }
	void AM_PickUpSequence(GameObject Piglet){
		Transform pigletMark = Piglet.transform.FindChild ("PigletMark");
		Debug.Log ("pigletMark" + pigletMark);
		pigletMark.parent = null;
		pigletAnim = Piglet.GetComponentInChildren<Animator> ();

		// find pigmark
		Transform pigMark = pigletMark.FindChild ("PigMark");

		panelTopAnim.enabled = true;
		panelBtnAnim.enabled = true;

		cameraAnim.gameObject.transform.parent = pigletMark;
		cameraAnim.enabled = true;

		Piglet.transform.position = pigletMark.position;
		Piglet.transform.rotation = pigletMark.rotation;

		Rigidbody pigRB = GameManager.instance.player.GetComponent<Rigidbody> ();
		pigRB.velocity = Vector3.zero;
		pigRB.angularVelocity = Vector3.zero;

		GameManager.instance.player.transform.position = pigMark.position;
		GameManager.instance.player.transform.rotation = pigMark.rotation;

		playerAnim.SetTrigger ("pickupPiglet");
		pigletAnim.SetBool("pickupPigletCut", true);
	}

	void AM_PickUpSequenceEnd(GameObject Piglet){

		pigletAnim = Piglet.GetComponentInChildren<Animator> ();
		pigletAnim.SetBool("pickupPigletCut", false);
	}

	public void AM_PickUpCameraReset(){
		cameraAnim.enabled = false;
		panelTopAnim.enabled = false;
		panelBtnAnim.enabled = false;
		StartCoroutine (UnparentCam());

	}
	IEnumerator UnparentCam (){
		yield return null;
		cameraAnim.gameObject.transform.parent = null;
	}


    //*********** Monster ****************
    void AM_Slink(GameObject monster)
    {
        monster.GetComponentInChildren<Animator>().SetTrigger("isSlinking");
    }

    void AM_Search(GameObject monster)
    {
        monster.GetComponentInChildren<Animator>().SetBool("isSearching", true);
    }

    void AM_Attack(GameObject monster)
    {
        monster.GetComponentInChildren<Animator>().SetTrigger("disappear");
        monster.GetComponentInChildren<Animator>().SetTrigger("isAttacking");
    }

    void AM_OutRange(GameObject monster)
    {
        monster.GetComponentInChildren<Animator>().SetBool("isSearching", false);
    }

    void AM_Stun(GameObject monster)
    {
        monster.GetComponentInChildren<Animator>().SetTrigger("isStunned");
        monster.GetComponentInChildren<Animator>().SetBool("beingStunned", true);
    }

    void AM_Recoil(GameObject monster)
    {
        monster.GetComponentInChildren<Animator>().SetBool("beingStunned", false);
    }

    void AM_Death(GameObject monster)
    {
        monster.GetComponentInChildren<Animator>().SetTrigger("isDying");
        //MonsterDestroying.current.Destroy(monster);
    }

    void OnEnable()
    {
        isPlayerSwimming = false;
        playerAnim = GameManager.instance.player.GetComponentInChildren<Animator>() as Animator;
		cameraAnim = Camera.main.gameObject.GetComponent<Animator> ();
		panelTopAnim = GameObject.FindGameObjectWithTag("panelTop").GetComponent<Animator>();
		panelBtnAnim = GameObject.FindGameObjectWithTag("panelBtn").GetComponent<Animator>();

		//ripples
		//pigRippleAnim = GameManager.instance.player.GetComponentInChildren<Animator>();
		GameObject ripple = GameObject.Find("RipplesSamantha");
		pigRippleAnim = ripple.GetComponent<Animator> ();
		//pigRippleAnim.SetBool ("swim", true);

        //player events
        GameManager.instance.OnPlayerMove += AM_PlayerSwim;
        GameManager.instance.OnPlayerNotMoving += AM_PlayerSwimStop;
        GameManager.instance.OnChargeHit += AM_Charge;
	
        //monster events
        GameManager.instance.OnMonsterDeath += AM_Death;
        GameManager.instance.OnMonsterRecoil += AM_Recoil;
        GameManager.instance.OnMonsterOutOfRange += AM_OutRange;
        GameManager.instance.OnMonsterJump += AM_Slink;
        GameManager.instance.OnMonsterAttack += AM_Attack;
        GameManager.instance.OnMonsterAggro += AM_Search;
        GameManager.instance.OnMonsterStun += AM_Stun;

		// key cinematic moments
		GameManager.instance.OnPickUp += AM_PickUpSequence;
		GameManager.instance.OnPickUpEnd += AM_PickUpSequenceEnd;

    }
    void OnDisable()
    {
        //player events
        GameManager.instance.OnPlayerMove -= AM_PlayerSwim;
        GameManager.instance.OnPlayerNotMoving -= AM_PlayerSwimStop;
        GameManager.instance.OnChargeHit -= AM_Charge;
       
		//monster events
        GameManager.instance.OnMonsterDeath -= AM_Death;
        GameManager.instance.OnMonsterRecoil -= AM_Recoil;
        GameManager.instance.OnMonsterOutOfRange -= AM_OutRange;
        GameManager.instance.OnMonsterJump -= AM_Slink;
        GameManager.instance.OnMonsterAttack -= AM_Attack;
        GameManager.instance.OnMonsterAggro -= AM_Search;
        GameManager.instance.OnMonsterStun -= AM_Stun;

		// key cinematic moments
		GameManager.instance.OnPickUp -= AM_PickUpSequence;
		GameManager.instance.OnPickUpEnd -= AM_PickUpSequenceEnd;
    }
}
