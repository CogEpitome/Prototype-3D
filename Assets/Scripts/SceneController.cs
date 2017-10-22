using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

	private float gameOverTime, gameOverWait;
	private bool gameOver;
	public Text gameOverText;

	void Awake(){
		gameOverTime = 1;
		gameOverWait = 0;
		gameOver = false;
		gameOverText.enabled = false;
	}

	public void GameOver(){
		gameOver = true;
		gameOverWait = 0;
	}

	void Update(){
		if (gameOver) {
			gameOverWait += Time.deltaTime;
			if (gameOverWait > gameOverTime) {
				gameOverText.enabled = true;
				if (Input.anyKey) {
					SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
				}
			}
		}

	}
}
