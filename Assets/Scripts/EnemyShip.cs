﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

	public float speed, shotSpeed, fireRate, scoreAward;
	public int hp;
	public EnemyShot shot;
	public GameObject gun;
	public GameObject smoke, explosion;

	protected bool dead;
	protected bool active;
	protected float fireTime;
	public Vector3 startPosition;
	protected Vector3 velocity;

	void Awake () {
		active = false;
		velocity = Vector3.zero;
		fireTime = 2 / fireRate;
	}

	protected void CheckActive(){
		if (!active) {
			velocity.z = 14.0f*speed;
			transform.position += velocity;
			if (transform.position.z > 150) {
				transform.Rotate(new Vector3(0.0f, 180.0f,0.0f));
				transform.position = startPosition;
				active = true;
			}
		}
	}

	protected void LateUpdate(){
		if (hp <= 0 && !dead) {
			GameObject.Find ("Score").GetComponent<ScoreManager> ().score += scoreAward;
			Instantiate (smoke, this.transform);
			Instantiate (explosion, this.transform);
			dead = true;
			this.transform.position -= new Vector3(2.0f,0.0f,0.0f);
		}
		if(dead){
			if (this.transform.position.y > -1) {
				velocity.x = 4.0f * Time.deltaTime;
				velocity.y = 12.0f * Time.deltaTime;
				transform.Rotate (new Vector3 (0.0f, 0.0f, 30.0f*Time.deltaTime));
			} else {
				Destroy (this.gameObject);
			}
		}
	}

	protected void Move(){
		//Move
		if(transform.position.z > 100) velocity.z = speed*4;
		else velocity.z = speed;

		transform.position -= velocity;

		//Check bounds
		if (transform.position.z < -40) {
			Destroy (this.gameObject);
		}
	}

	//Colliding with player fire
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player Fire") {
			this.hp--;
			Destroy (other.gameObject);
		}
	}
		
}