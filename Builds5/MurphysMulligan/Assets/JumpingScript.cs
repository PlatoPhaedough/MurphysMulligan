using UnityEngine;
using System.Collections;

public class JumpingScript : MonoBehaviour {

	public Vector3 maxHeight, minHeight; 
	public float speed;
	private bool goUp = true;
	public bool getValues = false;
	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () 
	{
		if (getValues) {
			maxHeight = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + 40.0f), gameObject.transform.position.z);
			minHeight = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + 20.0f), gameObject.transform.position.z);
			getValues = false;
		}

		float step = speed * Time.deltaTime;
		if(goUp)
			transform.position = Vector3.MoveTowards(transform.position, maxHeight, step);
		else
			transform.position = Vector3.MoveTowards(transform.position, minHeight, step);


		if(transform.position == maxHeight)
			goUp = false;

		if(!goUp && transform.position.y == minHeight.y)
			goUp = true;



		//if(transform.position.y >= minHeight.y)


	}
}
