using UnityEngine;
using System.Collections;

public class Highlight_Mouseover : MonoBehaviour {

	private float blueMultiply = 3.50f;
	
	private float redGreenMultiply = 0.50f; 
	
	private Color originalColor;

	public bool set;
	
	private void Start()
		
	{
		set = true;
		originalColor = gameObject.renderer.material.color;
	}
	
	
	
	void OnMouseEnter()
		
	{
		if(set){
			AddHighlight();
			GameObject.Find ("Reticule").GetComponent<GUICrosshair> ().OriginalOn = false;
		}
	}
	
	
	
	void OnMouseExit()
		
	{
		
		RemoveHighlight();
		GameObject.Find ("Reticule").GetComponent<GUICrosshair> ().OriginalOn = true;
	}
	
	
	
	private void  AddHighlight() 
		
	{
		
		float red = originalColor.r * redGreenMultiply;
		
		float blue = originalColor.b * blueMultiply;
		
		float green = originalColor.g * redGreenMultiply;
		
		
		
		gameObject.renderer.material.color = new Color(red, green, blue);
		
	}
	
	
	
	private void RemoveHighlight()
		
	{
		
		gameObject.renderer.material.color = originalColor;
		
	}
}
