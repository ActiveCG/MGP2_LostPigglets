using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 50, 30), "Restart"))
            SceneManager.LoadScene("Scenes/Development");

    }
}
