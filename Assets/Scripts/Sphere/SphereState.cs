using UnityEngine;
using System.Collections;

public class SphereState : MonoBehaviour {

	private enum time {PAST = 0, PRESENT = 1, FUTURE = 2};
	private time current_time;
	public bool onPlace;
	private bool changingTime;

	public Texture present, past, future;

	private GameObject pedestalPos;
	// Use this for initialization
	void Start () {
		changingTime = false;
		onPlace = false;
		current_time = time.PRESENT;
	}
	
	// Update is called once per frame
	void Update () {
		switch(current_time)
		{
			case(time.PAST):
			toPast();
			break;
			case(time.PRESENT):
			toPresent();
			break;
			case(time.FUTURE):
			toFuture();
			break;
		default:
			break;
		}
		if(changingTime)
		{
			this.transform.Rotate (transform.up, 1000.0f * Time.deltaTime);
			if(!this.GetComponent<AudioSource>().isPlaying)
				this.GetComponent<AudioSource>().Play();

		}
		else this.GetComponent<AudioSource>().Stop();

		/*if(rotating)
			this.transform.Rotate(this.transform.up, Time.deltaTime * 20);*/
		/*if(this.transform.position == pedestalPos)
			this.transform.Rotate(this.transform.up, Time.deltaTime * 20);*/
	}

	void toPast(){
		this.renderer.material.mainTexture = past;
		current_time = time.PAST;
	}

	void toPresent(){
		this.renderer.material.mainTexture = present;
		current_time = time.PRESENT;
	}

	void toFuture(){
		this.renderer.material.mainTexture = future;
		current_time = time.FUTURE;
	}

	public int getTime()
	{
		return (int) current_time;
	}

	public void setTime(int time)
	{
		current_time = (time) time;
	}

	public void onPedestal(bool value, GameObject pedestal)
	{
		onPlace = value;
		pedestalPos = pedestal;
	}

	public void placeOnPedestal()
	{
		this.transform.position = pedestalPos.transform.position;
		pedestalPos.GetComponent<SphereTrigger>().activeControlledRoom((int) this.current_time);
		changingTime = true;
		this.rigidbody.isKinematic = true;

	}

	public void pickFromPedestal()
	{
		if(changingTime)
		{
			pedestalPos.GetComponent<SphereTrigger>().activeControlledRoom (1);
			changingTime = false;
			this.rigidbody.isKinematic = false;
		}
	}
}
