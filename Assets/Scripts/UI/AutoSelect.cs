using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoSelect : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject selectedButton;
	private bool buttonSelected;

	void Update () {
		if (buttonSelected == false) 
		{
			eventSystem.SetSelectedGameObject (selectedButton);
			buttonSelected = true;
		}
	}

	private void OnDisable(){
		buttonSelected = false;
	}
}
