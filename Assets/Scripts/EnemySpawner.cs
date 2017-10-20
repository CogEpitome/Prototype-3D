using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

	// Use this for initialization
	void Start () {
		spawnNo = 3;
		waveNo = 0;
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
						spawnHeights [i] = UniqueInt(spawnHeights, 1, 8);
					}
						for (int i = 0; i < spawnNo; i++) {
						Spawn (waveInd, (1+spawnHeights[i])*5.0f);
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
		enemy = Instantiate (wave [i], transform.position, Quaternion.identity);
		enemy.startPosition = new Vector3 (0.0f, y, 110.0f+Random.Range(0.0f,30.0f));
		enemy.transform.position = new Vector3 (0.0f, enemy.startPosition.y, 0.0f);
	}

	void NewWave(){
		print ("new wave");
		waveNo++;
		waveInd = 0;
		waveTime = 0;
		spawnNo = 3 + (int)(waveNo/10);
		wave = new EnemyShip[3 + (waveNo*2) * spawnNo];
		for (int i = 0; i < 3 + (waveNo*2) * spawnNo; i++) {
			enemyInd =  Random.Range (0, (int)enemies.Length);
			wave [i] = enemies [enemyInd];
		}
	}
			
	int UniqueInt(int[] spawnHeights, int min, int max){
		int val = Random.Range(min, max);
		while(spawnHeights.Contains(val)){
			val = Random.Range(min, max);
		}
		return val;
	}
}
