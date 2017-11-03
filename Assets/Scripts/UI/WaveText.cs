using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveText : MonoBehaviour {

	public Text textElement;

	private string text;

	public void UpdateText(int waveNo)
	{
		text = "Wave: " + (waveNo+1);
		textElement.text = text;
	}
}
