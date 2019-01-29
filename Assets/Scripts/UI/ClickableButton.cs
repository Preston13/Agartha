using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableButton : MonoBehaviour, IPointerClickHandler {

	public void OnPointerClick(PointerEventData eventData){
		if (eventData.button == PointerEventData.InputButton.Left) {
			Debug.Log ("Left Click!");
		} else if (eventData.button == PointerEventData.InputButton.Right) {
			Debug.Log ("Right Click!");
		}
	}

}
