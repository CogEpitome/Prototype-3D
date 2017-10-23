using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	public PlayerController2D player;
	public float flashRate;
	private float flashTime, displayedHp, maxHp;
	private Text text;
	private string baseText;

	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text> ();
		flashTime = 0;
		displayedHp = 0;
		maxHp = player.GetMaxHp ();
		baseText = "\n.::HULL INTEGRITY::.\n";
	}
	
	// Update is called once per frame
	void Update () {
		float hp = player.GetHp ();

		if (hp <= 0) {
			string tempText = "!HULL BREACHED!";
			text.text = tempText + baseText;
		}
		else
		if (displayedHp != hp) {
			string tempText = "";
			for (int i = 0; i < hp; i++) {
				tempText += "O";
			}
			text.text = tempText + baseText;
		}

		if (hp < maxHp / 4.0f || hp <= 1.0f) {
			text.color = Color.red;
		} else {
			if (hp <= maxHp / 2.0f) {
				text.color = Color.yellow;
			} else {
				text.color = Color.green;
			}
		}
	}
}
