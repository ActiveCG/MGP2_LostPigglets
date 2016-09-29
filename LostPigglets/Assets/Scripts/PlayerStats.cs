using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats instance;

	public int piggletsInGame; //number of pigglets in the level

	void Awake()
    {
		instance = this;
	}

}
