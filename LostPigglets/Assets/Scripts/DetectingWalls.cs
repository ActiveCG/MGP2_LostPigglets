using UnityEngine;
using System.Collections;

public class DetectingWalls : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
            print("Impact");
        if (col.gameObject.tag == "Walls" && (TouchInput.instance.hitInfo.collider.tag == "Terain"))
        {
            if (PigMovement.current.nav.enabled)
            {
                PigMovement.current.nav.SetDestination(transform.position);
            }
        }
    }
}
