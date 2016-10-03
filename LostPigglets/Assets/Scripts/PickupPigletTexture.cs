using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickupPigletTexture : MonoBehaviour {

    public static PickupPigletTexture instance;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Camera.main.transform.rotation;
    }

    public void SetText() {
        gameObject.SetActive(true);
        transform.GetComponentInChildren<Text>().text = PlayerStats.instance.piggletsCollected.ToString() + "/" + PlayerStats.instance.piggletsInGame.ToString();
        StartCoroutine(SetFalse());
    }

    IEnumerator SetFalse () {       
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
