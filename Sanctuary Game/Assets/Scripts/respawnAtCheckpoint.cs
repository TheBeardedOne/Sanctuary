using UnityEngine;
using System.Collections;

//Script that will bring the player back to a checkpoint if they happen to fall off the stage
public class respawnAtCheckpoint : MonoBehaviour {
	public Collider thePlayer;
	public Camera cam;
	public playerInteract holder;
	public float xpos;
	public float ypos;
	public float zpos;
	public OpenLvl2 caveOpened;
	public OpenLvl3 stairsRaised1;
	public OpenLvl3 stairsRaised2;
	public bool inCave;
	public bool pastCave;
	public Vector3 checkpoint;
	
	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		holder = cam.GetComponent<playerInteract>();
		thePlayer = null;
		caveOpened = GameObject.Find ("Orange_slot").GetComponent<OpenLvl2> ();
		stairsRaised1 = GameObject.Find ("Orange_slot_lvl2").GetComponent<OpenLvl3> ();
		stairsRaised2 = GameObject.Find ("Blue_slot").GetComponent<OpenLvl3> ();
		inCave = false;
		pastCave = false;
		xpos = -4;
		ypos = 50;
		zpos = 10;
	}
	
	void Update () {
		if(caveOpened.activate == true){
			inCave = true;
		}
		if(stairsRaised1.unlock && stairsRaised2.unlock){
			pastCave = true;
		}

		if(holder.grnStoneGet){
			xpos = -30.2f;
			ypos = 93;
			zpos = 630.3f;
		}
		else if (holder.orngStoneGet){
			if(inCave){
				xpos = -0.5f;
				ypos = 50;
				zpos = 138;
			}
			else if(pastCave){
				xpos = -0.7f;
				ypos = 55.5f;
				zpos = 367;
			}
			else{
				xpos = -56;
				ypos = 46;
				zpos = 26;
			}
		}
	}
	
	// Checks to see if the collider object that is entering is the character controller
	// If so, sets thePlayer variable to the character Controller
	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.tag == "Player") {
			thePlayer = Other;
			checkpoint = new Vector3 (xpos, ypos, zpos);
		}
		else if(holder.isHolding){
			thePlayer = GameObject.FindGameObjectWithTag("Player").collider;
		}
		else{
			thePlayer = null;
		}
	}
	
	// Respawns the character controller at the specified checkpoint
	void OnTriggerExit(Collider Other){
		if(thePlayer != null){
			thePlayer.transform.position = checkpoint;
		}
	}
}
