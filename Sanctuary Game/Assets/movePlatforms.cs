using UnityEngine;
using System.Collections;

public class movePlatforms : MonoBehaviour {

	// Sets animations to continously loop
	void Start () {
		this.animation.wrapMode = WrapMode.Loop;
	}
	
	// Play the animations
	void Update () {
		this.animation.Play();
	}
}
