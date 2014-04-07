using UnityEngine;
using System.Collections;

public class lvl3Activation : MonoBehaviour {
	public Collider mover;
	public bool setAnim;
	public Camera scriptHolder;
	public playerInteract carrier;
	public bool hold;
	public Transform isCarrying;
	public GameObject plat1;
	public GameObject plat2;
	public GameObject bridge;
	public GameObject orngStone;
	public GameObject bluStone;
	public GameObject gStone;

	// Use this for initialization
	void Start () {
		mover = null;
		setAnim = false;
		scriptHolder = GameObject.Find ("Main Camera").GetComponent<Camera>();;
		carrier = scriptHolder.GetComponent<playerInteract>();
		hold = false;
		isCarrying = null;

		// Identifying the stones and moving platforms
		orngStone = GameObject.Find ("Orng_Stone_PlcHldr3");
		bluStone = GameObject.Find ("Blue_Stone_PlcHldr2");
		gStone = GameObject.Find ("Grn_Stone_PlcHldr");
		plat1 = GameObject.Find ("thirdPlat1");
		plat2 = GameObject.Find ("thirdPlat3");
		bridge = GameObject.Find ("Bridge_to_Drop");

		// set up whether the animation is to play only once or loop
		orngStone.animation ["oStoneInsert3"].wrapMode = WrapMode.ClampForever;
		bluStone.animation ["bStoneInsert2"].wrapMode = WrapMode.ClampForever;
		gStone.animation ["gStoneInsert"].wrapMode = WrapMode.ClampForever;
		plat1.animation ["firstStep"].wrapMode = WrapMode.Loop;
		plat2.animation ["secondStep"].wrapMode = WrapMode.Loop;
		bridge.animation ["toSanctuary"].wrapMode = WrapMode.ClampForever;
	}
	
	// Update is called once per frame
	void Update () {
		// checks if the animation is set to play
		if(setAnim){
			// identifies which slot the current object is
			// plays the corresponding animation
			// when the insertion animation is done playing, the corresponding platform animation is played
			if(this.gameObject.name == "Orange_slot_lvl3"){
				orngStone.animation.Play("oStoneInsert3");
				if(orngStone.animation["oStoneInsert3"].time >= orngStone.animation["oStoneInsert3"].length){
					plat1.animation.Play("firstStep");
				}
			}
			else if(this.gameObject.name == "Blue_slot_lvl3"){
				bluStone.animation.Play("bStoneInsert2");
				if(bluStone.animation["bStoneInsert2"].time >= bluStone.animation["bStoneInsert2"].length){
					plat2.animation.Play("secondStep");
				}
			}
			else if(this.gameObject.name == "Green_slot"){
				gStone.animation.Play("gStoneInsert");
				if(gStone.animation["gStoneInsert"].time >= gStone.animation["gStoneInsert"].length){
					bridge.animation.Play ("toSanctuary");
				}
			}
		}
	}

	// Recognizes the first person controller
	// Checks whether the player is holding something
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			mover = other;
			hold = carrier.isHolding;
		}
	}
	
	// If the first person controller is within the trigger range while holding the stones
	//and the mouse is clicked, set the animation to be played
	void OnTriggerStay(){
		if (mover != null) {
			isCarrying = carrier.hitObject;
			if (hold) {
				GameObject.Find("Reticule").GetComponent<GUICrosshair>().OriginalOn = false;
				if(Input.GetMouseButtonDown (0)){
					// checks to see if the slot matches with the correct stone
					// if so, play the insertion animation

					//**** Changed to un render instead of set to active - Jeremy ****
					if(this.gameObject.name == "Orange_slot_lvl3" && isCarrying.gameObject.name == "Orange_stone"){
						GameObject.Find("Orange_stone").renderer.enabled = false;
						setAnim = true;
					}
					else if(this.gameObject.name == "Blue_slot_lvl3" && isCarrying.gameObject.name == "Blue_stone"){
						GameObject.Find("Blue_stone").renderer.enabled = false;
						setAnim = true;
					}
					else if(this.gameObject.name == "Green_slot" && isCarrying.gameObject.name == "Green_stone"){
						GameObject.Find("Green_stone").renderer.enabled = false;
						setAnim = true;
					}
				}
			}
		}
	}

	void OnTriggerExit(){
		GameObject.Find ("Reticule").GetComponent<GUICrosshair> ().OriginalOn = true;
	}
}
