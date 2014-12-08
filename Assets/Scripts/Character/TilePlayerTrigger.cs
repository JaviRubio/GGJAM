using UnityEngine;
using System.Collections;

public class TilePlayerTrigger : MonoBehaviour {

	public GameObject light;
	private GameObject tileLight;

	private bool solving, solved;

	private float lightDelay = 0.3f;
	private float times = 6;

	private Light thisLight;

	void Start(){
		solving = false;
		solved = false;

	}
	void OnTriggerEnter(Collider other){

		if(!solved)
		{
			if(other.collider.CompareTag ("Tile"))
			{
				//Debug.Log ("EWSAD");
			   int x = other.GetComponent<tileTrigger>().getX ();
				int y = other.GetComponent<tileTrigger>().getY ();
				RoomThreeScript script = (RoomThreeScript) FindObjectOfType<RoomThreeScript>();
				if(script.passTile (x,y))
				{
					solving = true;
					/*if(!tileLight)
					{
						tileLight = (GameObject) GameObject.Instantiate (light, this.transform.position - new Vector3(0.0f,-0.6f, 0.0f), Quaternion.identity);
						tileLight.transform.parent = this.transform;
					}
					if(tileLight)
					{
						tileLight.SetActive(true);*/
						if(script.checkSolvedRoom())
						{
							solved = true;
							solving = false;
							//Light tLight = tileLight.GetComponent<Light>();
							//tLight.color = Color.yellow;
						}
				}
				else solving = false;//tileLight.SetActive (false);
			}
		}
	}


	void Update(){
		if(!solved){
			if(solving){
				if(!tileLight)
				{
					tileLight = (GameObject) GameObject.Instantiate (light, this.transform.position - new Vector3(0.0f,-0.6f, 0.0f), Quaternion.identity);
					tileLight.transform.parent = this.transform;
					thisLight = tileLight.GetComponent<Light>();
					thisLight.color = Color.yellow;
				}
				else{
					tileLight.SetActive (true);
					thisLight.color = Color.yellow;
				}

			}
			else{
				if(tileLight)
					tileLight.SetActive(false);

			}

		}
		else{
			thisLight.color = Color.green;
			lightDelay -= Time.deltaTime;
			if(lightDelay<=0){
				if(times>=0)
				{
					thisLight.enabled = !thisLight.enabled;
					lightDelay = 0.3f;
					times --;
				}
				else{

					this.enabled = false;
					Object.Destroy(thisLight);
				}
			}

		}

	}
}
