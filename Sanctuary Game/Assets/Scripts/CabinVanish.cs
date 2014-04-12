using UnityEngine;
using System.Collections;

public class CabinVanish : MonoBehaviour {
	public Collider playerChar;
	public GameObject shack;
	public GameObject door;

	// Use this for initialization
	void Start () {
		playerChar = null;
		shack = GameObject.Find ("Cabin");
		door = GameObject.Find ("Door 1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider Other){
		Debug.Log ("in");
		if(Other.gameObject.tag == "Player"){
			playerChar = Other;
		}
	}

	void OnTriggerExit(Collider Other){
		Debug.Log ("exit");
		if(Other == playerChar){
			shack.SetActive (false);
			door.SetActive (false);
		}
	}
}
