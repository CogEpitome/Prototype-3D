using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollider : MonoBehaviour {

	public float life, damage;

	
	// Update is called once per frame
	void Update () {
		life -= Time.deltaTime;
		if (life <= 0)
			Destroy (this.gameObject);
	}
}
