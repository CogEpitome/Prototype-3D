using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSlider : SliderSetting {

	public void OnValueChangedChild()
	{
		OnValueChanged ();
		AudioListener.volume = slider.value;
		Debug.Log ("Volume changed to " + AudioListener.volume);
	}
		
}
