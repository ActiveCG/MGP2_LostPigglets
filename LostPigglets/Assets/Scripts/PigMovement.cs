using UnityEngine;
using System.Collections;

public class PigMovement : MonoBehaviour {

	void OnEnable()
	{
		TouchInput.move += Movement;	
	}

	void OnDisable()
	{
		TouchInput.move -= Movement;
	}


	void Movement(Vector3 position)
	{
		Debug.Log(position);
	}
}
