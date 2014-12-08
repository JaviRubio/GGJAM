using UnityEngine;
using System.Collections;

public class P2TimeScript : ScriptableObject, IRoomScript {
	
	public enum time {PAST =0, PRESENT = 1, FUTURE = 2};
	private time current_time;
	
	public GameObject[] notasPresente, notasPasado, notasFuturo;
	
	public P2TimeScript(){
		
		current_time = time.PRESENT;
	}
	
	void IRoomScript.changeTime(int toTime){
		current_time = (time) toTime;
	}
	
	void IRoomScript.toPast(){
		foreach(GameObject i in notasPresente)
			i.SetActive (false);
		foreach(GameObject i in notasFuturo)
			i.SetActive(false);
		foreach(GameObject i  in notasPasado)
			i.SetActive(true);
	}
	
	void IRoomScript.toPresent(){
		foreach(GameObject i in notasPresente)
			i.SetActive (true);
		foreach(GameObject i in notasFuturo)
			i.SetActive(false);
		foreach(GameObject i  in notasPasado)
			i.SetActive(false);
	}
	
	void IRoomScript.toFuture(){
		foreach(GameObject i in notasPresente)
			i.SetActive (false);
		foreach(GameObject i in notasFuturo)
			i.SetActive(true);
		foreach(GameObject i  in notasPasado)
			i.SetActive(false);
	}
	
	int IRoomScript.getCurrentTime(){
		return (int) current_time;
	}
	
	public time getCurrentTime(){
		return current_time;
	}
	
}
