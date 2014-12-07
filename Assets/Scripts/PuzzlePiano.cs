using UnityEngine;
using System.Collections;


public class PuzzlePiano : MonoBehaviour {

	private Vector3 startPos,endPos;
	private float currentLerpTime;
	public float moveDistance,lerpTime;

	void Start(){
		startPos = transform.position;
		endPos = transform.position + transform.forward * moveDistance;
		currentLerpTime = lerpTime;
		}

	void Update(){
		if(Input.GetMouseButtonDown(0)){
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(ray,out hit);
			if(hit.collider.name==this.gameObject.name){
				//Lerpeemos todos!!
				//reset when we press spacebar
				currentLerpTime = 0f;
				}
			}
		//increment timer once per frame
		currentLerpTime += Time.deltaTime;
		if (currentLerpTime > lerpTime) {
			currentLerpTime = lerpTime;
		}
		
		//lerp!
		float perc = currentLerpTime / lerpTime;
		transform.position = Vector3.Lerp(startPos, endPos, Mathf.Sin (perc*4));
		//Debug.Log ("Tecla 1 pulsada");
		}
	}

