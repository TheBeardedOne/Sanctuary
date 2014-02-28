using UnityEngine;
using System.Collections;

public class pullLever : MonoBehaviour {
	public Collider thePlayer;
	public bool pulled;
	
	// Use this for initialization
	void Start () {
		thePlayer = null;
		pulled = false;
		this.animation ["leverPull"].wrapMode = WrapMode.ClampForever;
	}
	
	// Update is called once per frame
	void Update () {
		if (pulled == true) {
			this.animation.Play("leverPull");
		}
	}
	
	// Recognizes the first person controller
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			thePlayer = other;
		}
	}
	
	// If the first person controller is within the trigger range and mouse is clicked,
	// set the door animation to true
	void OnTriggerStay(){
		if (thePlayer != null) {
			if (Input.GetMouseButtonDown (0)) {
				pulled = true;
			}
		}
	}
}
