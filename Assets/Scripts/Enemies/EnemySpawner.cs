using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/* Author: Jonas Iacobi (13:16 23-10-2017)
 * Handles the spawning of enemy ships, including waves.
*/
public class EnemySpawner : MonoBehaviour {

	private int waveNo;
	public int spawnNo;
	public float intervalLength, waveLength, spawnLength, waveTime;
	public EnemyShip[] enemies;
	public EnemyShip[] wave;
	public EnemyShip enemy;
	private int[] spawnHeights;
	private float spawnTime;
	private int enemyInd, waveInd;
	private string difficultyKey = "Difficulty";

	// Use this for initialization
	void Awake () {
		spawnNo = 2;
		if (PlayerPrefs.HasKey (difficultyKey)) {
			waveNo = (int)PlayerPrefs.GetFloat (difficultyKey) - 1;
		} else {
			waveNo = 0;
		}
		waveInd = 0;
		waveTime = 0;
		spawnTime = 0;
		NewWave ();
	}
	
	// Update is called once per frame
	void Update () {
			if (waveTime > intervalLength) {
				if (spawnTime > spawnLength) {
					if (waveInd < wave.Length) {

					spawnHeights = new int[spawnNo];
					for (int i = 0; i < spawnNo; i++) {
						spawnHeights [i] = UniqueInt(spawnHeights, 0, 9);
					}
						for (int i = 0; i < spawnNo; i++) {
						Spawn (waveInd, (spawnHeights[i])*5.0f);
							waveInd++;
						}		
						spawnTime = 0;
					} else {
					if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
						NewWave ();
					}
					}
				} else {
					spawnTime += Time.deltaTime;
				}
			} else {
				waveTime += Time.deltaTime;
			}
		}

	void Spawn(int i, float y){
		enemy = Instantiate (wave [i], this.transform);
		enemy.startPosition = new Vector3 (0.0f, y, 110.0f+Random.Range(0.0f,30.0f));
		enemy.transform.position = new Vector3 (enemy.transform.position.x, enemy.startPosition.y, -60.0f);
	}

	void NewWave(){
		print ("new wave");
		waveNo++;
		waveInd = 0;
		waveTime = 0;
		spawnNo = 2 + (int)(waveNo/10);
		wave = new EnemyShip[3 + (waveNo*2) * spawnNo];
		for (int i = 0; i < 3 + (waveNo*2) * spawnNo; i++) {
			enemyInd =  Random.Range (0, (int)enemies.Length);
			wave [i] = enemies [enemyInd];
		}
	}
			
	//Returns an integer between min and max that is not present in an array
	int UniqueInt(int[] array, int min, int max){
		int safeInt = 100000;
		int val = Random.Range(min, max);
		while(array.Contains(val)){
			if (--safeInt <= 0) {Debug.Log("Method UniqueInt in EnemySpawner.cs failed to find a unique integer, check parameters."); break;} //Basic sanity check to prevent an infinite or long loop in case 
			val = Random.Range(min, max);
		}
		return val;
	}
}
