using UnityEngine;
using System.Collections;

//This script will run all miscellaneous functions related to the game. 

public class gameManager : MonoBehaviour {
	//Camera

	//Menu Booleans
	private bool onPause;
	private bool onOptions;
	private bool onMenu;

	//isSound is true when sound is playing
	private bool isSound;

	//Is occulus enabled?
	private bool onOculus;

	// Use this for initialization

	float lockPos = 2;
	void Start () {
		onPause = false;
		onOptions = false;
		onMenu = false;
		onOculus = false;

		//Oculus is disabled for start
		GameObject.Find ("CameraLeft").GetComponent<Camera>().enabled = false;
		GameObject.Find ("CameraRight").GetComponent<Camera>().enabled = false;

		//Checks to see if sound is already paused
		if (AudioListener.pause == false) {
						isSound = true;
				} else {
						isSound = false;
				}


	}
	
	// Update is called once per frame
	void Update () {
		//This pauses the game and gives an in game menu screen
		// ********** GET RID OF OTHER PAUSE BUTTON ON P ************* 
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(onPause == false){
			//	GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
				gameObject.GetComponent<MouseLook>().enabled = false;
				gameObject.GetComponent<FPSInputController>().enabled = false;
				gameObject.GetComponent<CharacterController>().enabled = false;
				gameObject.GetComponent<CharacterMotor>().enabled = false;
				GameObject.Find ("Main Camera").GetComponent<MouseLook>().enabled = false;



				//*** WE NEED TO VERIFY THAT THE MOUSE IS STILL AT THE CENTER OF THE SCREEN ***
				Screen.lockCursor = false;
				onPause = true;
				onMenu = true;
				Time.timeScale = 0.0f;
			}
			else if(onPause == true){
				gameObject.GetComponent<MouseLook>().enabled = true;
				gameObject.GetComponent<FPSInputController>().enabled = true;
				gameObject.GetComponent<CharacterController>().enabled = true;
				gameObject.GetComponent<CharacterMotor>().enabled = true;
				GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;				

				Screen.lockCursor = true;
				onPause = false;
				onMenu = false;
				onOptions = false;
				Time.timeScale = 1.0f;
			}
		}
		//end escape button
	}

	void OnGUI(){
		//When paused screen pops up
		if(onPause == true){
			if(onMenu == true){
				//Box creates background for buttons
				GUI.Box(new Rect(Screen.width/2 - 50, Screen.height/2, 80, 50), "");

					if(GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2 + 30, 80, 20), "Options")){
						onOptions = true;
						onMenu = false;
					}

					if(GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2, 80, 20), "Quit")){
						Application.Quit();
					}
			}

			if(onOptions == true){
				//This is where any GUI code for the options menu will go
				GUI.Box(new Rect(Screen.width/2 - 50, Screen.height/2, 100, 80), "");
				if(GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2, 100, 20), "Back")){
					onOptions = false;
					onMenu = true;

				}
				
				if(GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2 + 60, 100, 20), "Mute Sound")){
					if(isSound == false){
						AudioListener.pause = false;
						isSound = true;
						Debug.Log("Sound On");
					}else{
						AudioListener.pause = true;
						isSound = false;
						Debug.Log ("Sound Off");
					}

					
				}
				if(GUI.Button (new Rect (Screen.width/2 - 50, Screen.height/2 + 30, 100, 20), "Enable Oculus")){
					if(onOculus == false){
						GameObject.Find ("Main Camera").GetComponent<Camera>().enabled = false;
						GameObject.Find ("CameraLeft").GetComponent<Camera>().enabled = true;
						GameObject.Find ("CameraRight").GetComponent<Camera>().enabled = true;
						onOculus = true;
						//Camera.en
					}else{
						GameObject.Find ("Main Camera").GetComponent<Camera>().enabled = true;
						GameObject.Find ("CameraLeft").GetComponent<Camera>().enabled = false;
						GameObject.Find ("CameraRight").GetComponent<Camera>().enabled = false;
						Debug.Log ("EXIT RIFT");
					}
				}
			}
		}



	}
}
