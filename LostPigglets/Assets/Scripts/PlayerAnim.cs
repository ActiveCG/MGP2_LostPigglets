using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

public void AM_ResetChargeEvent()
    {
        GameManager.instance.animManager.AM_ResetCharge();
    }

	public void PlayerSwimEvent()
	{
		GameManager.instance.swimPull (Vector3.zero);
	}
	public void PlayerChargeEvent()
	{
		GameManager.instance.chargeHit ();
	}
}
