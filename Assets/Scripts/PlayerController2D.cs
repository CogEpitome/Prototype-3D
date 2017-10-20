using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController2D : MonoBehaviour {

	public Vector3 upperBounds, lowerBounds;
	private Vector3 velocity, shipAngle;
	private float pitch, roll, yaw, fireTime, hp;
	private Ship2D ship;

	// Use this for initialization
	void Awake () {
		ship = this.GetComponentInChildren<Ship2D> ();
		fireTime = 0;
	}

	void Start(){
		hp = ship.integrity;
	}

	void Update(){
		//Fire!
		if (Input.GetButton ("Fire1") && fireTime > 1/ship.fireRate) {
			fireTime = 0;
			Instantiate (ship.shot, ship.gun.transform.position + velocity, Quaternion.identity);
		} else {
			fireTime+=Time.deltaTime;
		}

		//Game Over
		if (hp <= 0) {
			GameOver ();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {

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
	void OnTriggerEnter(Collider other){
		if (other.tag == "Enemy Fire") {
			this.hp -= other.GetComponent<EnemyShot>().damage;
			ReflectDamage ();
			Destroy (other.gameObject);
		}
		if (other.tag == "Enemy Trail Fire") {
			this.hp -= other.GetComponent<TrailCollider> ().damage;
			ReflectDamage ();
			Destroy (other.gameObject);
		}
	}

	void ReflectDamage(){
		}

	public float GetHp(){
		return hp;
	}

	public float GetMaxHp(){
		return ship.integrity;
	}

	void GameOver(){
		GameObject.Find ("SceneController").GetComponent<SceneController> ().GameOver ();
		Destroy (this.gameObject);
	}
}
