using UnityEngine;
using System.Collections;

public class guiButtonBehaviour : MonoBehaviour {

	public bool pickedUpOrange;
	public bool pickedUpBlue;
	public bool pickedUpGreen;
	public bool pickedUpKey;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<dfButton> ().NormalBackgroundColor = Color.clear;
		pickedUpKey = false;
		pickedUpOrange = false;
		pickedUpBlue = false;
		pickedUpGreen = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (pickedUpOrange == true) {
						if(gameObject.name == "Button_1"){
								gameObject.GetComponent<dfButton> ().NormalBackgroundColor = Color.white;
						}
						
						if (Input.GetKeyDown (KeyCode.Alpha1)) {
								GameObject.Find ("Orange_stone").renderer.enabled = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().orngStoneGet = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().isHolding = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().hitObject = GameObject.Find ("Orange_stone").gameObject.transform;
						}
				}
		if (pickedUpBlue == true) {
						if(gameObject.name == "Button_2"){
								gameObject.GetComponent<dfButton> ().NormalBackgroundColor = Color.white;
						}
						if (Input.GetKeyDown (KeyCode.Alpha2)) {
								GameObject.Find ("Blue_stone").renderer.enabled = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().blueStoneGet = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().isHolding = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().hitObject = GameObject.Find ("Blue_stone").gameObject.transform;
						}
				}
			//Debug.Log(GameObject.Find ("Main Camera").GetComponent<playerInteract>().orngStoneGet);
		if (pickedUpGreen == true) {
						if(gameObject.name == "Button_3"){
								gameObject.GetComponent<dfButton> ().NormalBackgroundColor = Color.white;
						}
						if (Input.GetKeyDown (KeyCode.Alpha3)) {
								GameObject.Find ("Green_stone").renderer.enabled = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().grnStoneGet = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().isHolding = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().hitObject = GameObject.Find ("Green_stone").gameObject.transform;
						}
				}
		if (pickedUpKey == true) {
						if(gameObject.name == "Key"){
								gameObject.GetComponent<dfButton> ().NormalBackgroundColor = Color.white;
						}
						if (Input.GetKeyDown (KeyCode.Alpha4)) {
								GameObject.Find ("Key").renderer.enabled = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().keyGet = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().isHolding = true;
								GameObject.Find ("Main Camera").GetComponent<playerInteract> ().hitObject = GameObject.Find ("Key").gameObject.transform;
						}

				}
	}


	
}
