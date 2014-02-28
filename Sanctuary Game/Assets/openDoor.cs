﻿using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {
	public Collider thePlayer;
	public bool open;
	public GameObject you;
	public bool keyHold;

	// Use this for initialization
	void Start () {
		thePlayer = null;
		open = false;
		you = GameObject.Find ("Key");
		keyHold = false;
		this.animation ["cabinDoorAnim"].wrapMode = WrapMode.ClampForever;
	}
	
	// Update is called once per frame
	void Update () {
		if (open == true) {
		this.animation.Play("cabinDoorAnim");
		}
	}

	// Recognizes the first person controller
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			thePlayer = other;
		}
		keyHold = you.GetComponent<playerInteract> ().isHolding;
	}

	// If the first person controller is within the trigger range and mouse is clicked,
	// set the door animation to true
	void OnTriggerStay(){
		if (thePlayer != null) {
			Debug.Log (keyHold);
			if (Input.GetMouseButtonDown (0)) {
				if(keyHold){
					open = true;
				}
			}
		}
	}
}
