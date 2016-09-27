using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterStats : MonoBehaviour {

    public static MonsterStats current;

    public List<Transform> spawnPlaces;

    public int pooledAmount;

    void Start()
    {
        current = this;
    }

}
