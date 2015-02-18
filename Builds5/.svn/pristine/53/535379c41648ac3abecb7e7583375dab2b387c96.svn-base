using UnityEngine;
using System.Collections;

public class SetHolePosition : MonoBehaviour {

	public bool turnOn = false;
	private TerrainGenerator tg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (turnOn) {
			tg = GameObject.FindGameObjectWithTag("TerrainGenerator").GetComponent<TerrainGenerator>();
			float steep = tg.GetSteepnessValue(transform.position);
			transform.position = new Vector3(transform.position.x, (steep + .3f), transform.position.z);
			turnOn = false;
		}
	
	}
}
