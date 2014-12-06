using UnityEngine;
using System.Collections;

public class TimeState : MonoBehaviour {

	/*public enum time {PAST =0, PRESENT = 1, FUTURE = 2};
	private time current_time;*/
	//public GameObject boquete, mesa;

	public IRoomScript roomScript;

	// Use this for initialization
	void Start () {
		/*current_time = time.PRESENT;
		GameObject.Find ("Boquete").SetActive (false);*/
		roomScript = (IRoomScript) gameObject.GetComponent(typeof(IRoomScript));
	}
	
	// Update is called once per frame
	void Update () {
	
		if(roomScript != null)
		{
			switch(roomScript.getCurrentTime())
			{
			case(0):
				roomScript.toPast();
				break;
			case(1):
				roomScript.toPresent();
				break;
			case(2):
				roomScript.toFuture();
				break;
			}
		}

	}

	/*public time getCurrentTime(){
		return current_time;
	}*/

	public void changeTime(int toTime){
		roomScript.changeTime (toTime);
	}

	/*private void toPast(){
		boquete.SetActive(true);
		mesa.SetActive (true);
		/*GameObject.Find ("Boquete").SetActive(true);
		GameObject.FindGameObjectWithTag("Mesa").SetActive (true);
	}

	private void toPresent(){
		boquete.SetActive (false);
		mesa.SetActive(true);
		/*GameObject.Find ("Boquete").SetActive (false);
		GameObject.FindGameObjectWithTag("Mesa").SetActive (true);
	}

	private void toFuture(){
		boquete.SetActive(false);
		mesa.SetActive (false);
		/*GameObject.Find ("Boquete").SetActive (false);
		GameObject.FindGameObjectWithTag("Mesa").SetActive (false);*/
	//}
	


}
