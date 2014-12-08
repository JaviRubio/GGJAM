using UnityEngine;
//using System.Collections;

public class ScriptHabitacionDos : ScriptableObject, IRoomScript {
	
	public enum time {PAST =0, PRESENT = 1, FUTURE = 2};
	private time current_time;
	
	public GameObject cuadro1, cuadro2, muro, puertaSecreta;

	public GameObject[] notasPresente, notasPasado, notasFuturo;

	public GameObject openDoor;
	private bool solved;
	
	public ScriptHabitacionDos(){
		
		current_time = time.PRESENT;
		solved = false;
	}
	
	void IRoomScript.changeTime(int toTime){
		current_time = (time) toTime;
	}
	
	void IRoomScript.toPast(){

		cuadro1.SetActive (true);
		cuadro2.SetActive (false);
		muro.SetActive (false);
		puertaSecreta.SetActive (false);
		foreach(GameObject i in notasPresente)
			i.SetActive (false);
		foreach(GameObject i in notasFuturo)
			i.SetActive(false);
		foreach(GameObject i  in notasPasado)
			i.SetActive(true);

		openDoor.SetActive(false);
	}
	
	void IRoomScript.toPresent(){
		openDoor.SetActive(true);
		muro.SetActive (true);

		if(!solved)
		{
			checkSolvedRoom();
			puertaSecreta.SetActive (true);
			
		}
		else{
			puertaSecreta.SetActive (false);
		}
		cuadro1.SetActive(true);
		cuadro2.SetActive (true);
		foreach(GameObject i in notasPresente)
			i.SetActive (true);
		foreach(GameObject i in notasFuturo)
			i.SetActive(false);
		foreach(GameObject i  in notasPasado)
			i.SetActive(false);
		
	}
	
	void IRoomScript.toFuture(){
		openDoor.SetActive (false);

		cuadro1.SetActive (false);
		cuadro2.SetActive (true);
		muro.SetActive (false);
		puertaSecreta.SetActive (false);
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
	
	void checkSolvedRoom(){
		if(cuadro1.GetComponent<cuadroStatus>().getSolved () && cuadro2.GetComponent<cuadroStatus>().getSolved ())
		{
			solved = true;
			openDoor.GetComponent<InterruptorScript>().solved = true;
		}
		else solved = false;
		
	}
	
	
}
