using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{

    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        
        if (player != null)
        {
            //Set the position of the camera according to the player.
            transform.position = player.position + PlayerStats.instance.cameraOffset;
            //Make the camera always look at the player
            transform.LookAt(player.transform);
        }
    }
}
