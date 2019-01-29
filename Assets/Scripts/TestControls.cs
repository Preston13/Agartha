using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestControls : MonoBehaviour {

	public GameObject backgroundPanel;

	// Use this for initialization
	void Start () {
		backgroundPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			//flip whatever the active value was
			backgroundPanel.SetActive (!backgroundPanel.activeSelf);

			//if the background was just turned on
			if (backgroundPanel.activeSelf) {
				//run the setup for the UI
				UIController.S.Setup();
			}
		}
	}

	public void Move(Button button){
		Debug.Log (button.name);
	}
}
