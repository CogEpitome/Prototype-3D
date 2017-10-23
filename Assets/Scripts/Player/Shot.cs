using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jonas Iacobi (12:09 23-10-2017)
 * This class handles moving the player's shots, and destroying them when they leave the screen.
*/
public class Shot : MonoBehaviour {

	public float speed; //determines the speed of the shot. Leave as 0 if the instantiator assigns a speed.

	[SerializeField]
	private static float maxZ = 120; //static member that determines the z position at which to destroy the shot.

	void Update () 
	{
		transform.position += new Vector3 (0.0f, 0.0f, speed * Time.deltaTime); //Move the shot along the z axis
		if (transform.position.z > maxZ) {Destroy (this.gameObject);}			//Destroy the shot it it has left the screen
	}
}
