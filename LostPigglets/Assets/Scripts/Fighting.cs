using UnityEngine;
using System.Collections;

public class Fighting : MonoBehaviour
{

    private float angle;
    private Vector3 direction;


    void Start()
    {
        PlayerStats.instance.spotlight = GameObject.FindGameObjectWithTag("Spotlight").GetComponent<Light>();
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
                print("Stunned");
                // MonsterDestroying.current.Destroy(col[i].gameObject);
                if (!Intro.instance.makeMonsterJump)
                {
                    MonsterStun.current.Stun(col[i].gameObject);
                }
                if (Intro.instance.stopPlayerMove)
                {
                    Intro.instance.letPlayerCharge = true;
                    Intro.instance.stopPlayerRotate = true;
                }
            }
        }
    }
}
