using UnityEngine;
using System.Collections;

public class tileScript : MonoBehaviour {

	private Vector3 origin;
	public GameObject tile;

	public GameObject room;

	//origin en -8.5, 0.1, -5.5

	//-1 en X, +1 en Z
	// Use this for initialization
	void Start () {
		origin = new Vector3 (-8.5f, 0.1f, -5.5f);
		GameObject instance;
		for (int i=0; i<14; i++)
		{
			for(int j=0; j<6; j++)
			{
				instance = (GameObject)  GameObject.Instantiate (tile, origin + new Vector3(-1 * i, 0, 1*j), Quaternion.identity);
				instance.name = "Tile "+ i +"," + j;
				instance.transform.parent = transform;
				instance.GetComponent<tileTrigger>().setCoordinates(i,j);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
