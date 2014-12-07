using UnityEngine;
using System.Collections;

public class alcayataScript : MonoBehaviour {

	public Transform alcayata;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		if(other.collider.CompareTag ("Cuadro"))
		{	
			other.gameObject.GetComponent<cuadroStatus>().onPlace = true;
			other.gameObject.GetComponent<cuadroStatus>().SetAlcayataPos(alcayata);
		}

	}

	void OnTriggerExit(Collider other){
		if(other.collider.CompareTag ("Cuadro"))
		{
			other.gameObject.GetComponent<cuadroStatus>().onPlace = false;
			other.gameObject.GetComponent<cuadroStatus>().SetAlcayataPos(null);

		}

	}
}
