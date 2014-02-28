using UnityEngine;
using System.Collections;

public class pullLever : MonoBehaviour {
	public Collider thePlayer;
	public bool pulled;
	public GameObject leftWall;
	public GameObject rightWall;
	
	// Use this for initialization
	void Start () {
		thePlayer = null;
		pulled = false;
		leftWall = GameObject.Find ("Wall_Left");
		rightWall = GameObject.Find ("Wall_Right");
		this.animation ["leverPull"].wrapMode = WrapMode.ClampForever;
		leftWall.animation ["leftCaveWall"].wrapMode = WrapMode.ClampForever;
		rightWall.animation ["rightCaveWall"].wrapMode = WrapMode.ClampForever;
	}
	
	// If the lever is being pulled, play the lever animation
	// Also checks which lever it is and plays the corresponding wall animation
	void Update () {
		if (pulled == true) {
			this.animation.Play("leverPull");
			if(this.gameObject.name == "Lswitch"){
				Debug.Log ("yes");
				leftWall.animation.Play("leftCaveWall");
			}
			else{rightWall.animation.Play("rightCaveWall");}
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
