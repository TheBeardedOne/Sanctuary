using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour {
	public Texture2D crosshairTexture;
	public Texture2D interactTexture;
	public Rect position;
	public Rect position2;
	public bool OriginalOn = true;


	// Use this for initialization
	void Start () {
		position = new Rect((Screen.width - crosshairTexture.width) / 2, 
			(Screen.height - crosshairTexture.height) /2, crosshairTexture.width, crosshairTexture.height);
		position2 = new Rect((Screen.width - interactTexture.width) / 2, 
		                    (Screen.height - interactTexture.height) /2, interactTexture.width, interactTexture.height);
	}

	void OnGUI(){
		if(OriginalOn == true){
			GUI.DrawTexture(position, crosshairTexture);
		}
		else{GUI.DrawTexture(position2, interactTexture);}
	}
}