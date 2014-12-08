using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml; 
using System.IO; 

public class DisplayTextAnimated : MonoBehaviour {

	public string nameNota;
	private Text texto;
	private float letterDelay = 0.05f;
	private bool text_active;
	private string contenido;
	private float timePassed;
	private Vector3 initial_pos;

	private bool soundPlayed;
	public Canvas level_canvas;

	private int level;
	// Use this for initialization
	void Start () {
		soundPlayed = false;
		if(level_canvas == null)
			level_canvas =  GameObject.Find ("CanvasNotas").GetComponent<Canvas>();
		texto = level_canvas.GetComponentInChildren<Text>();
		text_active = false;
		texto.text = null;
		initial_pos = texto.transform.position;
		//this.texto.enabled = false;
		level = 0;
		timePassed = letterDelay;
		contenido = LoadStringFromDisk (nameNota);

	}
	
	// Update is called once per frame
	void Update () {

		if(text_active)
		{
			//if(!this.enabled)
				//this.enabled = true;
			if(!soundPlayed)
				if(!this.GetComponent<AudioSource>().isPlaying)
				{
					this.GetComponent<AudioSource>().Play();
				soundPlayed = true;
				}


			if(timePassed <= 0.0f && level < contenido.Length)
			{

				texto.text += contenido[level];
				level ++;
				timePassed = letterDelay;
			}
			timePassed -= Time.deltaTime;

		}
	}

	public void setActive(){
		text_active = true;
		this.texto.enabled = true;
	}

	public void deactivate(){
		soundPlayed = false;
		text_active = false;
		this.texto.enabled = false;
		texto.text = null;
		level = 0;
		texto.transform.position = initial_pos;
	}

	public void goUp(){
		texto.transform.position += texto.transform.up;
	}

	public void goDown(){

		texto.transform.position -= texto.transform.up;
	}

	//Metodo que carga el contenido de un fichero en un string
	private string LoadStringFromDisk(string nameString) 
	{ 
		StreamReader r = File.OpenText("Assets\\Notas\\"+nameString); 
		string _info = r.ReadToEnd(); 
		r.Close(); 
		return _info;
	} 

}
