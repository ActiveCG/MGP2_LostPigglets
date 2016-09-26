using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats playerStatsCurrent;

	public float playerHealth;
	public float playerSpeed;

	void Start(){

		playerStatsCurrent = this;
	}

}
