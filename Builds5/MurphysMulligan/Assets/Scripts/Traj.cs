using UnityEngine;
using System.Collections;

public class Traj : MonoBehaviour {
	public Transform tr_myTarget, tr_default_pos;
	public GameObject go_golfBall;
	private float _fl_shootAngle = 30, _fl_vel, _fl_dist, _fl_halfDist;
	private Vector3 _v3_dir;

	private SelectManager _sm;
	private GameObject _go_sm, player, terr;
	public bool _curveTest = false, didHit = false, didCollideWithGround = false, queExit = false, didCollideWithHole = false;
	private Vector3 v3_origBallLocation, v3_target, halfDist;
	private int _int_index;

	private GameManager GM;
	private PlayerController _playercont;


	// Use this for initialization
	void Start () {
		_go_sm = GameObject.FindWithTag ("SelectManager");
		GM = GameObject.FindGameObjectWithTag ("gameManager").GetComponent<GameManager> ();
		player = GameObject.FindWithTag ("Holy");
		 _sm = _go_sm.GetComponent<SelectManager> ();
		//Debug.Log (transform.position.magnitude);
		v3_origBallLocation = gameObject.transform.position;
		v3_target = GameObject.FindWithTag ("Hole").transform.position;
		//_fl_dist = Vector3.Distance (v3_origBallLocation, v3_target);
		//_fl_halfDist = _fl_dist / 2;
		//midpoint = (gameObject.transform.position + v3_target) * 0.25f;
		tr_default_pos = GameObject.Find ("Node 20").transform;
		terr = GameObject.Find ("Terrain");

	}

	void Update()
	{
		if (didCollideWithGround && !didCollideWithHole) {
			//here we need to check if ball is 2+ above par, or if ball is in hole
			//if so, Start Coroutine Exit (StartCoroutine(WaitForExit());)
			//if not, move player to ball
			//
			//
			if(gameObject.rigidbody.velocity.sqrMagnitude < 15.0f)
				StartCoroutine(WaitForExit());
		}

		if (didCollideWithHole) {
			queExit = true;
			StartCoroutine(WaitForExit());
		}
	}

	IEnumerator WaitForExit()
	{

		if (didCollideWithHole) {
				yield return new WaitForSeconds (2);
				queExit = true;
		} else {
				GM.TurnOffTexts ();
				yield return new WaitForSeconds (0.8f);
				GM.cam_State = CameraState.CS_Par;
				yield return new WaitForSeconds (2);
				//GM.ParText.SetActive (true);
				GM.initPlayerMove (gameObject.transform.position);
				_sm.gaveVel = false;
				Destroy (gameObject);
		}
	}

	void OnGUI()
	{
		if (queExit) {
			const int restart_buttonWidth = 84;
			const int restart_buttonHeight = 60;
			const int exit_buttonWidth = 84;
			const int exit_buttonHeight = 60;

			Rect restart_buttonRect = new Rect(
				Screen.width / 2 - (restart_buttonWidth / 2),
				(2 * Screen.height / 6) - (restart_buttonHeight / 2),
				restart_buttonWidth,
				restart_buttonHeight
				);
			
			Rect exit_buttonRect = new Rect(
				Screen.width / 2 - (exit_buttonWidth / 2),
				(2 * Screen.height / 4) - (exit_buttonHeight / 2),
				exit_buttonWidth,
				exit_buttonHeight
				);

			if(GUI.Button(restart_buttonRect,"Restart Game"))
			{
				Application.LoadLevel(0);
				queExit = false;
			}
			
			if(GUI.Button(exit_buttonRect,"Exit"))
			{
				Application.Quit ();
				queExit = false;
			}
		}
	}


	// Update is called once per frame
	void FixedUpdate () 
	{
		//Debug.Log (_fl_halfDist);

		//Debug.Log (v3_origBallLocation - midpoint);

		//Debug.Log (midpoint);

		if (didHit) {

			if (_curveTest) {
				//Debug.Log ("half1");

				//gameObject.rigidbody.AddForce (new Vector3 (5.0f, 0.0f, 0.0f), ForceMode.Force);
			}

			/*if(gameObject.transform.position.x <= midpoint.x)
			{
				_curveTest = false;
				//Debug.Log ("half2");
				gameObject.rigidbody.AddForce (new Vector3(-10.0f, 0.0f, 0.0f), ForceMode.Force);
			}

			if(gameObject.transform.position.x <= v3_target.x + 10.0f)
			{
				//didHit = false;
			}*/
		}


	}

    public void setTraj()
    {
        didHit = true;
        halfDist = ((v3_target - v3_origBallLocation) / 2);

		if (_sm.currently_selected_node != null)
			tr_myTarget = _sm.currently_selected_node.transform;
		else
			tr_myTarget = tr_default_pos;

		SwingGUI SG = GameObject.FindGameObjectWithTag("SwingGUI").GetComponent<SwingGUI>();
		float offset = SG.powerDifference;
		Debug.Log (offset);
		gameObject.rigidbody.velocity = BallisticVel(tr_myTarget, _fl_shootAngle, offset);
        _curveTest = true;
		GM.cam_State = CameraState.CS_Ball;
		GM.game_State = GameState.GS_BallInAir;
		_sm.gaveVel = true;
		_sm.ClearPath();

        //Debug.Log ("here");
    }

	Vector3 BallisticVel(Transform target, float angle, float offset)
	{
		_v3_dir = target.position - transform.position;
		float h = _v3_dir.y;
		_v3_dir.y = 0;
		float dist = _v3_dir.magnitude;
		float a = angle * Mathf.Deg2Rad;
		_v3_dir.y = dist * Mathf.Tan (a);
		dist += h / Mathf.Tan (a);
		_fl_vel = Mathf.Sqrt (dist * Physics.gravity.magnitude / Mathf.Sin (2 * a));
		//Debug.Log (_fl_vel * _v3_dir.normalized.magnitude);
		return (_fl_vel - offset) * _v3_dir.normalized;
	}

	Vector3 BallisticVel(Transform target, float angle)
	{
		_v3_dir = target.position - transform.position;
		float h = _v3_dir.y;
		_v3_dir.y = 0;
		float dist = _v3_dir.magnitude;
		float a = angle * Mathf.Deg2Rad;
		_v3_dir.y = dist * Mathf.Tan (a);
		dist += h / Mathf.Tan (a);
		_fl_vel = Mathf.Sqrt (dist * Physics.gravity.magnitude / Mathf.Sin (2 * a));
		//Debug.Log (_fl_vel * _v3_dir.normalized.magnitude);
		return _fl_vel * _v3_dir.normalized;
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Player") {
			didHit = true;
			halfDist = ((v3_target - v3_origBallLocation)/2);
			tr_myTarget = _sm.currently_selected_node.transform;
			gameObject.rigidbody.velocity = BallisticVel(tr_myTarget, _fl_shootAngle);
			_curveTest = true;

		}


		if (didHit) {
			if (col.collider.gameObject.name == "Terrain") {

				//HERE WE NEED TO MAKE SURE BALL HAS STOPPED MOVING
				didCollideWithGround = true;
				didHit = false;
			}
		}

		if (col.collider.tag == "Hole") {
			Debug.Log ("BALL IN HOLE!");
			didCollideWithHole = true;
		}






	}
}
