using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jonas Iacobi (11:27 02-11-2017)
 * This class is a container for the properties of a player ship. The player's movement will be based on the parameters of the referenced Ship.
 * This class references an object of the type <Shot>
*/
public class Ship2D : MonoBehaviour {
	public float hSpeed, vSpeed, zSpeed;		 				//Determines the ship's speed while moving along the x, y, and z axes respectively.
	public float pitchAngle, pitchSpeed, rollAngle, rollSpeed; 	//Determines the ship's maximum pitch (x axis) and roll (z axis) angles in degrees, and the speed at which said angles change.
	public float fireRate; 										//Determines the maximum amount of shots the ship can fire in a second, expressed in shots per second.
	public float integrity, regenDelay, regenRate;				//The ship's maxímum health, i.e. how much damage it can withstand. regenDelay and -Rate is the time after damage before the shield regenerate, and how fast they do so.
	public Transform gun;										//Reference to the ship's Gun component, which is where the shots originate.
	public Shot shot;											//Reference to the specific kind of shot the ship will fire
}
