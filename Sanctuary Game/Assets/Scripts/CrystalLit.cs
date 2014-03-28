using UnityEngine;
using System.Collections;

public class CrystalLit : MonoBehaviour {
	public Camera playerCam;
	public playerInteract clicker;

	// Use this for initialization
	void Start () {
		// get script for player interaction
		playerCam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		clicker = playerCam.GetComponent<playerInteract> ();

		// set the crystal light off initally
		this.light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		// checks for whether the player clicks on the crystal
		if(clicker.tempHitObj != null){
			// if so, turn the crystal light on
			if(clicker.tempHitObj.gameObject.name == this.name){
				this.light.enabled = true;
			}
		}
	}
}
