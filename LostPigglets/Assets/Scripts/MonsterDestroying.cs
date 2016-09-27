using UnityEngine;
using System.Collections;

public class MonsterDestroying : MonoBehaviour {


    //Only for testing purposes the enemies are going to be destroyed after 2 seconds
	void OnEnable()
    {
        Invoke("Destroy", 2f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
