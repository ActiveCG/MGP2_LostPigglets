using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {

	public delegate void MovementInput(Vector3 position);
	public static event MovementInput move;
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) 
		{
			move (Input.GetTouch (0).position);
		}
	}
}
