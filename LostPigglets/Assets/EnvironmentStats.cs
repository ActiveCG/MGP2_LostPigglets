using UnityEngine;
using System.Collections;

public class EnvironmentStats : MonoBehaviour {

    public static EnvironmentStats instance;

    public Vector3 emissionColor;

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

}
