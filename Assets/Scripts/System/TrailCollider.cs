using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jonas Iacobi (12:44 23-10-2017)
 * This class represents the collision for an area of a rendered trail.
 * An object with a TrailRenderer will instantiate TrailCollider objects at a regular interval.
*/
public class TrailCollider : MonoBehaviour {

	public float life;		//The time before this collider autodestructs. Usually depends on the time member of the TrailCollider.
	public float damage;	//How much damage a collision with this collider will do.


	void Update () //Autodestruct after the lifetime is over.
	{
		life -= Time.deltaTime;
		if (life <= 0)
			Destroy (this.gameObject);
	}
}
