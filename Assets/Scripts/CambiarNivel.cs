using UnityEngine;
using System.Collections;

public class CambiarNivel : MonoBehaviour {

	public string NombreScena;

	void OnTriggerStay(Collider col){
		if (col.gameObject.name == "Player") {
			Debug.Log ("Collider in");
			if (Input.GetKey ("e")) {
				Debug.Log("Input in");
				Application.LoadLevel (NombreScena);
			}
		}
	}
}
