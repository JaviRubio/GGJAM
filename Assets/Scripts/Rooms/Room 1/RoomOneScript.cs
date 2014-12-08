using UnityEngine;
//using System.Collections;

public class RoomOneScript : ScriptableObject, IRoomScript {
	
	public enum time {PAST =0, PRESENT = 1, FUTURE = 2};
	private time current_time;
	public GameObject boquete, mesa;

	public GameObject[] notasFuturo, notasPresnte, notasPasado;

	public GameObject openDoor;
	
	public RoomOneScript(){
		current_time = time.PRESENT;
	}
	
	void IRoomScript.changeTime(int toTime){
		current_time = (time) toTime;
	}
	
	void IRoomScript.toPast(){
		boquete.SetActive(true);
		mesa.SetActive (true);
		foreach(GameObject i in notasPresnte)
			i.SetActive (false);
		foreach(GameObject i in notasFuturo)
			i.SetActive(false);
		foreach(GameObject i  in notasPasado)
			i.SetActive(true);

		openDoor.SetActive (false);
		/*GameObject.Find ("Boquete").SetActive(true);
		GameObject.FindGameObjectWithTag("Mesa").SetActive (true);*/
	}
	
	void IRoomScript.toPresent(){
		boquete.SetActive (false);
		mesa.SetActive(true);
		foreach(GameObject i in notasPresnte)
			i.SetActive (true);
		foreach(GameObject i in notasFuturo)
			i.SetActive(false);
		foreach(GameObject i  in notasPasado)
			i.SetActive(false);

		openDoor.SetActive (true);
		/*GameObject.Find ("Boquete").SetActive (false);
		GameObject.FindGameObjectWithTag("Mesa").SetActive (true);*/
	}
	
	void IRoomScript.toFuture(){
		boquete.SetActive(false);
		mesa.SetActive (true);
		foreach(GameObject i in notasPresnte)
			i.SetActive (false);
		foreach(GameObject i in notasFuturo)
			i.SetActive(true);
		foreach(GameObject i  in notasPasado)
			i.SetActive(false);

		openDoor.SetActive (false);
		/*GameObject.Find ("Boquete").SetActive (false);
		GameObject.FindGameObjectWithTag("Mesa").SetActive (false);*/
	}
	
	int IRoomScript.getCurrentTime(){
		return (int) current_time;
	}
	
	public time getCurrentTime(){
		return current_time;
	}

	
}