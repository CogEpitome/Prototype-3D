using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/* Author: Jonas Iacobi (12:51 23-10-2017)
 * This class is responsible for managing the scene. This includes handling scene restarts and game overs.
 * Requires a reference to a game over Text component.
*/
public class SceneController : MonoBehaviour {

	public float gameOverTime; 					//Denotes the minimum time before the scene is allowed to be restarted after a game over. 
	private float gameOverWait; 				//Keeps track of how much time has passed since the game over.
	public bool gameOver;						//Keeps track of whether a game over has occurred.
	public Text gameOverText;					//The game over text to be displayed.
	public HighScore highScoreText;					//The high score text component.
	public ScoreManager scoreManager;


	void Awake() //Initialize
	{
		gameOverWait = 0;
		gameOver = false;						
		gameOverText.enabled = false;			//Hide the Game Over text.
		highScoreText.GetComponent<Text>().enabled = false;			//Hide the High Score text.
	}
		
	void Update()
	{
		if (gameOver) 
		{
			if (gameOverWait > gameOverTime) //If gameOverTime has passed, show the game over and high score texts and allow the scene to be restarted by the player.
			{
				gameOverText.enabled = true;
				highScoreText.GetComponent<Text>().enabled = true;
				highScoreText.UpdateText ();
				if (Input.anyKey) 
				{
					SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); //Restart the current scene
				}
			} else {
				gameOverWait += Time.deltaTime;
			}
		}

	}

	//Used by the player to indicate a game over has occurred.
	public void GameOver()
	{
		gameOver = true;
		gameOverWait = 0;
		scoreManager.active = false;
		if(scoreManager.score > PlayerPrefs.GetInt("HighScore")) PlayerPrefs.SetInt ("HighScore", (int)scoreManager.score);
	}
}
