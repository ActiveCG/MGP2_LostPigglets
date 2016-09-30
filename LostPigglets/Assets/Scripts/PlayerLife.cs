using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{

    void OnEnable()
    {

        GameManager.instance.OnMonsterAttack += TakeDamage;
        GameManager.instance.OnPlayerDeath += Die;

    }

    void OnDisable()
    {
        GameManager.instance.OnMonsterAttack -= TakeDamage;
        GameManager.instance.OnPlayerDeath -= Die;
    }

    //recieve damage from monsters
    void TakeDamage(GameObject monster)
    {
        GameManager.instance.playerDies(0);
    }

    //to happen when player dies
    void Die(int playerHealth)
    {
        GameManager.instance.notMoving(transform.position);
        StartCoroutine("DeathAnimation");
    }

    IEnumerator DeathAnimation()
    {
        yield return new WaitForSeconds(10);
        GameManager.instance.GameOver();
    }
}
