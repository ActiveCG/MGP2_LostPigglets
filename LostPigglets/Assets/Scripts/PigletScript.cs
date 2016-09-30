using UnityEngine;
using System.Collections;

public class PigletScript : MonoBehaviour {

    [HideInInspector]
    public int id;
    [HideInInspector]
    public bool amIPickedUp;

    void Awake() {
        amIPickedUp = false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (amIPickedUp) {
            PigletManager.current.SetMeFalse(id);
        }
	}
}
