using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {
	public Collider thePlayer;
	public bool open;

	// Use this for initialization
	void Start () {
		thePlayer = null;
		open = false;
		this.animation ["cabinDoorAnim"].wrapMode = WrapMode.ClampForever;
	}
	
	// Update is called once per frame
	void Update () {
		if (open == true) {
		this.animation.Play("cabinDoorAnim");
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("working");
		if (other.gameObject.tag == "Player") {
			thePlayer = other;
		}
	}

	void OnTriggerStay(){
		if (thePlayer != null) {
			if (Input.GetMouseButtonDown (0)) {
				open = true;
			}
		}
	}
}
