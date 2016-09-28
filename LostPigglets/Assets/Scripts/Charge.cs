using UnityEngine;
using System.Collections;

public class Charge : MonoBehaviour {

    public static Charge instance;

    int countTouch = 0;
    float timer = 0;
    bool startCount = false;
    public bool pleaseCharge = false;
    public float chargeSpeed;
    [HideInInspector]
    public float initialSpeed;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
       initialSpeed = PigMovement.current.nav.speed;
    }

    void Update()
    {
        if(startCount)
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
        if(countTouch == 2 && timer < 1f)
        {

            //PigMovement.current.nav.Stop();
            PigMovement.current.nav.enabled = false;
            Debug.Log("I am in");
            pleaseCharge = true;
            countTouch = 0;
            startCount = false;
            timer = 0;
            //PigMovement.current.nav.speed = chargeSpeed;
            
            PigMovement.current.pigRB.AddForce(transform.forward * chargeSpeed);
        }

        if(countTouch > 2)
        {
            countTouch = 0;
            startCount = false;
            timer = 0;
            //pleaseCharge = false;
            //PigMovement.current.nav.speed = initialSpeed;
        }
    }
}
