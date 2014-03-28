using UnityEngine;
using System.Collections;

public class OpenLvl3 : MonoBehaviour {
	public Collider playerController;
	public bool unlock;
	public Camera findHolding;
	public playerInteract holder;
	public bool holding;
	public Transform curHold;
	public GameObject bottom;
	public GameObject top;
	public GameObject oStone;
	public GameObject bStone;

	// Use this for initialization
	void Start () {
		playerController = null;
		unlock = false;
		findHolding = GameObject.Find ("Main Camera").GetComponent<Camera>();;
		holder = findHolding.GetComponent<playerInteract>();
		holding = false;
		curHold = null;
		bottom = GameObject.Find ("stairsBottomHalf");
		top = GameObject.Find ("stairsTopHalf");
		oStone = GameObject.Find ("Orng_Stone_PlcHldr2");
		bStone = GameObject.Find ("Blue_Stone_PlcHldr");
		bottom.animation ["Lvl2Exit1"].wrapMode = WrapMode.ClampForever;
		top.animation ["Lvl2Exit2"].wrapMode = WrapMode.ClampForever;
		oStone.animation ["oStoneInsert2"].wrapMode = WrapMode.ClampForever;
		bStone.animation ["bStoneInsert"].wrapMode = WrapMode.ClampForever;
	}
	
	// Update is called once per frame
	void Update () {
		if(unlock){
			if(this.gameObject.name == "Orange_slot_lvl2"){
				oStone.animation.Play("oStoneInsert2");
				if(oStone.animation["oStoneInsert2"].time >= oStone.animation["oStoneInsert2"].length){
					bottom.animation.Play("Lvl2Exit1");
				}
			}
			else if(this.gameObject.name == "Blue_slot"){
				bStone.animation.Play("bStoneInsert");
				if(bStone.animation["bStoneInsert"].time >= bStone.animation["bStoneInsert"].length){
					top.animation.Play("Lvl2Exit2");
				}
			}
		}
	}

	// Recognizes the first person controller
	// Sees if the key is being held
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			playerController = other;
			holding = holder.isHolding;
		}
	}
	
	// If the first person controller is within the trigger range while holding the key
	//and mouse is clicked, set the door animation to true
	void OnTriggerStay(){
		if (playerController != null) {
			curHold = holder.hitObject;
			if (curHold) {
				if(Input.GetMouseButtonDown (0)){
					if(this.gameObject.name == "Orange_slot_lvl2" && curHold.gameObject.name == "Orange_stone"){
						GameObject.Find("Orange_stone").SetActive(false);
						unlock = true;
					}
					else if(this.gameObject.name == "Blue_slot" && curHold.gameObject.name == "Blue_stone"){
						GameObject.Find("Blue_stone").SetActive(false);
						unlock = true;
					}
				}
			}
		}
	}
}