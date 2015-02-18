using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SelectManager : MonoBehaviour {
		

	RaycastHit hit;
	Ray ray;
	public GameObject golfBall;
	//private NodeGeneratorController NGC;
	private Node Node, tempNodeScript, _previousNode;
	private GameManager GM_Script;
	private ZoneManager ZM_Script;
	private Traj TrajScript;

	public GameObject original, hole, farthest, closest, secondfarthest, thirdfarthest;
	public List<GameObject> listOfNodesInView, listOfNodesFromPath, nodesInView_list;
	private Stack<GameObject> _path = new Stack<GameObject> ();
	public GameObject[] nodesInSelectionView;
	private GameObject[] nodes;
	public GameObject currently_selected_node, execute_selected_node, player;
	private GameObject Traj, LR, GM, NGC_GO,_previousSelectedNode;

	private bool nodeGenComplete = false;
	public bool isSelecting = false, gaveVel = false, blnGrabbedOriginal = false;

	public Material mat;

	public float maxDistance;

	// Use this for initialization
	void Start () {
		ray = new Ray ();
		original = GameObject.Find ("NodeMother");
		Traj = GameObject.FindWithTag ("Traj");
		GM = GameObject.FindGameObjectWithTag ("gameManager");
		GM_Script = GM.GetComponent<GameManager> ();
		TrajScript = Traj.GetComponent<Traj> ();
		StartCoroutine (WaitForPlayer ());

	}

	IEnumerator WaitForPlayer()
	{
		yield return new WaitForSeconds (3);
		yield return 0;
	}


	void OnGUI()
	{
		Rect rect = new Rect ();
		nodes = GameObject.FindGameObjectsWithTag ("Node");
		foreach (GameObject node in nodes) {
			if(node.GetComponent<Node>().isSelected)
			{
				rect.x = node.transform.FindChild("Selected").transform.position.x;
				rect.y = node.transform.FindChild("Selected").transform.position.y;
				Texture2D texture = new Texture2D(1, 1);
				texture.SetPixel(0,0,Color.green);
				texture.Apply();
				GUI.skin.box.normal.background = texture;
				GUI.Box(rect, GUIContent.none);
			}
		}



	}

	void SelectNode(Node node, GameObject go)
	{
		//Debug.Log (go.name);
		currently_selected_node = go;
		PlayerController PC = GameObject.FindGameObjectWithTag ("Holy").GetComponent<PlayerController> ();
		PC.SelectedNode = go;
		TrajScript.tr_myTarget = currently_selected_node.transform;
		if (_previousSelectedNode != null) {
			_previousNode = _previousSelectedNode.GetComponent<Node>();
			_previousNode.isSelected = false;
		}
		node = go.GetComponent<Node>();
		node.isSelected = true;
		node.control_sel = true;
		_previousSelectedNode = go;
	}

	IEnumerator FindNextNode()
	{
		/*if (_path == null) {
			UpdatePath ();
		}*/
		//GameObject temp = _path.Pop();
		//Debug.Log (temp.name);
		try {
			SelectNode(Node, _path.Pop ());
		}
		catch {
			//Debug.Log ("works as planned");
			CreatePath();
			blnGrabbedOriginal = false;
		}

		yield return 0;
	}

	void FixedUpdate()
	{
		if (isInHoleView ()) {
						Debug.Log ("is in view");
				}
	}

	public void CreatePath()
	{
		nodesInSelectionView = FindSmartSelectionNodes();
		FindSecondFarthest();
		FindThirdFarthest();
		_path.Push(farthest);
		_path.Push (secondfarthest);
		_path.Push (thirdfarthest);

		//currently_selected_node = farthest;
		hole = GameObject.FindGameObjectWithTag ("Hole");
	}
	
	public void ClearPath()
	{
		GameObject grab = currently_selected_node;
		try{
			grab.GetComponent<Node>().isSelected = false;

		} catch {
		}

		farthest = GameObject.FindGameObjectWithTag("SelectManager");
		secondfarthest = GameObject.FindGameObjectWithTag("SelectManager");
		thirdfarthest = GameObject.FindGameObjectWithTag("SelectManager");
		currently_selected_node = GameObject.FindGameObjectWithTag("SelectManager");
	}

	public bool isInHoleView()
	{
		GameObject hole_temp = GameObject.FindGameObjectWithTag ("Hole");
		ZM_Script = GameObject.FindGameObjectWithTag ("Hole")
			.GetComponent<ZoneManager> ();
		golfBall = GameObject.FindGameObjectWithTag ("golfBall");
		GameManager gm = GameObject.FindGameObjectWithTag ("gameManager")
			.GetComponent<GameManager> ();
		if (gm.game_State == GameState.GS_NodeSelect) {
			if (ZM_Script.PointInsideSphere (golfBall.transform.position, hole_temp.transform.position, 250.0f)) {
				Debug.Log ("Hole is in view");
				return true;
			} else {
				return false;
			}
		}
		return false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("NodeGenerator") != null)
			original = GameObject.Find ("NodeMother");

		/*if (GM_Script.showUpText) {
			//GM_Script.UpText.SetActive (true);
			//GM_Script.SelectText.SetActive(true);
		}			
		else{
			//GM_Script.UpText.SetActive (false);
			//GM_Script.SelectText.SetActive(false);
		}*/

		if(Input.GetKeyDown (KeyCode.C))
		{
			Debug.Log ("Clearing..");
			ClearPath();
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			isSelecting = true;
			if(!blnGrabbedOriginal)
			{
				nodesInSelectionView = FindSmartSelectionNodes();
				FindSecondFarthest();
				FindThirdFarthest();
				_path.Push(farthest);
				Debug.Log ("fetching farthest..");
				_path.Push (secondfarthest);
				Debug.Log ("fetching 2nd farthest..");
				_path.Push (thirdfarthest);
				Debug.Log ("fetching 3rd farthest..");
				/*_path = DijkstraAlgorithm.Dijkstra (nodesInSelectionView, 
						                                closest.GetComponent<CurrentNode> ().currentNode, 
						                                farthest.GetComponent<CurrentNode> ().currentNode);*/
				StartCoroutine(FindNextNode());
				if(isInHoleView())
				{
					Debug.Log("show");
					thirdfarthest = GameObject.FindGameObjectWithTag("Hole");
				}
				blnGrabbedOriginal = true;


				//SelectNode(Node, original);
			}
			else {
				/*if (_path == null) {
						UpdatePath ();
					}*/
				if(isInHoleView())
				{
					thirdfarthest = GameObject.FindGameObjectWithTag("Hole");
				}
				StartCoroutine(FindNextNode());
			}				
		}

		if(Input.GetKeyDown (KeyCode.H))
		{
			GameObject ball = (GameObject)Instantiate(golfBall) as GameObject;
			ball.transform.parent = player.transform;
			ball.transform.position = new Vector3(player.transform.position.x - 2.0f , player.transform.position.y, player.transform.position.z);
			isSelecting = false;
		}
	}

	GameObject[] FindSmartSelectionNodes()
	{
		GameObject[] nodesInView = GameObject.FindGameObjectsWithTag ("Node");
		hole = GameObject.FindGameObjectWithTag ("Hole");
		nodesInView_list = new List<GameObject> ();
		foreach (GameObject node in nodesInView)
						nodesInView_list.Add (node);

		nodesInView_list.Add (hole);
		listOfNodesInView = new List<GameObject> ();
		float farthestDistance = 0;
		float closestDistance = Mathf.Infinity;


		if (player != null) {
			foreach (GameObject node in nodesInView_list) {
				float dist = (player.transform.position - node.transform.position).magnitude;

				float real_max  = (hole.transform.position - player.transform.position).magnitude;
				if(real_max < maxDistance)
				{
					maxDistance = real_max;
				}

				if(dist < maxDistance)
				{
					Vector3 dir = node.transform.position - player.transform.position;
					float angle = Mathf.Atan2 (dir.z, dir.x) * Mathf.Rad2Deg;

					Vector3 against_dir = hole.transform.position - node.transform.position;
					float against_angle = Mathf.Atan2 (against_dir.z, against_dir.x) * Mathf.Rad2Deg;
					//Debug.Log (angle);
					//Debug.Log (against_angle);
					//Debug.Log (node.name + " " + against_angle);

					if(angle >= (against_angle - 30) && angle <= (against_angle + 30))
					{
						//Debug.Log (node.name + " " + angle);
						listOfNodesInView.Add (node);
					}
						
					
					foreach(GameObject n in listOfNodesInView)
					{
						float curDistance = dir.sqrMagnitude;
						
						node.GetComponent<Node>()._curDistance = curDistance;
						if(curDistance < closestDistance)
						{
							closestDistance = curDistance;
							closest = node;
						}
						if(curDistance > farthestDistance)
						{
							farthestDistance = curDistance;
							farthest = node;
						}
					}
				}
			}
		}


		/*for (int i = 0; i < 1; i++) {
			listOfNodesInView.Add (GameObject.Find ("NodeMother2"));
			listOfNodesInView.Add (GameObject.Find ("NodeFather2"));
		}*/
		GameObject[] listOfNodesInViewToArray = listOfNodesInView.ToArray ();
		return listOfNodesInViewToArray;	
	}

	public void FindSecondFarthest()
	{
		float farthestDistance = 0;
		foreach (GameObject node in listOfNodesInView) {
			float dist = (player.transform.position - node.transform.position).magnitude;
			
			if(dist < 300)
			{
				Vector3 dir = player.transform.position - node.transform.position;
				float curDistance2 = dir.sqrMagnitude;
				//Debug.Log (node.name + " distance away " + curDistance2);
				if(node != farthest)
				{
					float curDistance = dir.sqrMagnitude;
					if(curDistance > farthestDistance)
					{
						farthestDistance = curDistance;
						secondfarthest = node;
					}
				}
			}
		}
	}

	public void FindThirdFarthest()
	{
		float farthestDistance = 0;
		GameObject hole_temp = GameObject.FindGameObjectWithTag ("Hole");
		ZM_Script = hole_temp.GetComponent<ZoneManager> ();
		golfBall = GameObject.FindGameObjectWithTag ("golfBall");
		if (golfBall != null) {
			if (ZM_Script.PointInsideSphere (golfBall.transform.position, hole_temp.transform.position, 50.0f)) {
				Debug.Log ("djdjd");
				thirdfarthest = hole_temp;
			} 
			else {
				foreach (GameObject node in listOfNodesInView) {
					float dist = (player.transform.position - node.transform.position).magnitude;
					
					if(dist < 300)
					{
						Vector3 dir = player.transform.position - node.transform.position;
						float curDistance2 = dir.sqrMagnitude;
						//Debug.Log (node.name + " distance away " + curDistance2);
						if(node != farthest && node != secondfarthest)
						{
							float curDistance = dir.sqrMagnitude;
							if(curDistance > farthestDistance)
							{
								farthestDistance = curDistance;
								thirdfarthest = node;
								
							}
						}
					}
				}
				
			}
		}
		
	}
	
	
	
}
