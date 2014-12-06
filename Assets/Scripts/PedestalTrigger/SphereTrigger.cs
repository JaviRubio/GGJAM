using UnityEngine;
using System.Collections;

public class SphereTrigger : MonoBehaviour {
	public GameObject controlledRoom;
	//private int sphereTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Bola"))
		{
			other.GetComponent<SphereState>().onPedestal(true, this.gameObject);
			//sphereTime = other.GetComponent<SphereState>().getTime ();
		}

	}

	void OnTriggerExit(Collider other){
		if(other.CompareTag ("Bola"))
			other.GetComponent<SphereState>().onPedestal(false,null);

	}

	public void activeControlledRoom(int time){
		controlledRoom.GetComponent<TimeState>().changeTime ( time);
	}
}
