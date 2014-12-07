﻿using UnityEngine;
//using System.Collections;

public class RoomTwoScript : ScriptableObject, IRoomScript {
	
	public enum time {PAST =0, PRESENT = 1, FUTURE = 2};
	private time current_time;
	
	public GameObject cuadro1, cuadro2, llave, muro, puertaSecreta;
	
	private bool solved;
	
	public RoomTwoScript(){
		
		current_time = time.PRESENT;
		solved = false;
	}
	
	public void passObjects(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e){
		cuadro1 = a;
		cuadro2 = b;
		llave = c;
		muro = d;
		puertaSecreta = e;
	}
	
	void IRoomScript.changeTime(int toTime){
		current_time = (time) toTime;
	}
	
	void IRoomScript.toPast(){
		llave.SetActive (false);
		cuadro1.SetActive (true);
		cuadro2.SetActive (false);
		muro.SetActive (false);
		puertaSecreta.SetActive (false);
	}
	
	void IRoomScript.toPresent(){
		muro.SetActive (true);
		llave.SetActive (true);
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

	}
	
	void IRoomScript.toFuture(){
		llave.SetActive (false);
		cuadro1.SetActive (false);
		cuadro2.SetActive (true);
		muro.SetActive (false);
		puertaSecreta.SetActive (false);
	}
	
	int IRoomScript.getCurrentTime(){
		return (int) current_time;
	}
	
	public time getCurrentTime(){
		return current_time;
	}

	void checkSolvedRoom(){
		if(cuadro1.GetComponent<cuadroStatus>().getSolved () && cuadro2.GetComponent<cuadroStatus>().getSolved ())
			solved = true;
		else solved = false;

	}
	

}
