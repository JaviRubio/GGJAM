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
	private enum states {MOVING = 0, READING = 1};
	private states current_state;

	//private float inputLag = 1.0f;
	
	void Start () {
		isObjectHeld = false;
		objectHeld = null;
		current_state = states.MOVING;
	}
	
	void Update () {

		if(current_state != states.READING)
		{
			if(Input.GetKeyUp(KeyCode.E)){
				if(!isObjectHeld){
					interactWithObject();
				} else {
					//holdObject();
					dropObject();
				}
			}
			if(isObjectHeld)
			{
				holdObject();
			}
		}
		else{
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

		}
	}


		/*if(Input.GetKeyUp(KeyCode.E) && isObjectHeld){
			isObjectHeld = false;
			objectHeld.rigidbody.useGravity = true;
		}*/
	
	private void interactWithObject(){
		Ray playerAim = playerCam.camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;
		
		Physics.Raycast (playerAim, out hit);

		if(current_state == states.MOVING)
		{
			if(hit.collider.gameObject.tag.Equals("Bola"))
			{
				isObjectHeld = true;
				objectHeld = hit.collider.gameObject;
				objectHeld.rigidbody.useGravity = false;
				//objectHeld.transform.position = this.transform.position + this.transform.forward;
			}
			if(hit.collider.gameObject.tag.Equals ("Nota"))
			{
				objectHeld = hit.collider.gameObject;
				objectHeld.GetComponent<DisplayTextAnimated>().setActive ();
				this.current_state = states.READING;
			}
		}

	}
	
	private void holdObject(){
		Ray playerAim = playerCam.camera.ViewportPointToRay(new Vector3(0.5f, 0.2f, 0));
		objectHeld.transform.position = playerCam.transform.position + playerAim.direction * 0.5f;
		objectHeld.transform.rotation = playerCam.transform.rotation;
		//Vector3 nextPos = playerCam.transform.position + playerAim.direction * 2;
		//Vector3 currPos = objectHeld.transform.position;
		
		//objectHeld.rigidbody.velocity = (nextPos - currPos) * 10;
	}

	private void dropObject(){
		objectHeld.rigidbody.useGravity = true;
		isObjectHeld = false;
	}


}

