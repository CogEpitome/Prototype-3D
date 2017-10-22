using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserShip : EnemyShip{

	private bool fired;
	private float fireDuration;
	private EnemyLaserShot laser;

	void Start(){
		fired = false;
		fireDuration = 5;
	}

	//The laser ship has two modes: firing and moving. It enters the screen, fires, and moves out.
	void Update () {
		if (active) {
			if (!dead) {
				if (fireDuration > 0 && transform.position.z < 90) {
					if (!fired && fireDuration < 4) {
						laser = Instantiate (shot, this.transform.position, this.transform.rotation) as EnemyLaserShot;
						laser.speed = shotSpeed;
						fired = true;
					} else {
						if (fired) {
							laser.GetComponent<TrailRenderer> ().time += Time.deltaTime;
						}
						fireDuration -= Time.deltaTime;
						this.transform.Rotate (new Vector3 (0.0f, 0.0f, 1.0f));
					}
				} else {
					Move ();
					this.transform.rotation = Quaternion.Lerp (this.transform.rotation, Quaternion.Euler (Vector3.zero), Time.deltaTime);
				}
			} else
				Move ();
		} else {
			CheckActive ();
		}
	}
}