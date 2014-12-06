using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayTextAnimated : MonoBehaviour {

	private Text texto;
	private float letterDelay = 0.1f;
	private bool text_active;
	public string contenido;
	private float timePassed;

	public Canvas level_canvas;

	private int level;
	// Use this for initialization
	void Start () {
		if(level_canvas == null)
			level_canvas =  GameObject.Find ("Canvas").GetComponent<Canvas>();;
		texto = level_canvas.GetComponentInChildren<Text>();
		text_active = false;
		texto.text = null;
		//this.texto.enabled = false;
		level = 0;
		timePassed = letterDelay;

	}
	
	// Update is called once per frame
	void Update () {

		if(text_active)
		{
			//if(!this.enabled)
				//this.enabled = true;
			if(timePassed <= 0.0f && level < contenido.Length)
			{
				Debug.Log(level);
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
		text_active = false;
		this.texto.enabled = false;
		texto.text = null;
		level = 0;
	}


}
