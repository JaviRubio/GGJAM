using UnityEngine;
using System.Collections;

public class ChangerScriptRoomTwo : MonoBehaviour {

	IRoomScript changer;

	public enum time {PAST =0, PRESENT = 1, FUTURE = 2};
	private time current_time;
	

	// Use this for initialization
	void Start () {
		changer = new RoomTwoScript();
		//changer.passObjects(cuadro1, cuadro2, llave, muro, puertaSecreta);
		current_time = time.PRESENT;
	}
	
	// Update is called once per frame
	void Update () {
		if(current_time != (time) changer.getCurrentTime ())
		{
			switch(changer.getCurrentTime())
			{
			case(0):
				changer.toPast();
				break;
			case(1):
				changer.toPresent();
				break;
			case(2):
				changer.toFuture();
				break;
			}
		}
	}
}
