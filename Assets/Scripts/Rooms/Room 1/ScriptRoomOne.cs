using UnityEngine;
//using System.Collections;

public class ScriptRoomOne : ScriptableObject, IRoomScript {

	public enum time {PAST =0, PRESENT = 1, FUTURE = 2};
	private time current_time;
	public GameObject boquete, mesa;

	void IRoomScript.changeTime(int toTime){
		current_time = (time) toTime;
	}
	
	void IRoomScript.toPast(){
		boquete.SetActive(true);
		mesa.SetActive (true);
		/*GameObject.Find ("Boquete").SetActive(true);
		GameObject.FindGameObjectWithTag("Mesa").SetActive (true);*/
	}
	
	void IRoomScript.toPresent(){
		boquete.SetActive (false);
		mesa.SetActive(true);
		/*GameObject.Find ("Boquete").SetActive (false);
		GameObject.FindGameObjectWithTag("Mesa").SetActive (true);*/
	}
	
	void IRoomScript.toFuture(){
		boquete.SetActive(false);
		mesa.SetActive (false);
		/*GameObject.Find ("Boquete").SetActive (false);
		GameObject.FindGameObjectWithTag("Mesa").SetActive (false);*/
	}

	int IRoomScript.getCurrentTime(){
		return (int) current_time;
	}

	public time getCurrentTime(){
		return current_time;
	}


	/*
	void Start () {
		current_time = time.PRESENT;
		GameObject.Find ("Boquete").SetActive (false);
	}


	// Update is called once per frame
	void Update () {
		
		switch(current_time)
		{
		case(time.PAST):
			toPast();
			break;
		case(time.PRESENT):
			toPresent();
			break;
		case(time.FUTURE):
			toFuture();
			break;
		}
		
	}
	
	public time getCurrentTime(){
		return current_time;
	}
	*/


}