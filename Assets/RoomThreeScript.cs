﻿using UnityEngine;
using System.Collections;
using ThreeLines;

public class RoomThreeScript : ScriptableObject, IRoomScript {
	
	public enum time {PAST =0, PRESENT = 1, FUTURE = 2};
	private time current_time;
	public GameObject suelo, tiles;

	public Texture past, present;

	private H3Puzzle puzzleSolver;
	public RoomThreeScript(){
		puzzleSolver = new H3Puzzle();
		current_time = time.PRESENT;
	}
	

	void IRoomScript.changeTime(int toTime){
		current_time = (time) toTime;
	}
	
	void IRoomScript.toPast(){
		//suelo.GetComponent<Material>().SetTexture (past, Resources.Load (path, Texture));
		//suelo.renderer.material.SetTexture("_MainTexture", past);
		if(suelo.renderer.material.mainTexture != past)
		{
			suelo.renderer.material.mainTexture = past;
			tiles.SetActive (false);
		}
		//Debug.Log ("ASMDKSAM");
	}
	
	void IRoomScript.toPresent(){
		//suelo.renderer.material.SetTexture (present, Resources.Load (path,Texture));
		//suelo.renderer.material.SetTexture ("_MainTexture", present);
		if(suelo.renderer.material.mainTexture != present)
		{
			//suelo.renderer.material.mainTexture = present;
			tiles.SetActive(true);
		}
		
	}
	
	void IRoomScript.toFuture(){
		tiles.SetActive(false);
	}
	
	int IRoomScript.getCurrentTime(){
		return (int) current_time;
	}
	
	public time getCurrentTime(){
		return current_time;
	}
	
	public bool checkSolvedRoom(){
		return puzzleSolver.CheckIsSolved();

	}

	public bool passTile(int x, int y){

		return puzzleSolver.WalkTile(x,y);


	}
	
	
}
