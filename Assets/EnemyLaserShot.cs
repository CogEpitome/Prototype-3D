using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserShot : EnemyShot {

	public float precision;
	public TrailCollider trailCollider;
	private float nextCollider;


	void Start(){
		nextCollider = 0;
		damage /= precision;
	}
	// Update is called once per frame
	void Update () {
		Move ();

		//Drop collision objects
		if (nextCollider > precision) {
			nextCollider = 0;
			TrailCollider thisCollider = Instantiate (trailCollider, this.transform.parent);
			thisCollider.transform.position = this.transform.position + new Vector3 (0.0f, 0.0f, 1.0f);;
			thisCollider.damage = damage;
			thisCollider.life = this.GetComponent<TrailRenderer>().time;
		} else {
			nextCollider += speed * Time.deltaTime;
		}
	}
}
