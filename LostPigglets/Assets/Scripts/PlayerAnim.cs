using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

public void AM_ResetChargeEvent()
    {
        GameManager.instance.animManager.AM_ResetCharge();
    }
}
