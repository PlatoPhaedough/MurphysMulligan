using UnityEngine;
using System.Collections;

public class ZoneManager : MonoBehaviour {
	public GameObject ball;
	public bool ballIsInPlay = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (ball != null) {
			if (ballIsInPlay) {
				if (PointInsideSphere (ball.transform.position, gameObject.transform.position, 50.0f)) {
					Debug.Log ("ball is in putting zone");
				}
				
				if (PointInsideSphere (ball.transform.position, gameObject.transform.position, 150.0f)) {
					Debug.Log ("ball is  chipping zone");
				}
				
				if (PointInsideSphere (ball.transform.position, gameObject.transform.position, 250.0f)) {
					Debug.Log ("ball is close zone");
				}
				
				if (PointInsideSphere (ball.transform.position, gameObject.transform.position, 400.0f)) {
					Debug.Log ("This should be default position zone");
				}
			}
		}


	
	}

	public bool PointInsideSphere(Vector3 point, Vector3 center, float radius) {
		return Vector3.Distance(point, center) < radius;
	}
}
