using UnityEngine;
using System.Collections;

public class EnemyAnimDeath : MonoBehaviour
{

    public void DeathAnim()
    {
        MonsterDestroying.current.Destroy(transform.parent.gameObject);
    }
	public void SubmergeEvent()
	{
		GameManager.instance.MonsterSubmerge (transform.parent.gameObject);
	}
	public void TapWaterEvent()
	{
		GameManager.instance.MonsterWaterTap (transform.parent.gameObject);
	}
}