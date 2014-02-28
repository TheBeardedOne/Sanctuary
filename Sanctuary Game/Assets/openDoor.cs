using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {
	public Collider thePlayer;
	public bool open;
	public Camera scriptFind;
	public playerInteract keyFind;
	public bool keyHold;


	// Use this for initialization
	// Finds the playerInteract script attached to the player camera
	// Sets the animation to only run once
	void Start () {
		thePlayer = null;
		open = false;
		scriptFind = GameObject.Find ("Main Camera").GetComponent<Camera>();;
		keyFind = scriptFind.GetComponent<playerInteract>();
		keyHold = false;
		this.animation ["cabinDoorAnim"].wrapMode = WrapMode.ClampForever;
	}
	
	// If the door is set to open, play the animation
	void Update () {
		if (open == true) {
		this.animation.Play("cabinDoorAnim");
		}
	}

	// Recognizes the first person controller
	// Sees if the key is being held
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			thePlayer = other;
			keyHold = keyFind.isHolding;
		}
		Debug.Log (keyFind);
	}

	// If the first person controller is within the trigger range while holding the key
	//and mouse is clicked, set the door animation to true
	void OnTriggerStay(){
		if (thePlayer != null) {
			if (Input.GetMouseButtonDown (0)) {
				if(keyHold){
					open = true;
				}
			}
		}
	}
}
