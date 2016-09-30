using UnityEngine;
using System.Collections;

public class AnimatorManager : MonoBehaviour
{

    //script variables
    private bool isMonsterSearching = false;
    private bool isPlayerSwimming = false;
    private bool canJump = true;
    private Animator playerAnim;
    private Animator monsterAnim;

    //*********** Player ****************
    void AM_PlayerSwim(Vector3 position)
    {
        if (isPlayerSwimming == true)
            return;
        playerAnim.SetBool("isPigSwimming", true);
        isPlayerSwimming = true;
    }
    void AM_PlayerSwimStop(Vector3 position)
    {
        if (isPlayerSwimming == false)
            return;
        playerAnim.SetBool("isPigSwimming", false);
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
        monster.GetComponentInChildren<Animator>().SetBool("isAttacking", true);
    }

    void OnEnable()
    {
        isPlayerSwimming = false;
        playerAnim = GameManager.instance.player.GetComponentInChildren<Animator>() as Animator;
        //player events
        GameManager.instance.OnPlayerMove += AM_PlayerSwim;
        GameManager.instance.OnPlayerNotMoving += AM_PlayerSwimStop;
        GameManager.instance.OnChargeHit += AM_Charge;
        //monster events
        GameManager.instance.OnMonsterJump += AM_Slink;
        GameManager.instance.OnMonsterAttack += AM_Attack;
        GameManager.instance.OnMonsterAggro += AM_Search;
    }
    void OnDisable()
    {
        //player events
        GameManager.instance.OnPlayerMove -= AM_PlayerSwim;
        GameManager.instance.OnPlayerNotMoving -= AM_PlayerSwimStop;
        GameManager.instance.OnChargeHit -= AM_Charge;
        //monster events
        GameManager.instance.OnMonsterJump -= AM_Slink;
        GameManager.instance.OnMonsterAttack -= AM_Attack;
        GameManager.instance.OnMonsterAggro -= AM_Search;
    }
}
