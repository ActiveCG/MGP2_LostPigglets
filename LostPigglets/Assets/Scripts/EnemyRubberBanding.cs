using UnityEngine;
using System.Collections;

public class EnemyRubberBanding : MonoBehaviour {

	void OnBecameVisible()
    {
        GetComponent<NavMeshAgent>().speed = 6f;
    }

    void OnBecameInvisible()
    {
        //GetComponent<NavMeshAgent>().speed = 6f;
        StartCoroutine("IncreaseSpeed");
    }

    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<NavMeshAgent>().speed = 12f;
    }
}
