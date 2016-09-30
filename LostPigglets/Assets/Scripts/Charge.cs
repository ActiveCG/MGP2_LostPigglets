using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {

    public static Charge instance;

    private int countTouch = 0;
    private float timer = 0;
    private bool startCount = false;
    

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
    }


    public void Charging()
    {

        countTouch++;
        startCount = true;
        if (countTouch == 2 && timer < PlayerStats.instance.doubleTapTime)
        {

            //PigMovement.current.nav.Stop();
            PigMovement.current.nav.enabled = false;
			GameManager.instance.chargeHit ();  // player charging
            //Debug.Log("CHARGE!!!!!!");
            countTouch = 0;
            startCount = false;
            timer = 0;

            PigMovement.current.pigRB.AddForce(transform.forward * PlayerStats.instance.chargeSpeed);
            //ChargedOnMonster.instance.ChargeHit();
        }

        if (countTouch > 2 || timer > PlayerStats.instance.doubleTapTime)
        {
            countTouch = 0;
            startCount = false;
            timer = 0;
        }
    }

    public void ChargeHit()
    {
        GameManager.instance.ChargeOnStun(GetComponent<Collider>());
    }
}
