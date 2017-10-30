using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetting : MonoBehaviour {
	
	public string prefKey;
	public Slider slider;

	public void Start()
	{
		if (PlayerPrefs.HasKey (prefKey)) 
		{
			slider.value = PlayerPrefs.GetFloat (prefKey);
		}
	}

	public void OnValueChanged()
	{
		PlayerPrefs.SetFloat (prefKey, slider.value);
		PlayerPrefs.Save ();
		Debug.Log ("New setting " + prefKey + " set to " + slider.value);
	}
}
