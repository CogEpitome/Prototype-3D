using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

	public float speed, damage;

	// Update is called once per frame
	protected void Move () {
		transform.position += new Vector3 (0.0f, 0.0f, -speed * Time.deltaTime);

		if (transform.position.z < -100)
			Destroy (this.gameObject);
	}

}
