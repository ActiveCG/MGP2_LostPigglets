using UnityEngine;
using System.Collections;

public class DetectingWalls : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Walls")
        {
            if (PigMovement.current.nav.enabled)
            {
                PigMovement.current.nav.SetDestination(transform.position);
            }
        }
    }
}
