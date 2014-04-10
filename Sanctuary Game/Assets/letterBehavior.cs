using UnityEngine;
using System.Collections;

public class letterBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<dfSprite> ().IsVisible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (gameObject.GetComponent<dfSprite> ().IsVisible) {
				if(Input.GetMouseButtonDown(0)){
				gameObject.GetComponent<dfSprite> ().IsVisible = false;
					}
				}
	}
}
