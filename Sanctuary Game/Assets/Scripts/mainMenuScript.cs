using UnityEngine;
using System.Collections;

public class mainMenuScript : MonoBehaviour {

	private bool onMenu;
	private bool onOptions;
	private bool onCredits;

	// Use this for initialization
	void Start () {
		onMenu = true;
		onOptions = false;
		onCredits = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		
		//GUI MAIN MENU
		if(onMenu == true){
			if (GUI.Button (new Rect (Screen.width/2 - 300,Screen.height/2 + 100,80,20), "Play")) {
				//Must correct build settings so that menu "level" is 0 and game is 1
				Application.LoadLevel (1);
			}
			if(GUI.Button (new Rect (Screen.width/2 - 300, Screen.height/2 + 150, 80, 20), "Options")){
				onMenu = false;
				onOptions = true;
			}
			if(GUI.Button (new Rect(Screen.width/2 - 300, Screen.height/2 + 200, 80, 20), "Credits")){
				onMenu = false;
				onCredits = true;
			}
			if(GUI.Button(new Rect (Screen.width/2 - 300, Screen.height/2 + 250, 80, 20), "Quit")){
				//Double check this
				Application.Quit();
			}
		}
		//Only option will be to mute sound **** Must program some buttons ****
		if(onOptions == true){
				//This is where any GUI code for the options menu will go
				if(GUI.Button (new Rect (Screen.width/2 - 300, Screen.height/2 + 250, 80, 20), "Back")){
					onOptions = false;
					onMenu = true;
				}
				if(GUI.Button (new Rect (Screen.width/2 - 300, Screen.height/2 + 150, 100, 20), "Mute Sound")){

				}
				if(GUI.Button (new Rect (Screen.width/2 - 300, Screen.height/2 + 200, 100, 20), "Enable Oculus")){
					
				}
		}
		//Credits Display
		if(onCredits == true){
			if(GUI.Button (new Rect (Screen.width/2 - 300, Screen.height/2 + 250, 80, 20), "Back")){
					onCredits = false;
					onMenu = true;
				}
		}


	}

}
