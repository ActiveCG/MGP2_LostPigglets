using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {

    public static Charge instance;

    private int countTouch = 0;
    private float timer = 0;
    private float chargingTimer = 0;
    private bool startCount = false;
    private bool notCharged = true;
    private bool charged = false;
    

    void Awake()
    {
        instance = this;
    }


    void Update()
    {
        if (startCount)
        {
            timer += Time.deltaTime;
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Charging();
            }
        }

        chargingTimer += Time.deltaTime;

        //if(PigMovement.current.pigRB.velocity.magnitude < 1f)
        //{
        //    //charged = false;
        //}
        print(charged);
        //print(PigMovement.current.pigRB.velocity.magnitude);
    }


    public void Charging()
    {

        countTouch++;
        startCount = true;
        if (countTouch == 2 && timer < PlayerStats.instance.doubleTapTime)
        {
            if (chargingTimer > PlayerStats.instance.chargeCooldown || notCharged)
            {
                //PigMovement.current.nav.Stop();
                PigMovement.current.nav.enabled = false;
                charged = true;
                StartCoroutine("SetChargeFalse");
                //ChargeHit();
                //Debug.Log("CHARGE!!!!!!");
                notCharged = false;
                chargingTimer = 0;
                countTouch = 0;
                startCount = false;
                timer = 0;

                PigMovement.current.pigRB.AddForce(transform.forward * PlayerStats.instance.chargeSpeed);
                //ChargedOnMonster.instance.ChargeHit();
            }
        }

        if (countTouch > 2 || timer > PlayerStats.instance.doubleTapTime)
        {
            countTouch = 0;
            startCount = false;
            timer = 0;

        }
    }

    //public void ChargeHit()
    //{
    //    GameManager.instance.ChargeOnStun(GetComponent<Collider>());
    //}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy" && MonsterStun.current.monsterStunned && charged)
        {
            Debug.Log("Hit the enemy");
            ///////PLAY ANIMATION/////////
            StartCoroutine(MonsterPushedBack(MonsterStats.instance.destroyTimeAfterHit, col));
        }
    }

    IEnumerator MonsterPushedBack(float time, Collider enemyCol)
    {
        yield return new WaitForSeconds(time);
        MonsterDestroying.current.Destroy(enemyCol.gameObject);
    }

    IEnumerator SetChargeFalse()
    {
        yield return new WaitForSeconds(PlayerStats.instance.setChargeFalse);
        charged = false;
    }
}
