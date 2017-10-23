using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Author: Jonas Iacobi (12:55 23-10-2017)
 * This class keeps track of the player score.
 * Requires a Text component.
*/
public class ScoreManager : MonoBehaviour {

	public int scorePerSecond;	//How much score to be awarded over time
	private float score;		//The score of the current session
	private Text text;			//The score text

	void Start () {
		score = 0.0f;
		text = GetComponent<Text> ();
	}

	//Increments the score by time and updates the score text.
	void Update () {
		score += Time.deltaTime * scorePerSecond;
		text.text = "Score: " + (int)Mathf.Floor(score);
	}

	//Used by external classes to increase (or decrease) the score
	public void AddScore(float score)
	{
		this.score += score;
	}
		
}
