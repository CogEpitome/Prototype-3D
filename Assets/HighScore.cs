﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public Text textElement;
	public ScoreManager scorer;

	private string text;

	public void UpdateText()
	{
		int score = (int)scorer.score;
		if (score >= PlayerPrefs.GetInt ("HighScore")) {
			text = "!NEW HIGH SCORE!\n" + score;
		} else 
		{
			text = "YOUR SCORE: " + score + "\nHigh Score: " + PlayerPrefs.GetInt ("HighScore");
		}
		textElement.text = text;
	}
}
