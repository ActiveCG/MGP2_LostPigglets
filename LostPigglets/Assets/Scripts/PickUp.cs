using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {
	
	private bool isColliding;
	private int timer;

	void OnEnable(){
		GameManager.instance.OnPickUpEnd += PickUpPigglet;
	}
	void OnDisable(){
		GameManager.instance.OnPickUpEnd -= PickUpPigglet;
	}


	//when player picks up something
	void OnTriggerEnter(Collider other){
		//picking up pigglets
		if (isColliding == false) {
			isColliding = true;
			timer = 0;

			if (other.gameObject.tag == "Pigglet") {
				Debug.Log ("Collided");
				other.gameObject.GetComponent<Collider> ().enabled = false;
				GameManager.instance.pickUpPigglet (other.gameObject);
				//PickUpPigglet (other.gameObject);

				//check whther all pigglets collected

			}
		}
	}

	private void PickUpPigglet(GameObject pigglet) {
        PlayerStats.piggletsCollected++;
		Debug.Log ("win not yet" + PlayerStats.piggletsCollected);

		//make pigglets follow pig
		Transform pickups = transform.FindChild("PickUps");
		Transform place = pickups.GetChild (PlayerStats.piggletsCollected - 1);
		pigglet.transform.rotation = place.rotation;
		pigglet.transform.position = place.position;
		pigglet.transform.parent = pickups;

        pigglet.GetComponent<PigletScript>().amIPickedUp = true;
        PickupPigletTexture.instance.SetText();

		if (PlayerStats.piggletsCollected == PlayerStats.instance.piggletsInGame) {
			GameManager.instance.Win ();
		}
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
