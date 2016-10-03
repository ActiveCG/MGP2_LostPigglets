using UnityEngine;
using System.Collections;

public class BecomeVisible : MonoBehaviour {

    void OnBecameVisible()
    {
        MonsterStats.instance.spawnPlaces.Remove(transform);
        print(gameObject.name);
    }

    void OnBecameInvisible()
    {
        MonsterStats.instance.spawnPlaces.Add(transform);
    }
}
