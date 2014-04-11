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
		scriptFind = GameObject.Find ("Main Camera").GetComponent<Camera>();
		keyFind = scriptFind.GetComponent<playerInteract>();
		keyHold = false;
		this.animation ["cabinDoorAnim"].wrapMode = WrapMode.ClampForever;
	}
	
	// If the door is set to open, play the animation
	void Update () {
		Debug.Log (this.GetComponent<Highlight_Mouseover> ().set);
		if (open == true) {
			this.animation.Play("cabinDoorAnim");
			GameObject.Find ("Key").renderer.enabled = false;
		}
	}

	// Recognizes the first person controller
	// Sees if the key is being held
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			thePlayer = other;
			keyHold = keyFind.isHolding;
		}
	}

	// If the first person controller is within the trigger range while holding the key
	//and mouse is clicked, set the door animation to true
	void OnTriggerStay(){
		if (thePlayer != null) {
			keyHold = keyFind.isHolding;
			if(keyHold){
				this.GetComponent<Highlight_Mouseover> ().set = true;
			}

			if (Input.GetMouseButtonDown (0)) {
				if(keyHold){
					open = true;
					audio.Play();
					//de-renders key instead of having it drop to the floor
					GameObject.Find ("Key").renderer.enabled = false;
				}
			}
		}
	}

	void OnTriggerExit(){
		this.GetComponent<Highlight_Mouseover> ().set = false;
	}
}
