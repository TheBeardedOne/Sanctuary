using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour {
	public Texture2D crosshairTexture;
	public Texture2D interactTexture;
	public Rect position;
	public bool OriginalOn = true;


	// Use this for initialization
	void Start () {
		position = new Rect((Screen.width - crosshairTexture.width) / 2, 
			(Screen.height - crosshairTexture.height) /2, crosshairTexture.width, crosshairTexture.height);
	}

	void OnGUI(){
		if(OriginalOn == true){
			GUI.DrawTexture(position, crosshairTexture);
		}
		else{GUI.DrawTexture(position, interactTexture);}
	}
}