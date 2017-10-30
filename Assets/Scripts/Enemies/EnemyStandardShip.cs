using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandardShip : EnemyShip {

	private float pathMagnitude, pathFrequency;
	private float time, vsp, dir;

	void Start(){
		pathMagnitude = 13.0f / (Random.Range (1.0f,4.0f));
		pathFrequency = .1f;
		time = 0.0f;
		vsp = 0.0f;
		dir = Random.Range (0, 2) * 2 - 1;
	}

	// Update is called once per frame
	void Update () {

		if (active) {
			if (!dead) {
				//Fire!
				if (fireTime > 1 / fireRate) {
					fireTime = 0;
					EnemyShot shotClone = Instantiate (shot, gun.transform.position + velocity + transform.up*0.0f, gun.transform.rotation);
					shotClone.speed = shotSpeed;
				} else {
					fireTime += Time.deltaTime;
				}

				MovePath ();
			}
			Move ();

		}
		else
			CheckActive ();
	}

	private void MovePath(){
		time += Time.deltaTime;
		float sine = dir * Mathf.Cos (2.0f * Mathf.PI * pathFrequency * time);
		vsp = pathMagnitude * sine;
		transform.localPosition = new Vector3(transform.localPosition.x, startPosition.y - 10.0f + vsp, transform.localPosition.z);
	}
}
