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
	public OpenLvl2 isOpened;
	public bool inCave;
	public bool pastCave;
	public Vector3 checkpoint;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera").GetComponent<Camera>();
		holder = cam.GetComponent<playerInteract>();
		thePlayer = null;
		isOpened = GameObject.Find ("Orange_slot").GetComponent<OpenLvl2> ();
		inCave = false;
		pastCave = false;
	}

	void Update () {
		if(isOpened.activate == true){
			inCave = true;
		}
	}

	// Checks to see if the collider object that is entering is the character controller
	// If so, sets thePlayer variable to the character Controller
	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.tag == "Player") {
			thePlayer = Other;
			if (holder.isHolding && holder.hitObject.name == "Orange_stone") {
				xpos = -56;
				ypos = 46;
				zpos = 26;
			}
			else if(inCave){
				xpos = -0.5f;
				ypos = 45;
				zpos = 138;
			}
			else {
				xpos = -4;
				ypos = 50;
				zpos = 10;
			}
			checkpoint = new Vector3 (xpos, ypos, zpos);
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
