using UnityEngine;
using System.Collections;

public class MoveEnemies : MonoBehaviour {

    private NavMeshAgent nav;
	public bool isSwimming;

    [HideInInspector]
    public Transform target;

    void Start()
    {
		target = GameManager.instance.player.transform;
		nav = GetComponent<NavMeshAgent>();
    }

    void Update () {
        nav.SetDestination(target.position); //move towards target
    }
}
