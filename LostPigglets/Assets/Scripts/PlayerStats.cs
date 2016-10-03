using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats instance;

    [HideInInspector]
    public int piggletsCollected = 0;
    [HideInInspector]
    public Light spotlight;
    [HideInInspector]
    public float pigletsFollowPosZ = -1.5f;
    public float chargeSpeed = 2000f;
    public float chargeCooldown = 8f;
    public float doubleTapTime = 0.5f;
    public float collisionRadiusMonster = 10;
    [HideInInspector]
    public float rotSpeedFinger = 3f;
    public float setChargeFalse = 1f;
    [HideInInspector]
    public int radiusForRotation = 9;
    public float playerSpeed; // The speed of the player
    public float acceleration; // The acceleration of the player
    public float rotateRadius; // The variable that controls the vicinity in which the character will only rotate
    public float speedMaxDist; // Variable to scale the speed according to how away your finger is from the screen. 20 appears to be a good number
    public int piggletsInGame = 2;
    public Vector3 cameraOffset;
    public Vector3 rotationOffset = new Vector3(0, 7.5f, 0);



    void Awake()
    {
		instance = this;
	}

}
