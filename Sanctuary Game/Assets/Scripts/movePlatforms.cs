using UnityEngine;
using System.Collections;

public class movePlatforms : MonoBehaviour {

	// Sets animations to continously loop
	void Start () {
		this.animation.wrapMode = WrapMode.Loop;
		animation ["horPlatform"].speed = 0.5f;
		animation ["horPlatform2"].speed = 0.8f;
		animation ["vertPlatform"].speed = 0.8f;
		animation ["vertPlatform2"].speed = 0.8f;
	}
	
	// Play the animations
	void Update () {
		this.animation.Play();
	}
}
