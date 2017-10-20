using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStandardShip : EnemyShip {

	// Update is called once per frame
	void Update () {

		if (active) {
			if (!dead) {
				//Fire!
				if (fireTime > 1 / fireRate) {
					fireTime = 0;
					EnemyShot shotClone = Instantiate (shot, gun.transform.position + velocity, gun.transform.rotation);
					shotClone.speed = shotSpeed;
				} else {
					fireTime += Time.deltaTime;
				}
			}
			Move ();
		}
		else
			CheckActive ();
	}
}
