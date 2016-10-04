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
    }
}
