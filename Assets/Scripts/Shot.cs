using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0.0f, 0.0f, speed * Time.deltaTime);

		if (transform.position.z > 140)
			Destroy (this.gameObject);
	}
}
