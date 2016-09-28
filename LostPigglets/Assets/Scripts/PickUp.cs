using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	public static int piggletsCollected = 0;

	//when player picks up something
	void OnTriggerEnter(Collider other){
		//picking up pigglets
		if (other.gameObject.tag == "Pigglet") {
			Debug.Log ("pigglet");
			piggletsCollected++;
			//make pigglets follow pig
			other.gameObject.transform.rotation = transform.rotation;
			other.gameObject.transform.position = transform.position + new Vector3 (0f, 0f, -1.5f * piggletsCollected);
			other.gameObject.transform.parent = transform;

			//check whther all pigglets collected
			if (piggletsCollected == PlayerStats.playerStatsCurrent.piggletsInGame) {
				GameManager.instance.Win ();
			}
		}
	}
}
