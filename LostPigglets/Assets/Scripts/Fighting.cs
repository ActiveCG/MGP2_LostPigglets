using UnityEngine;
using System.Collections;

public class Fighting : MonoBehaviour {

    public float collisionRadius;
    float angle;

    Light spotlight;

    Vector3 direction;

    void Start()
    {
        spotlight = GetComponentInChildren<Light>();
    }
	
	void Update () {

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, collisionRadius, 1 << LayerMask.NameToLayer("Enemy"));
        int i = 0;
        while (i < hitColliders.Length)
        {
            direction = (hitColliders[i].gameObject.transform.position - transform.position).normalized;
            angle = Vector3.Angle(transform.forward, direction);
            //Debug.Log(angle);
            if (angle < spotlight.spotAngle)
            {
                MonsterDestroying.current.Destroy(hitColliders[i].gameObject);
            }
            i++;
        }
    }
}
