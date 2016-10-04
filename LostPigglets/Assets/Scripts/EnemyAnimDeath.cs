using UnityEngine;
using System.Collections;

public class EnemyAnimDeath : MonoBehaviour
{

    public void DeathAnim()
    {
        MonsterDestroying.current.Destroy(transform.parent.gameObject);
    }
}