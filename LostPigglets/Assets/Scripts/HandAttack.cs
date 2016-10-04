using UnityEngine;
using System.Collections;

public class HandAttack : MonoBehaviour {

    GameObject AttackHand;

    void Start()
    {
        AttackHand = gameObject.transform.GetChild(0).transform.gameObject;
    }

    void Update()
    {
        if (Intro.instance.letPlayerCharge == true)
        {
            AttackHand.SetActive(true);
        }
        if (MonsterDestroying.current.stopHandAnim == true)
        {
            AttackHand.SetActive(false);
        }
    }
}
