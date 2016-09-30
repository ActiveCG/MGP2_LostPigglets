using UnityEngine;
using System.Collections;

public class LightUpObjects : MonoBehaviour {

    private float angle;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
        PlayerStats.instance.spotlight = GetComponentInChildren<Light>();
    }
	
	// Update is called once per frame
	void Update () {
        Collider[] landMarkColliders = Physics.OverlapSphere(transform.position, PlayerStats.instance.collisionRadius, 1 << LayerMask.NameToLayer("Landmark"));
        LightUpObject(landMarkColliders);
    }

    void LightUpObject(Collider[] col) {

        for (int i = 0; i < col.Length; i++) {
            direction = (col[i].gameObject.transform.position - transform.position).normalized;
            angle = Vector3.Angle(transform.forward, direction);
            if (angle < PlayerStats.instance.spotlight.spotAngle / 2f) {
                col[i].gameObject.GetComponent<PigSkull>().ActivateLight();
            }
        }
    }
}
