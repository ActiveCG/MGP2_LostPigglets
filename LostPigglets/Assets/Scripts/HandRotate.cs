using UnityEngine;
using System.Collections;

public class HandRotate : MonoBehaviour {

    GameObject RotationHand;

    void Start()
    {
        RotationHand = gameObject.transform.GetChild(0).transform.gameObject;
    }

	void Update ()
    {
	    if(Intro.instance.playHand == true)
        {
            RotationHand.SetActive(true);
        }
        if(Intro.instance.stopPlayerRotate == true)
        {
            RotationHand.SetActive(false);
        }
	}
}
