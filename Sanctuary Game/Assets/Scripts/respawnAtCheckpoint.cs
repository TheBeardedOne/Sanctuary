using UnityEngine;
using System.Collections;

//Script that will bring the player back to a checkpoint if they happen to fall off the stage
public class respawnAtCheckpoint : MonoBehaviour {
	public Collider thePlayer;
	public Camera cam;
	public playerInteract holder;

	// position variables for the checkpoints
	public float xpos;
	public float ypos;
	public float zpos;

	// conditions for which checkpoint to use
	public OpenLvl2 caveOpened;
	public OpenLvl3 stairsRaised1;
	public OpenLvl3 stairsRaised2;
	public bool inCave;
	public bool pastCave;

	public Vector3 checkpoint;
	
	// Use this for initialization
	void Start () {
		// initialize all objects and scripts
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		holder = cam.GetComponent<playerInteract>();
		thePlayer = null;
		caveOpened = GameObject.Find ("Orange_slot").GetComponent<OpenLvl2> ();
		stairsRaised1 = GameObject.Find ("Orange_slot_lvl2").GetComponent<OpenLvl3> ();
		stairsRaised2 = GameObject.Find ("Blue_slot").GetComponent<OpenLvl3> ();
		inCave = false;
		pastCave = false;

		// default checkpoint
		xpos = -0.04f;
		ypos = 45;
		zpos = 9.8f;
	}
	
	void Update () {
		// checks if the player has opened the door to level 2 (cave)
		if(caveOpened.activate == true){
			inCave = true;
		}
		// checks if the player has gotten out of the cave
		if(stairsRaised1.unlock && stairsRaised2.unlock){
			pastCave = true;
		}

		// if the player has the green stone collect, set respawn to last checkpoint
		if(holder.grnStoneGet){
			xpos = 10.5f;
			ypos = 52.8f;
			zpos = 286.2f;
		}
		// checks if the player has collect the first stone (orange)
		else if (holder.orngStoneGet){
			// sets checkpoint at start of level 3
			if(pastCave){
				xpos = -2.9f;
				ypos = 47.6f;
				zpos = 230.3f;
			}
			// sets checkpoint to the entrance of the cave
			else if(inCave){
				xpos = -0.5f;
				ypos = 50;
				zpos = 138;
			}
			// first checkpoint at where the orange stone is collected
			else{
				xpos = -56;
				ypos = 46;
				zpos = 26;
			}
		}

		checkpoint = new Vector3 (xpos, ypos, zpos);
	}
	
	// Checks to see if the collider object that is entering is the character controller
	// If so, sets thePlayer variable to the character Controller
	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.tag == "Player") {
			Debug.Log("TESSSSSSSSSSSSSST");
			thePlayer = Other;
		}
		// if something else enters the trigger first, check if the player is holding the item
		else if(Other.gameObject.tag != "Player"){
			if(holder.isHolding){
				thePlayer = GameObject.FindGameObjectWithTag("Player").collider;
			}
			else{thePlayer = null;}
		}
		else{thePlayer = GameObject.FindGameObjectWithTag("Player").collider;}
		//Accesses other script on "fadeTrigger" and clears the fade
		GameObject.Find ("fadeTrigger").GetComponent<FadeToDeath> ().dead = false;

	}
	
	// Respawns the character controller at the specified checkpoint
	void OnTriggerExit(Collider Other){
		if(thePlayer != null){
			audio.Play ();
			thePlayer.transform.position = checkpoint;
		}
		else if(holder.isHolding){
			if(holder.hitObject.gameObject.name != Other.gameObject.name){
				audio.Play ();
				GameObject.FindGameObjectWithTag("Player").transform.position = checkpoint;
			}
		}
	}
}
