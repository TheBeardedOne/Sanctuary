using UnityEngine;
using System.Collections;

//This script will run all miscellaneous functions related to the game. 

public class gameManager : MonoBehaviour {

	private bool onPause;
	private bool onOptions;
	// Use this for initialization
	void Start () {
		onPause = false;
		onOptions = false;
	}
	
	// Update is called once per frame
	void Update () {
		//This pauses the game and gives an in game menu screen
		// ********** GET RID OF OTHER PAUSE BUTTON ON P ************* 
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(onPause == false){
				GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
				gameObject.GetComponent<MouseLook>().enabled = false;
				gameObject.GetComponent<FPSInputController>().enabled = false;
				gameObject.GetComponent<CharacterController>().enabled = false;
				gameObject.GetComponent<CharacterMotor>().enabled = false;


				//*** WE NEED TO VERIFY THAT THE MOUSE IS STILL AT THE CENTER OF THE SCREEN ***
				Screen.lockCursor = false;
				onPause = true;
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
				Time.timeScale = 1.0f;
			}
		}
		//end escape button
	}

	void OnGUI(){
		//When paused screen pops up
		if(onPause == true){
			GUI.Box(new Rect(Screen.width/2, Screen.height/2, 80, 80), "");

			if(GUI.Button (new Rect (Screen.width/2, Screen.height/2 + 60, 80, 20), "Options")){
				onOptions = true;
			}

			if(GUI.Button (new Rect (Screen.width/2, Screen.height/2 + 10, 80, 20), "Quit")){
				Application.Quit();
			}

			if(onOptions == true){
				//This is where any GUI code for the options menu will go
				if(GUI.Button (new Rect (Screen.width/2, Screen.height/2 + 250, 80, 20), "Back")){
					onOptions = false;
				}

				if(GUI.Button (new Rect (Screen.width/2, Screen.height/2 + 150, 100, 20), "Mute Sound")){
					
				}
				if(GUI.Button (new Rect (Screen.width/2, Screen.height/2 + 200, 100, 20), "Enable Oculus")){
					
				}
			}
		}

	}
}
