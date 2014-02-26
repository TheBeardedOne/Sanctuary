using UnityEngine;
using System.Collections;

//Script that will bring the player back to a checkpoint if they happen to fall off the stage
public class respawnAtCheckpoint : MonoBehaviour {
	public Collider thePlayer;
	public float xpos;
	public float ypos;
	public float zpos;
	public Vector3 checkpoint;

	// Use this for initialization
	void Start () {
		thePlayer = null;
	}
	
	// Update is called once per frame
	// Checks and defines the position for where the character controller is to be respawned
	void Update () {
		xpos = -4;
		ypos = 50;
		zpos = 10;
		checkpoint = new Vector3 (xpos, ypos, zpos);
	}

	// Checks to see if the collider object that is entering is the character controller
	// If so, sets thePlayer variable to the character Controller
	void OnTriggerEnter(Collider Other){
		if (Other.gameObject.tag == "Player") {
			thePlayer = Other;
		}
	}

	// Respawns the character controller at the specified checkpoint
	void OnTriggerExit(Collider Other){
		thePlayer.transform.position = checkpoint;
	}
}
