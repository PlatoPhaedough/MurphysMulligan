using UnityEngine;
using System.Collections;

public class SwingInit : MonoBehaviour {

	private GameObject ball;
	private Traj trajScript;
	private int _int_onlyHitonce = 0;
	private GameManager GM;
	//public Animation anim;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag ("golfBall");
		trajScript = ball.GetComponent<Traj> ();
		GM = GameObject.FindGameObjectWithTag ("gameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update()
	{

				//Debug.Log (gameObject.transform.rotation.z);


		if (_int_onlyHitonce == 0)
		{
			if (gameObject.transform.rotation.z < 0) {
				trajScript.setTraj ();
				//StartCoroutine(WaitForSwitchToBall());
				//GM.cam_State = CameraState.CS_Ball;
				_int_onlyHitonce++;

			}

		}
						//trajScript.setTraj ();
	}

	void OnCollisionEnter(Collision col)
	{
		//if (col.collider.tag == "golfClub")
						//Debug.Log ("YES!");
	}

	IEnumerator WaitForSwitchToBall()
	{
		yield return new WaitForSeconds(1.5f);
	}
}
