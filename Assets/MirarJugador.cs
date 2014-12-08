using UnityEngine;
using System.Collections;

public class MirarJugador : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find("PlayerDavid").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			transform.LookAt(target);
			//this.transform.eulerAngles.z=0;
			//this.transform.eulerAngles.x=0;
		}
	}
}
