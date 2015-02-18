using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	public Transform target;
	public float trackSpeed = 8;
	// Use this for initialization
	
	public void Start(){

	}
	
	public void SetTarget (Transform t) {
		target = t;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float x	= IncrementTowards(transform.position.x, target.position.x, trackSpeed);
		float y	= IncrementTowards(transform.position.y, target.position.y + 7.5f, trackSpeed);
		float z	= IncrementTowards(transform.position.z, target.position.z - 10f, trackSpeed);
		if(x < 5.3f)
			x = 5.3f;
		if (y > 10f)
						y = 10;
		transform.position = new Vector3(x, y, -9);
	}
	
	public void Reset() {
		//camera.orthographicSize = 8;
		//transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
	}
	
	private float IncrementTowards(float n, float target, float o){
		if(n == target){
			return n;
		}
		else{
			float dir = Mathf.Sign (target - n);
			n += o * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target - n))? n : target;
		}
	}
}