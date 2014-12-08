using UnityEngine;
using System.Collections;


public class PuzzlePiano : MonoBehaviour {

	private Vector3 startPos,endPos;
	private float currentLerpTime;
	public float moveDistance,lerpTime;
	public AudioClip clipSonido;

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
			//Da nullpointer exception cuando el raycast no apunta a nada,pero funciona correctamente,lo suyo seria añadir un try-catch
			if(hit.collider.name==this.gameObject.name){
				//Lerpeemos todos!!
				//reset when we press spacebar
				currentLerpTime = 0f;
				audio.PlayOneShot(clipSonido);
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

