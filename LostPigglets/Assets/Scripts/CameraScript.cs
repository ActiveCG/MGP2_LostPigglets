using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    private Transform player;
	private bool cinematics;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
		cinematics = false;
    }


    void Update()
    {
        
		if (player != null && cinematics == false)
        {
            //Set the position of the camera according to the player.
            transform.position = player.position + PlayerStats.instance.cameraOffset;
            //Make the camera always look at the player
            transform.LookAt(player.transform);
        }
    }

	void OnEnable () {
		GameManager.instance.OnPickUp += CinematicPickUp;
	}

	void OnDisable(){
		GameManager.instance.OnPickUp -= CinematicPickUp;
	}

	void CinematicPickUp(GameObject piglet){
		cinematics = true;
		//Vector3 cinematicOffsetPos = new Vector3 (4f, 5f,-9f);
		//Quaternion cinematicOffsetRot = new 

		//transform.position = piglet.transform.position + cinematicOffsetPos;
	}
}
