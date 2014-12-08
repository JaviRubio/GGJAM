using UnityEngine;
using System.Collections;

public class tableRespawn : MonoBehaviour {

	private Transform startT;
	// Use this for initialization
	void Start () {
		startT = this.transform;
	}

	public void respawn(){
		this.transform.position = startT.position + new Vector3(0.0f, 1.0f, 0.0f);
		this.transform.rotation = startT.rotation;
	}
}
