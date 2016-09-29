using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats playerStatsCurrent;

	public int piggletsInGame; //number of pigglets in the level

	void Awake()
    {
		playerStatsCurrent = this;
	}

}
