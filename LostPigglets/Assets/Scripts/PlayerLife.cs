using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;

    public int deathTime;
    public bool died = false;

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

    void Awake()
    {
        instance = this;
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
        PlayerStats.instance.playerSpeed = 0;
        PlayerStats.instance.acceleration = 0;
        died = true;
        yield return new WaitForSeconds(deathTime);
        GameManager.instance.GameOver();
    }
}
