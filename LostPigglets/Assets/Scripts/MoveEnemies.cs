using UnityEngine;
using System.Collections;

public class MoveEnemies : MonoBehaviour {

    private NavMeshAgent nav;

    [HideInInspector]
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update () {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(target.position); //move towards target
    }
}
