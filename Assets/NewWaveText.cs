using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewWaveText : MonoBehaviour {

	public EnemySpawner spawner;
	public Text text;

	// Use this for initialization
	void Start () {
		text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawner.waveTime < spawner.intervalLength && text.enabled == false) {
			text.enabled = true;
		}else{
			if(spawner.waveTime > spawner.intervalLength && text.enabled == true){
				text.enabled = false;
			}
		}
	}
}
