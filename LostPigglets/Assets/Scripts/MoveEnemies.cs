using UnityEngine;
using System.Collections;

public class MoveEnemies : MonoBehaviour {

    private NavMeshAgent nav;
    [HideInInspector]
	public bool isSwimming;

    
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
