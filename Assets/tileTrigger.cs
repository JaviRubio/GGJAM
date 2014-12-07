using UnityEngine;
using System.Collections;

public class tileTrigger : MonoBehaviour {

	private int x, y;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setCoordinates(int x, int y){
		this.x = x;
		this.y = y;
	}

	public Vector2 getCoordinates(){

		return new Vector2(x,y);
	}

	public int getX(){
		return this.x;
	}

	public int getY(){
		return this.y;
	}


	void OnTriggerEnter(Collider other){


	}
}
