using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Author: Jonas Iacobi (13:26 23-10-2017)
 * This class is responsible for controlling the player's ship.
 * -Requires a child with a Ship2D component. 
 * -Requires an object with a SceneController component.
*/
public class PlayerController2D : MonoBehaviour {

	public bool autofire = true;						//Toggle autofire
	public Vector3 upperBounds, lowerBounds;			//These vectors limit the player's movement to within the specified bounds
	private Vector3 velocity, shipAngle;				//These vectors contain information about the player ship's relative velocity and angle in space.
	private float pitch, roll, yaw;						//These members contain information on the player ship's rotation along each axis. They correspond to the x, y, and z values of shipAngle
	private float fireTime, hp;							//fireTime holds the time since the last shot was fired, to be cross referenced with the fire rate. Hp is the player's current health.
	private float regenDelay, regenWait, regenRate;	 	//Regen refers to the ship's shields.
	private Ship2D ship;								//Reference to the ship properties container. The ship must be a child of the object this script is attached to.

	void Awake () 
	{
		ship = this.GetComponentInChildren<Ship2D> (); //A reference to the ship container is required.
	}

	void Start()	//Initialize private variables
	{
		fireTime = 0;
		hp = ship.integrity;
		regenDelay = ship.regenDelay;
		regenRate = ship.regenRate;
		regenWait = 0;
	}
		
	//Handle shooting and check for a game over.
	void Update()
	{
		//Check autofire toggle
		if (Input.GetButton ("Fire2")) {
			autofire = !autofire;
		}

		//Check for shooting
		if ((Input.GetButton ("Fire1") || autofire) && fireTime > 1/ship.fireRate) 							//The second condition compares the time since the last shot with the fireRate.
		{																							//The fireRate is in shots/second so the inverse gives the seconds/shot.
			fireTime = 0;																			//Reset the time since the last shot.
			Instantiate (ship.shot, ship.gun.transform.position + velocity, Quaternion.identity);	//Instantiate the shot.
		} 
		else 
		{
			fireTime+=Time.deltaTime;																//If no shot was fired, increase the time since the last shot.
		}

		//Check for health regen
	if (hp < GetMaxHp()) 
		{
			if (regenWait >= regenDelay) 
			{
				Regenerate ();
			} 
			else 
			{
				regenWait += Time.deltaTime;
			}
		}

		//Run the Game Over sequence if the player is out of hp
		if (hp <= 0) 
		{
			GameOver ();
		}
	}

	//Handle player movement
	void FixedUpdate () 
	{

		//Player local velocity
		velocity.x = 0.0f;
		velocity.y = Input.GetAxis("Vertical") * ship.vSpeed;
		velocity.z = Input.GetAxis("Horizontal") * ship.zSpeed;

		//Rotation of the ship (cosmestic only)
		pitch = Mathf.Clamp(Input.GetAxis("Horizontal") * ship.pitchAngle, -ship.pitchAngle, 0.0f);
		roll = Input.GetAxis ("Vertical") * ship.rollAngle;
		yaw = 0.0f;

		shipAngle.x = Mathf.Lerp(shipAngle.x, pitch, ship.pitchSpeed * Time.fixedDeltaTime);
		shipAngle.y = yaw;
		shipAngle.z = Mathf.Lerp(shipAngle.z, roll, ship.rollSpeed * Time.fixedDeltaTime);

		//Respect the boundaries
		if(transform.localPosition.y + velocity.y > upperBounds.y) velocity.y = upperBounds.y - transform.localPosition.y;
		if(transform.localPosition.y + velocity.y < lowerBounds.y) velocity.y = -transform.localPosition.y + lowerBounds.y;
		if(transform.localPosition.z + velocity.z > upperBounds.z) velocity.z = upperBounds.z - transform.localPosition.z;
		if(transform.localPosition.z + velocity.z < lowerBounds.z) velocity.z = -transform.localPosition.z - lowerBounds.z;

		//Move the ship
		transform.localPosition += velocity;

		//Rotate the ship
		ship.transform.localRotation = Quaternion.Euler(shipAngle);
	}

	//On collision with enemy fire
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy Fire") 
		{
			Damage(other.GetComponent<EnemyShot>().damage);
			ReflectDamage ();
			Destroy (other.gameObject);
		}
		if (other.tag == "Enemy Trail Fire") 
		{
			Damage(other.GetComponent<TrailCollider> ().damage);
			ReflectDamage ();
			Destroy (other.gameObject);
		}
	}

	//Start the GameOver sequence, and destroy the player
	void GameOver()
	{
		GameObject.Find ("SceneController").GetComponent<SceneController> ().GameOver ();
		Destroy (this.gameObject);
	}

	//Intended to show consmetic changes according to damage taken.
	void ReflectDamage()
	{

	}

	//Regenerate health
	public void Regenerate()
	{
		this.hp += regenRate * Time.deltaTime;
		if (this.hp >= this.GetMaxHp ()) { this.hp = this.GetMaxHp (); }
	}

	//Used by other objects to inflict damage
	public void Damage(float dmg)
	{
		this.hp -= dmg;
		regenWait = 0;
	}

	//Getters
	public float GetHp(){
		return hp;
	}

	public float GetMaxHp(){
		return ship.integrity;
	}
}
