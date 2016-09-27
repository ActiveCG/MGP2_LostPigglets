using UnityEngine;
using System.Collections;

public class MoveEnemies : MonoBehaviour {

    private NavMeshAgent nav;
    public Transform target;

    void Update () {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(target.position); //move towards target
    }
}
