using UnityEngine;
using System.Collections;

public class TilePlayerTrigger : MonoBehaviour {

	public GameObject light;
	private GameObject tileLight;

	void OnTriggerEnter(Collider other){

		if(other.collider.CompareTag ("Tile"))
		{
			//Debug.Log ("EWSAD");
		   int x = other.GetComponent<tileTrigger>().getX ();
			int y = other.GetComponent<tileTrigger>().getY ();
			RoomThreeScript script = (RoomThreeScript) FindObjectOfType<RoomThreeScript>();
			if(script.passTile (x,y))
			{
				if(!tileLight)
				{
					tileLight = (GameObject) GameObject.Instantiate (light, this.transform.position - new Vector3(0.0f,-0.6f, 0.0f), Quaternion.identity);
					tileLight.transform.parent = this.transform;
				}
				if(tileLight)
				{
					tileLight.SetActive(true);
					if(script.checkSolvedRoom())
						tileLight.GetComponent<Light>().color = Color.yellow;
				}
			}
			else tileLight.SetActive (false);
		}
	}
}
