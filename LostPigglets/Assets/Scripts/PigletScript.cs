using UnityEngine;
using System.Collections;

public class PigletScript : MonoBehaviour {

   // [HideInInspector]
    public int id;
    [HideInInspector]
    public bool amIPickedUp;

    void Awake() {
        amIPickedUp = false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Check if it's has been picked up
	void Update () {

        if (amIPickedUp) {
            PigletManager.current.SetMeFalse(id);
        }
	}
}
