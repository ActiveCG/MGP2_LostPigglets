﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 140, 180), "Restart"))
            SceneManager.LoadScene("Scenes/Development");
        if (GUI.Button(new Rect(10, 270, 70, 90), "Pause"))
            Time.timeScale = 0; 
        if (GUI.Button(new Rect(10, 370, 70, 90), "Resume"))
            Time.timeScale = 1;
    }
}
