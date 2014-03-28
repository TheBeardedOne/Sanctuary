using UnityEngine;
using System.Collections;

public class OpenLvl2 : MonoBehaviour {
	public Collider thePlayer;
	public bool activate;
	public Camera scriptFind;
	public playerInteract holding;
	public bool carry;
	public Transform holdStone;
	public GameObject door;
	public GameObject gear;
	public GameObject stone;
	
	
	// Use this for initialization
	// Finds the playerInteract script attached to the player camera
	// Sets the animation to only run once
	void Start () {
		thePlayer = null;
		activate = false;
		scriptFind = GameObject.Find ("Main Camera").GetComponent<Camera>();;
		holding = scriptFind.GetComponent<playerInteract>();
		carry = false;
		holdStone = null;
		door = GameObject.Find ("Level 1 Door");
		gear = GameObject.Find ("3_gears");
		stone = GameObject.Find ("Orng_Stone_PlcHldr");
		door.animation ["caveDoorAnim"].wrapMode = WrapMode.ClampForever;
		gear.animation ["gearsAnim"].wrapMode = WrapMode.ClampForever;
		stone.animation ["oStoneInsert"].speed = 0.5f;
		stone.animation ["oStoneInsert"].wrapMode = WrapMode.ClampForever;
	}
	
	// If the door is set to open, play the animation
	void Update () {
		if (activate == true) {
			stone.animation.Play("oStoneInsert");
			if (stone.animation["oStoneInsert"].time >= stone.animation["oStoneInsert"].length){
				door.animation.Play();
				gear.animation.Play();
				stone.animation.Play();
			}
		}
	}
	
	// Recognizes the first person controller
	// Sees if the key is being held
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			thePlayer = other;
			carry = holding.isHolding;
		}
	}
	
	// If the first person controller is within the trigger range while holding the key
	//and mouse is clicked, set the door animation to true
	void OnTriggerStay(){
		if (thePlayer != null) {
			holdStone = holding.hitObject;
			if (carry) {
				if(Input.GetMouseButtonDown (0)){
					if(holdStone.gameObject.name == "Orange_stone"){
						GameObject.Find("Orange_stone").SetActive(false);
						activate = true;
					}
				}
			}
		}
	}
}