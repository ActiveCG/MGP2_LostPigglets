using UnityEngine;
using System.Collections;

public class PigletAnim : MonoBehaviour {
	public void AM_EndPickupEvent(){
		GameManager.instance.pickUpPiggletEnd (transform.parent.gameObject);
	}

}
