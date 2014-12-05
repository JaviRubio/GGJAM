using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUpObject : MonoBehaviour {

	public GameObject playerCam;
	
	private Ray playerAim;
	private GameObject objectHeld;
	private bool isObjectHeld;

	//private float inputLag = 1.0f;
	
	void Start () {
		isObjectHeld = false;
		objectHeld = null;
	}
	
	void Update () {
		if(Input.GetKeyUp(KeyCode.E)){
			if(!isObjectHeld){
				tryPickObject();
			} else {
				//holdObject();
				dropObject();
			}
		}
		if(isObjectHeld)
		{
			holdObject();
		}


		/*if(Input.GetKeyUp(KeyCode.E) && isObjectHeld){
			isObjectHeld = false;
			objectHeld.rigidbody.useGravity = true;
		}*/
	}
	
	private void tryPickObject(){
		Ray playerAim = playerCam.camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;
		
		Physics.Raycast (playerAim, out hit);

		if(hit.collider.gameObject.tag.Equals("Bola"))
		{
			isObjectHeld = true;
			objectHeld = hit.collider.gameObject;
			objectHeld.rigidbody.useGravity = false;
			//objectHeld.transform.position = this.transform.position + this.transform.forward;
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

