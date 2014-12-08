using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	public Transform location;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		other.transform.position = location.position;
		if(collider.gameObject.CompareTag ("Arrastrable"))
			other.transform.localRotation.Set (-90.0f,0.0f,0.0f,0.0f);
	}
}
