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
	private bool gameOver;						//Keeps track of whether a game over has occurred.
	public Text gameOverText;					//The game over text to be displayed.


	void Awake() //Initialize
	{
		gameOverWait = 0;
		gameOver = false;						
		gameOverText.enabled = false;			//Hide the Game Over text.
	}
		
	void Update()
	{
		if (gameOver) 
		{
			if (gameOverWait > gameOverTime) //If gameOverTime has passed, show the game over text and allow the scene to be restarted by the player.
			{
				gameOverText.enabled = true;
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
	}
}
