using UnityEngine;
using System.Collections;

public class PigSkull : MonoBehaviour {

    Renderer render;
    Material mat;
    float r;
    float g;
    float b;
	bool lighting = false;

    void Start() {
        render = GetComponent<Renderer>();
        mat = render.material;
        r = EnvironmentStats.instance.emissionColor.x;
        g = EnvironmentStats.instance.emissionColor.y;
        b = EnvironmentStats.instance.emissionColor.z;
		lighting = false;
    }

    //Activate the light on the skull, and change the emission color.
    public void ActivateLight() {

        transform.GetChild(0).gameObject.SetActive(true);
        mat.EnableKeyword("_EMISSION");
        Color baseColor = new Color(r, g, b, 1.0f);
        mat.SetColor("_EmissionColor", baseColor);
		if (lighting == false) {
			GameManager.instance.lightPigSkull (gameObject);
			lighting = true;
		}
    }
}
