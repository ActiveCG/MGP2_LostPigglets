using UnityEngine;
using System.Collections;

public class WaterScroll : MonoBehaviour {

	public float scrollSpeed = 0.5F;
	public float offsetX, offsetY;
	public Renderer rend;
	void Start() {
		rend = GetComponent<Renderer>();
	}
	void Update() {
		rend.material.SetTextureOffset("_MainTex", new Vector2(scrollSpeed *Mathf.Sin(Time.time *  offsetX), scrollSpeed *Mathf.Sin(Time.time *  offsetY)));
	}
}
