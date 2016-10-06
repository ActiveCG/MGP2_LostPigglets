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
	public void EmergeEvent()
	{
		GameManager.instance.MonsterEmerge (transform.parent.gameObject);
	}
	public void TapWaterEvent()
	{
		GameManager.instance.MonsterWaterTap (transform.parent.gameObject);
	}
	public void SearchingEvent()
	{
		GameManager.instance.MonsterSearching (transform.parent.gameObject);
	}
	public void StunnedEvent()
	{
		GameManager.instance.MonsterStunned (transform.parent.gameObject);
	}
	public void StunSoundEvent()
	{
		GameManager.instance.MonsterStunSound (transform.parent.gameObject);
	}
	public void SlinkyEvent()
	{
		GameManager.instance.MonsterSlinky (transform.parent.gameObject);
	}
}