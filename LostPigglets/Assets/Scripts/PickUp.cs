using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	

	//when player picks up something
	void OnTriggerEnter(Collider other){
		//picking up pigglets
		if (other.gameObject.tag == "Pigglet") {

			GameManager.instance.pickUpPigglet (other.gameObject);
			PickUpPigglet (other.gameObject);

			//check whther all pigglets collected
			if (PlayerStats.instance.piggletsCollected == PlayerStats.instance.piggletsInGame) {
				GameManager.instance.Win ();
			}
		}
	}

	private void PickUpPigglet(GameObject pigglet) {
        PlayerStats.instance.piggletsCollected++;
		//make pigglets follow pig
		pigglet.transform.rotation = transform.rotation;
		pigglet.transform.position = transform.position + new Vector3 (0f, 0f, PlayerStats.instance.pigletsFollowPosZ * PlayerStats.instance.piggletsCollected);
		pigglet.transform.parent = transform;
        pigglet.GetComponent<PigletScript>().amIPickedUp = true;
        PickupPigletTexture.instance.SetText();
	}
}
