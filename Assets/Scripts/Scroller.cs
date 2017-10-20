using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

	public float scrollSpeed;

	private Renderer rend;
	private Vector2 offset;

	void Start(){
		rend = GetComponent<Renderer> ();
		offset = new Vector2 (0.0f, 0.0f);
	}

	void LateUpdate() {
		offset.y += scrollSpeed * Time.fixedDeltaTime;
		rend.material.SetTextureOffset ("_MainTex", offset);
	}
}
