using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public float score;
	public int scorePerSecond;
	private Text text;

	// Use this for initialization
	void Start () {
		score = 0.0f;
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime * scorePerSecond;
		text.text = "Score: " + (int)Mathf.Floor(score);
	}
		
}
