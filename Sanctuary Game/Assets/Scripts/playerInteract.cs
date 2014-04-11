using UnityEngine;
using System.Collections;

//Class which allows the player to grab and move objects in the environment
//!!!Must be attached to the Main Camera in First Person
public class playerInteract: MonoBehaviour {
	public Transform hitObject;
	public Transform tempHitObj;
	public bool isHolding;
	public GameObject fireSet;
	public bool isPaused;
	public bool inTrigger;

	// boolean for when the key items are collected
	public bool keyGet;
	public bool orngStoneGet;
	public bool blueStoneGet;
	public bool grnStoneGet;

	RaycastHit hit;
	
	
	// Use this for initialization
	void Start () {
		//Reset our variables when the game starts
		hitObject = null;
		tempHitObj = null;
		isHolding = false;
		isPaused = false;
		inTrigger = false;
		keyGet = false;
		orngStoneGet = false;
		blueStoneGet = false;
		grnStoneGet = false;
		fireSet = GameObject.Find("Flame");
		fireSet.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		//We don't want the raycast to hit the player, so we convert the player layer (8)
		//into a bitmask and pass that into the raycast later
		int layerMask = 1 << 8;
		//Reverses the bitmask so that we're hitting everything EXCEPT layer 8
		layerMask = ~layerMask;

		changeCrossHair ();

		if(Input.GetKeyDown (KeyCode.P)){
			if(!isPaused){
				isPaused = true;
				Time.timeScale = 0.0f;
				Debug.Log ("paused");
			}
			else if(isPaused){
				isPaused = false;
				Time.timeScale = 1.0f;
				Debug.Log ("false");
			}
		}


		if(Input.GetMouseButtonDown(0)){
			//If the player presses the grab key and is not holding an object, raycast to see if one is in range
			if(isHolding == false){
				Debug.DrawRay(transform.forward, hit.point, Color.green);
				Debug.DrawRay( transform.position, hit.point, Color.white, 5 );
				Debug.DrawRay( transform.position, hit.point+ transform.forward, Color.red, 5 );

				if(Physics.Raycast(transform.position, transform.forward, out hit, 3.0f)){
					Debug.Log ("entered raycast");
					tempHitObj = hit.collider.gameObject.transform;

					//If we hit a grabbable object, store a reference to that object if it has been tagged as Grabbable
					if(hit.collider.gameObject.tag == "GrabbableObject"){
						Debug.Log ("object hit");
						isHolding = true;
						hitObject = hit.collider.gameObject.transform;
					}
					if(hit.collider.gameObject.tag == "Fire"){
						Debug.Log ("fire");
						fireSet.SetActive (true);				
					}
					if(hit.collider.gameObject.tag == "letter"){
						GameObject.Find ("Letter").renderer.enabled = false;
						GameObject.Find ("Letter").SetActive(false);
						GameObject.Find ("UI_Letter").GetComponent<dfSprite>().IsVisible = true;
					}
				}
			}
			//If the grab key is pressed and an object is held, drop it
			else if (isHolding == true){
				isHolding = false;
			}
		}
		//If the object should be held, update it's position
		if(isHolding == true){

			// set collected boolean to true when the corresponding item is picked up
			switch(hitObject.gameObject.name){
			case "Key":
				keyGet = true;
				GameObject.Find("Button_4").GetComponent<dfButton> ().NormalBackgroundColor = Color.white;
				GameObject.Find("Button_4").GetComponent<guiButtonBehaviour>().pickedUpKey = true;
				break;
			case "Orange_stone":
				orngStoneGet = true;
				//hitObject = hit.collider.gameObject.transform;
				GameObject.Find("Button_1").GetComponent<dfButton> ().NormalBackgroundColor = Color.white;
				GameObject.Find("Button_1").GetComponent<guiButtonBehaviour>().pickedUpOrange = true;
				recallStoneOrange();
				break;
			case "Blue_stone":
				blueStoneGet = true;
				GameObject.Find("Button_2").GetComponent<dfButton> ().NormalBackgroundColor = Color.white;
				GameObject.Find("Button_2").GetComponent<guiButtonBehaviour>().pickedUpBlue = true;
				recallStoneBlue();
				break;
			case "Green_stone":
				grnStoneGet = true;
				GameObject.Find("Button_3").GetComponent<dfButton> ().NormalBackgroundColor = Color.white;
				GameObject.Find("Button_3").GetComponent<guiButtonBehaviour>().pickedUpGreen = true;
				recallStoneGreen();
				break;
			default:
				break;
			}

			hitObject.rigidbody.useGravity = false; 
			
			//Attach the object as a child to the camera
			hitObject.parent = this.transform;
			hitObject.Rotate (new Vector3 (90,0,0));
			
			//Change the final int to change distance from camera
			hitObject.transform.position = (this.transform.position + (this.transform.forward * 2.25f)) - new Vector3(0, 0.5f, 0); 
			hitObject.transform.rotation = this.transform.rotation; 
		}
		//If the object should not be held, detach from the camera and turn on gravity
		else if(hitObject != null && isHolding == false){ 
			hitObject.parent = null;
			hitObject.rigidbody.useGravity = true;
			hitObject = null;
		}
	}

	// FUNCTIONS TO RECALL STONE (This could be cleaner)
	void recallStoneOrange(){
		//Debug.Log("Entered FUNCTION Orange");
		isHolding = true;
		hitObject = GameObject.Find ("Orange_stone").gameObject.transform;

		hitObject.rigidbody.useGravity = false; 

		
		//Attach the object as a child to the camera
		hitObject.parent = this.transform;
		GameObject.Find ("Orange_stone").rigidbody.transform.Rotate (new Vector3 (90, 0, 0));
		
		//Change the final int to change distance from camera
		hitObject.transform.position = (this.transform.position + (this.transform.forward * 2.25f)) - new Vector3(0, 0.5f, 0); 
		hitObject.transform.rotation = this.transform.rotation; 

	}

	void recallStoneBlue(){
	//	Debug.Log("Entered FUNCTION Blue");
		isHolding = true;
		hitObject = GameObject.Find ("Blue_stone").gameObject.transform;
		
		hitObject.rigidbody.useGravity = false; 
		
		//Attach the object as a child to the camera
		hitObject.parent = this.transform;
		
		//Change the final int to change distance from camera
		hitObject.transform.position = (this.transform.position + (this.transform.forward * 2.25f)) - new Vector3(0, 0.5f, 0); 
		hitObject.transform.rotation = this.transform.rotation; 

	}

	void recallStoneGreen(){
	//	Debug.Log("Entered FUNCTION Green");
		isHolding = true;
		hitObject = GameObject.Find ("Green_stone").gameObject.transform;
		
		hitObject.rigidbody.useGravity = false; 
		
		//Attach the object as a child to the camera
		hitObject.parent = this.transform;
		
		//Change the final int to change distance from camera
		hitObject.transform.position = (this.transform.position + (this.transform.forward * 2.25f)) - new Vector3(0, 0.5f, 0); 
		hitObject.transform.rotation = this.transform.rotation; 
	}

	void recallStoneKey(){
	//	Debug.Log("Entered FUNCTION Key");
		isHolding = true;
		hitObject = GameObject.Find ("Key").gameObject.transform;
		
		hitObject.rigidbody.useGravity = false; 
		
		//Attach the object as a child to the camera
		hitObject.parent = this.transform;
		
		//Change the final int to change distance from camera
		hitObject.transform.position = (this.transform.position + (this.transform.forward * 2.25f)) - new Vector3(0, 0.5f, 0); 
		hitObject.transform.rotation = this.transform.rotation; 
	}

	void changeCrossHair(){
		/*if(Physics.Raycast(transform.position, transform.forward, out hit, 3.0f)){
			if(hit.collider.gameObject.tag == "Fire"){
				GameObject.Find ("Reticule").GetComponent<GUICrosshair> ().OriginalOn = false;
			}
			if(hit.collider.gameObject.tag == "letter"){
				GameObject.Find ("Reticule").GetComponent<GUICrosshair> ().OriginalOn = false;
			}
			if(hit.collider.gameObject.tag == "GrabbableObject" && isHolding == false){
				GameObject.Find ("Reticule").GetComponent<GUICrosshair> ().OriginalOn = false;
			}
		}
		else{GameObject.Find ("Reticule").GetComponent<GUICrosshair> ().OriginalOn = true;}*/
	}
}
