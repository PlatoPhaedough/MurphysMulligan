using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject golfBall;
	private bool didLay = false;
	private ZoneManager ZM;
	public GameObject SelectedNode, DefaultSelectedNode;
	// Use this for initialization
	void Start () {
		DefaultSelectedNode = GameObject.FindGameObjectWithTag ("Hole");
	}
	
	// Update is called once per frame
	void Update () {

		if (SelectedNode != null)
						transform.LookAt (SelectedNode.transform.position);
		else {
			transform.LookAt (DefaultSelectedNode.transform.position);
		}
		/*if (Input.GetKeyDown (KeyCode.Mouse1)) {
			if(!didLay)
			{
				GameObject ball = (GameObject)Instantiate(golfBall) as GameObject;
				ZM = GameObject.FindGameObjectWithTag("Hole").GetComponent<ZoneManager>();
				ZM.ballIsInPlay = true;
				ZM.ball = ball;
				ball.transform.parent = gameObject.transform;
				ball.transform.position = new Vector3(gameObject.transform.position.x - 0.8f , gameObject.transform.position.y, gameObject.transform.position.z - 2.35f);
				didLay = true;
			}
		}*/
	
	}

	public void MovePlayerToPosition(Vector3 pos)
	{
		didLay = false;
		//transform.position = new Vector3 (pos.x, (pos.y + 5.0f), pos.z);
		Destroy (gameObject);
	}

	public void InstanBall()
	{
		GameObject ball = (GameObject)Instantiate(golfBall) as GameObject;
		ZM = GameObject.FindGameObjectWithTag("Hole").GetComponent<ZoneManager>();
		ZM.ballIsInPlay = true;
		ZM.ball = ball;
		ball.transform.parent = gameObject.transform;
		ball.transform.position = new Vector3(gameObject.transform.position.x - 0.8f , gameObject.transform.position.y, gameObject.transform.position.z - 2.35f);
	}
}
