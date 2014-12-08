using UnityEngine;
using System.Collections;

public class CambiarNivel : MonoBehaviour {

	public string NombreScena;

	void OnTriggerStay(Collider col){
		if (col.gameObject.name == "PlayerDavid") {
			if (Input.GetKey ("e")) {
				Application.LoadLevel (NombreScena);
			}
		}
	}
}
