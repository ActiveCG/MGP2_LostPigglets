using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {

    public static Charge instance;

    int countTouch = 0;
    float timer = 0;
    bool startCount = false;
    public float chargeSpeed;
    public float doubleTapTime = 1f;

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
        if (countTouch == 2 && timer < doubleTapTime)
        {

            //PigMovement.current.nav.Stop();
            PigMovement.current.nav.enabled = false;
            /////////PLAY ANIMATION HERE////////////
            //Debug.Log("CHARGE!!!!!!");
            countTouch = 0;
            startCount = false;
            timer = 0;

            PigMovement.current.pigRB.AddForce(transform.forward * chargeSpeed);
            //ChargedOnMonster.instance.ChargeHit();
        }

        if (countTouch > 2 || timer > doubleTapTime)
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
