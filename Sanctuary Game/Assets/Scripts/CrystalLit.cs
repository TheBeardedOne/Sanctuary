using UnityEngine;
using System.Collections;

public class CrystalLit : MonoBehaviour {
	public Camera playerCam;
	public playerInteract clicker;

	// Use this for initialization
	void Start () {
		playerCam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		clicker = playerCam.GetComponent<playerInteract> ();
		this.light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(clicker.tempHitObj != null){
			if(clicker.tempHitObj.gameObject.name == this.name){
				this.light.enabled = true;
			}
		}
	}
}
