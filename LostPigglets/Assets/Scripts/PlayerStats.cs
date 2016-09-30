using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats instance;

   // [HideInInspector]
	public static int piggletsCollected = 0;
    [HideInInspector]
    public Light spotlight;
    public float pigletsFollowPosZ = -1.5f;
    public float chargeSpeed = 2000f;
    public float doubleTapTime = 0.5f;
    public float collisionRadius;
    public float rotSpeedFinger = 3f;
    public int piggletsInGame;
    public Vector3 cameraOffset;
    public Vector3 rotationOffset = new Vector3(0, 7.5f, 0);


    void Awake()
    {
		instance = this;
		piggletsCollected = 0;
	}

}
