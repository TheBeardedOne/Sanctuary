﻿    /// This script moves the character controller forward
    /// and sideways based on the arrow keys.
    /// It also jumps when pressing space.
    /// Make sure to attach a character controller to the same game object.
    /// It is recommended that you make only one call to Move or SimpleMove per frame.
     
     #pragma strict
     
    var speed : float = 6.0;
    var jumpSpeed : float = 8.0;
    var gravity : float = 20.0;
     
    private var moveDirection : Vector3 = Vector3.zero;
    // ======================================================================
    private var grabObj:boolean = false;
    private var hitObj:GameObject;
    private var hit : RaycastHit;
     
    function Update() {
     
     
    if(Input.GetMouseButtonDown(0)){
    
		//THIS needs to be verified first.     
   		 if(grabObj == true){
    		Debug.Log("Object detached");
    		hitObj.rigidbody.isKinematic = false;
    		grabObj = false;
    	}
    	
    	if(Physics.Raycast (gameObject.transform.position,gameObject.transform.forward, hit, 5)) {
    		Debug.Log("Raycast Hit");
    		if(hit.collider.gameObject && grabObj == false){
   				 Debug.Log("Object Verified");
   				 hitObj = hit.collider.gameObject;
   				 
   				
    			//hitObj.transform.position.y = gameObject.transform.position.y;
    			//hitObj.transform.position.z = gameObject.transform.position.z+0.01f;
    			hitObj.transform.parent = gameObject.transform;
    			hitObj.rigidbody.isKinematic = true;
    			 grabObj = true;
    		}
    	}
    }
    if(grabObj){
    //Moving object with player, 2 units in front of him cause we want to see it.
    
    }
    
    // =====================================================================
    var controller : CharacterController = GetComponent(CharacterController);
     
    if (controller.isGrounded) {
    // We are grounded, so recalculate
    // move direction directly from axes
    moveDirection = Vector3(Input.GetAxis("Horizontal"), 0,
    Input.GetAxis("Vertical"));
    moveDirection = transform.TransformDirection(moveDirection);
    moveDirection *= speed;
     
    if (Input.GetButton ("Jump")) {
    moveDirection.y = jumpSpeed;
    }
    }
     
    // Apply gravity
    moveDirection.y -= gravity * Time.deltaTime;
     
    // Move the controller
    controller.Move(moveDirection * Time.deltaTime);
    }