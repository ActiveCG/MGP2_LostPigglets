using UnityEngine;
using System.Collections;

public class Fighting : MonoBehaviour
{

    private float angle;
    private Vector3 direction;


    void Start()
    {
        PlayerStats.instance.spotlight = GetComponentInChildren<Light>();
    }


    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, PlayerStats.instance.collisionRadiusMonster, 1 << LayerMask.NameToLayer("Enemy"));
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
            if (angle < PlayerStats.instance.spotlight.spotAngle / 2f)
            {
                // MonsterDestroying.current.Destroy(col[i].gameObject);
                MonsterStun.current.Stun(col[i].gameObject);
            }
        }
    }
}
