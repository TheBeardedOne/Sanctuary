using UnityEngine;
using System.Collections;

public class Highlight_Mouseover : MonoBehaviour {

	private float blueMultiply = 3.50f;
	
	private float redGreenMultiply = 0.50f; 
	
	
	
	private Color originalColor;
	
	
	
	private void Start()
		
	{
		
		originalColor = gameObject.renderer.material.color;
		
	}
	
	
	
	void OnMouseEnter()
		
	{
		
		AddHighlight();
		
	}
	
	
	
	void OnMouseExit()
		
	{
		
		RemoveHighlight();
		
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
