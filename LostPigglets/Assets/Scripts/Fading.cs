using UnityEngine;
using System.Collections;

// ******************** //
//        DONE          //
// ******************** //

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;    // A texture used for fading.

    private float fadeSpeed = 0.3f;     // Fading speed
    private int drawDepth = -1000;      // Order in the draw hierarchy: a low number means it renders on top
    private float alpha = 1.0f;         // Alpha value between 0 and 1
    private int fadeDir = -1;           // Direction to fade: in = -1 or out = 1

    // Sets fadeDir making the scene fade in if -1 and out if 1
    public float BeginFade(int direction) {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnGUI() {
        // Fade out/in the alpha value using a direction, a speed and Time.deltaTime to convert the operation to seconds
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // Force (clamp) the number to be between 0 and 1 because GUI.color uses Alpha values between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        // Set color of our GUI.
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        // Render the texture on top
        GUI.depth = drawDepth;
        // Draw the texture to fit the entire screen area
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }
}