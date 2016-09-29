using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	public static int piggletsCollected = 0;

	//when player picks up something
	void OnTriggerEnter(Collider other){
		//picking up pigglets
		if (other.gameObject.tag == "Pigglet") {

			GameManager.instance.pickUpPigglet (other.gameObject);
			PickUpPigglet (other.gameObject);

			//check whther all pigglets collected
			if (piggletsCollected == PlayerStats.instance.piggletsInGame) {
				GameManager.instance.Win ();
			}
		}
	}

	private void PickUpPigglet(GameObject pigglet) {
		piggletsCollected++;
		//make pigglets follow pig
		pigglet.transform.rotation = transform.rotation;
		pigglet.transform.position = transform.position + new Vector3 (0f, 0f, -1.5f * piggletsCollected);
		pigglet.transform.parent = transform;
	}
}
