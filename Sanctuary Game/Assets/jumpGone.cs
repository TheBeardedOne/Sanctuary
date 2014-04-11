using UnityEngine;
using System.Collections;

public class jumpGone : MonoBehaviour {

	void OnTriggerEnter(Collider Other){

	}

	void OnTriggerExit(){
		GameObject.Find ("Jump").SetActive (false);
	}
}
