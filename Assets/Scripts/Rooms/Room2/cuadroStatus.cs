using UnityEngine;
using System.Collections;

public class cuadroStatus : MonoBehaviour {

	public bool onPlace;
	private Transform alcayata;
	private bool solved;
	// Use this for initialization
	void Start () {
		onPlace = false;
		solved = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetAlcayataPos(Transform t){
		alcayata = t;
	}

	public void placeOnAlcayata(){
		transform.position = alcayata.position;
		transform.rotation = Quaternion.identity;
		transform.Rotate (transform.up, 90);
		rigidbody.isKinematic = true;
		solved = true;
	}

	public bool getSolved(){
		return solved;
	}
}
