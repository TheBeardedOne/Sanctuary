﻿using UnityEngine;
using System.Collections;

public class pullLever : MonoBehaviour {
	public Collider thePlayer;
	public bool pulled;
	public GameObject leftWall;
	public GameObject rightWall;
	
	// Use this for initialization
	// Identifies the lever animation and sets it to play once
	// Identifies the wall platforms and sets their animation to play only once
	void Start () {
		thePlayer = null;
		pulled = false;
		leftWall = GameObject.Find ("Cave_Platform_Left");
		rightWall = GameObject.Find ("Cave_Platform_Right");
		this.animation ["leverPull"].wrapMode = WrapMode.ClampForever;
		leftWall.animation ["leftCaveWall"].wrapMode = WrapMode.ClampForever;
		rightWall.animation ["rightCaveWall"].wrapMode = WrapMode.ClampForever;
		this.GetComponent<Highlight_Mouseover> ().set = false;
	}
	
	// If the lever is being pulled, play the lever animation
	// Also checks which lever it is and plays the corresponding wall animation
	void Update () {
		if (pulled == true) {
			this.animation.Play("leverPull");
			if(this.gameObject.name == "Lswitch"){
				leftWall.audio.Play ();
				leftWall.animation.Play("leftCaveWall");
			}
			else{
				rightWall.audio.Play ();
				rightWall.animation.Play("rightCaveWall");}
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
			this.GetComponent<Highlight_Mouseover> ().set = true;
			//GameObject.Find ("Main Camera").GetComponent<playerInteract>().inTrigger = true;
			if (Input.GetMouseButtonDown (0)) {
				pulled = true;
			}
		}
	}

	void OnTriggerExit(){
		//GameObject.Find ("Main Camera").GetComponent<playerInteract> ().inTrigger = false;
		this.GetComponent<Highlight_Mouseover> ().set = false;
	}
}
