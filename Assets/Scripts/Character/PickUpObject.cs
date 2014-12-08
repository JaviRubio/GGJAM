using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpObject : MonoBehaviour {

	public GameObject playerCam;
	
	private Ray playerAim;
	private GameObject objectHeld;
	private bool isObjectHeld;

	/**
	 * 
	 * states describing what the character is doing anytime
	 */
	private enum states {MOVING = 0, READING = 1, DRAG_OBJECT = 2};
	private states current_state;

	//private float inputLag = 1.0f;
	
	void Start () {
		isObjectHeld = false;
		objectHeld = null;
		current_state = states.MOVING;
	}
	
	void Update () {
		if(Input.GetKey (KeyCode.Escape))
			Application.Quit ();
		switch(current_state)
		{
		case(states.MOVING):
			if(Input.GetKeyUp(KeyCode.E)){
				if(!isObjectHeld){
					interactWithObject();
				} else {
					//holdObject();
					dropObject();
				}
			}
			if(isObjectHeld && current_state == states.MOVING)
			{
				holdObject();
				if(objectHeld.CompareTag("Bola"))
				{
					if(Input.GetKeyUp (KeyCode.R))
					{
						objectHeld.GetComponent<SphereState>().setTime (0);
					}
					if(Input.GetKeyUp (KeyCode.T))
					{
						objectHeld.GetComponent<SphereState>().setTime (1);
					}
					if(Input.GetKeyUp (KeyCode.Y))
					{
						objectHeld.GetComponent<SphereState>().setTime (2);
					}
				}
			}
			break;
		case(states.READING):
			this.GetComponent<CharacterMotor>().enabled = false;
			if(Input.GetKeyUp(KeyCode.E)){
				if (current_state == states.READING)
				{
					objectHeld.GetComponent<DisplayTextAnimated>().deactivate ();
					
				}
				this.current_state = states.MOVING;
				this.GetComponent<CharacterMotor>().enabled = true;
			}
			
			if(Input.GetKey (KeyCode.W)){
				objectHeld.GetComponent<DisplayTextAnimated>().goUp();
				
			}
			if(Input.GetKey(KeyCode.S)){
				objectHeld.GetComponent<DisplayTextAnimated>().goDown();
			}

		break;
		case(states.DRAG_OBJECT):
			if(Input.GetKeyUp(KeyCode.E)){
				this.GetComponent<CharacterMotor>().enabled = true;
				this.GetComponent<FPSInputController>().enabled = true;
				current_state = states.MOVING;
				isObjectHeld = false;
				objectHeld = null;
			}
			else{
				if(Input.GetKey(KeyCode.W)){
					//dragObject (transform.forward);
					dragObject (-objectHeld.transform.up);
				}
				if(Input.GetKey (KeyCode.S)){
					dragObject (objectHeld.transform.up);
				}

				if(Input.GetKey (KeyCode.A)){
					dragObject (-transform.right);
				}

				if(Input.GetKey (KeyCode.D)){
					dragObject (transform.right);
				}
			}
			break;

		}
	}


		/*if(Input.GetKeyUp(KeyCode.E) && isObjectHeld){
			isObjectHeld = false;
			objectHeld.rigidbody.useGravity = true;
		}*/
	
	private void interactWithObject(){
		Ray playerAim = playerCam.camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;

		if(Physics.SphereCast (playerAim,  0.5f, out hit, 1.0f))
		{
			//Physics.Raycast (playerAim, out hit);

			if(current_state == states.MOVING)
			{
				if(hit.collider.gameObject.tag.Equals("Bola") )
				{
					isObjectHeld = true;
					objectHeld = hit.collider.gameObject;
					objectHeld.rigidbody.useGravity = false;
					if(hit.collider.gameObject.tag.Equals("Bola"))
						objectHeld.GetComponent<SphereState>().pickFromPedestal();
					//objectHeld.transform.position = this.transform.position + this.transform.forward;
				}
				if( hit.collider.gameObject.tag.Equals ("Arrastrable"))
				{
					current_state = states.DRAG_OBJECT;
					isObjectHeld = true;
					objectHeld = hit.collider.gameObject;
					this.GetComponent<CharacterMotor>().enabled = false;
					this.GetComponent<FPSInputController>().enabled = false;


				}
				if(hit.collider.gameObject.tag.Equals ("Nota"))
				{
					objectHeld = hit.collider.gameObject;
					objectHeld.GetComponent<DisplayTextAnimated>().setActive ();
					this.current_state = states.READING;
				}

				if(hit.collider.gameObject.CompareTag ("Cuadro"))
				{
					objectHeld = hit.collider.gameObject;
					isObjectHeld = true;
					objectHeld.rigidbody.useGravity = false;
				}
				if(hit.collider.gameObject.CompareTag ("InterruptorH1"))
				{
					hit.collider.GetComponent<InterruptorScript>().solved = true;
				}
			}
			/*if(hit.collider.gameObject.CompareTag ("TioDelFinal"))
			{
				objectHeld = hit.collider.gameObject;

			}*/
		}

	}
	
	private void holdObject(){
		Ray playerAim = playerCam.camera.ViewportPointToRay(new Vector3(0.5f, 0.2f, 0));
		objectHeld.transform.position = playerCam.transform.position + playerAim.direction * 0.5f;
		objectHeld.transform.rotation = Quaternion.identity;
		//objectHeld.transform.rotation = playerCam.transform.rotation;
		//Vector3 nextPos = playerCam.transform.position + playerAim.direction * 2;
		//Vector3 currPos = objectHeld.transform.position;
		
		//objectHeld.rigidbody.velocity = (nextPos - currPos) * 10;
	}

	private void dropObject(){
		switch(objectHeld.tag)
		{
		case("Bola"):
			if(objectHeld.GetComponent<SphereState>().onPlace)
			{
				objectHeld.GetComponent<SphereState>().placeOnPedestal();
				objectHeld = null;
				
			}
			else objectHeld.rigidbody.useGravity = true;
			isObjectHeld = false;
			break;
		case("Cuadro"):
			if(objectHeld.GetComponent<cuadroStatus>().onPlace)
			{
				objectHeld.GetComponent<cuadroStatus>().placeOnAlcayata();
			}
			else{
				objectHeld.rigidbody.useGravity = true;
				objectHeld.rigidbody.isKinematic = false;
			}
			isObjectHeld = false;
			objectHeld = null;
			break;
		}
			/*
		if(!objectHeld.CompareTag ("Bola"))
		{
			objectHeld.rigidbody.useGravity = true;
			isObjectHeld = false;
			objectHeld = null;
			}
		else{
			if(objectHeld.GetComponent<SphereState>().onPlace)
			{
				objectHeld.GetComponent<SphereState>().placeOnPedestal();
				objectHeld = null;

			}
			else objectHeld.rigidbody.useGravity = true;
			isObjectHeld = false;
		}*/
	}

	private void dragObject(Vector3 moveDir){
		Vector3 dir = moveDir * Time.deltaTime;
		objectHeld.rigidbody.MovePosition(objectHeld.rigidbody.position + dir);
		Vector3 gravity = -Vector3.up;
		this.GetComponent<CharacterController>().Move (dir + gravity);
		//objectHeld.rigidbody.velocity = dir;
		
		//objectHeld.transform.position += dir;
		//this.transform.position += dir;


	}
}

