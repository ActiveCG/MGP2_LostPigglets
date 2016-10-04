using UnityEngine;
using System.Collections;

public class HandMove : MonoBehaviour
{

    GameObject MoveHand;

    void Start()
    {
        MoveHand = gameObject.transform.GetChild(0).transform.gameObject;

        MoveHand.SetActive(true);
    }

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            MoveHand.SetActive(false);
        }
    }
}
