using UnityEngine;
using System.Collections;

public class Fighting : MonoBehaviour
{

    public float collisionRadius;
    float angle;

    public static Light spotlight;
    Vector3 direction;
    public float lightTimer = 1f;
    public float cdTimer = 8f;
    bool stunCD;

    void Start()
    {
        stunCD = true;
        spotlight = GetComponentInChildren<Light>();
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, collisionRadius, 1 << LayerMask.NameToLayer("Enemy"));
        Fight(hitColliders);
    }

    void Fight(Collider[] col)
    {
        for (int i = 0; i < col.Length; i++)
        {
            //Charge.instance.Charging();
            direction = (col[i].gameObject.transform.position - transform.position).normalized;
            angle = Vector3.Angle(transform.forward, direction);
            //Debug.Log(angle);
            if (angle < spotlight.spotAngle / 2f)
            {
                // MonsterDestroying.current.Destroy(col[i].gameObject);
                MonsterStun.current.Stun(col[i].gameObject);
            }
        }
    }
}
