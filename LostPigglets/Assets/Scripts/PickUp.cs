using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	
	private bool isColliding;
	private int timer;

	//when player picks up something
	void OnTriggerEnter(Collider other){
		//picking up pigglets
		if (isColliding == false) {
			isColliding = true;
			timer = 0;

			if (other.gameObject.tag == "Pigglet") {
				Debug.Log ("Collided");
				GameManager.instance.pickUpPigglet (other.gameObject);
				PickUpPigglet (other.gameObject);

				//check whther all pigglets collected
				if (PlayerStats.piggletsCollected == PlayerStats.instance.piggletsInGame) {
					GameManager.instance.Win ();
				}
			}
		}
	}

	private void PickUpPigglet(GameObject pigglet) {
        PlayerStats.piggletsCollected++;
		Debug.Log ("win not yet" + PlayerStats.piggletsCollected);
		//make pigglets follow pig
		pigglet.transform.rotation = transform.rotation;
		pigglet.transform.position = transform.position + new Vector3 (0f, 0f, PlayerStats.instance.pigletsFollowPosZ * PlayerStats.piggletsCollected);
		pigglet.transform.parent = transform;
        pigglet.GetComponent<PigletScript>().amIPickedUp = true;
	}

	void Update (){
		if (isColliding == true) {
			timer++;
			if (timer > 200) {
				isColliding = false;
			}
		}
		isColliding = false;
		
	}
		
}
