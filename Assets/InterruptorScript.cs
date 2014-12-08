using UnityEngine;
using System.Collections;

public class InterruptorScript : MonoBehaviour {

	public bool solved = false;
	private bool Open = false;

	public GameObject paredPasillo;
	void Update(){
		if(!solved)
		{
			if(!Open)
			{
				paredPasillo.SetActive (false);
				Open = true;
				if(!this.GetComponent<AudioSource>().isPlaying)
					this.GetComponent<AudioSource>().Play ();
			}
		}
	}
	
}
