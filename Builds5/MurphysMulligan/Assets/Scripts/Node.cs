using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour 
{

	public List<GameObject> neighbors = new List<GameObject>();
	public GameObject goal;
	private GameObject player, companion, nodeg;
	private GameObject[] walls;
	//Instances
	private CurrentNode _cN;
	
	//Bools
	private bool _nodeListIsFull = false;
	public bool cantGoUp, cantGoDown, cantGoRight, cantGoLeft, isSelected = false, control_sel = false;

	public Terrain current;
	public TerrainData cur_TD;
	private PlayerTest pt;
	public float offset = 20.0f;
	public Transform me, me_target;
	public float _curDistance;



	void Start()
	{
		//pt = GameObject.FindGameObjectWithTag ("gameManager").GetComponent<PlayerTest> ();
		//StartCoroutine (FindNeighbors ());


		me = gameObject.transform.FindChild ("Selected");
		me_target = gameObject.transform.FindChild ("miniMapTarget");
		me.gameObject.SetActive(false);
		me_target.gameObject.SetActive (false);
	}

	void Awake()
	{

	}
	void Update()
	{
		//if (gameObject.name != "Hole") {
		if (this.isSelected) {
			if(control_sel)
			{
				me.gameObject.SetActive (true);
				if(me_target != null)
					me_target.gameObject.SetActive(true);
				else
					me_target = gameObject.transform.FindChild ("miniMapTarget");
				FadeObjectInAndOut grab = GameObject.Find ("miniMapHole")
					.GetComponent<FadeObjectInAndOut>();
				grab.reset = true;
				control_sel = false;
			}
		} else {

			if(me != null)
			{
				me.gameObject.SetActive (false);
				if(me_target != null)
					me_target.gameObject.SetActive(false);
			}

		}
		//}
		
		//goal = hole;
	}


	
	IEnumerator FindNeighbors()
	{	
		GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");
		Node _thisNode = gameObject.GetComponent<Node>();
		Vector3 nextPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z  + offset);

		foreach(GameObject node in nodes)
		{
			Node _otherNode = node.GetComponent<Node>();
			if(node.transform.position == nextPos)
			{
				if(!_thisNode.neighbors.Contains(node))
				{
					_thisNode.neighbors.Add (node);
					_otherNode.neighbors.Add (_thisNode.gameObject);
				}
			}
		}

		yield return 0;
	}

	IEnumerator DrawNeighbors()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
		/*foreach(GameObject neighor in neighbors)
		{
			Gizmos.DrawLine (transform.position, neighor.transform.position);
			Gizmos.DrawWireSphere(neighor.transform.position, 0.25f);
		}*/
		
		if(goal)
		{
			Gizmos.color = Color.green;
			GameObject current = gameObject;
			
			Stack<GameObject> path = DijkstraAlgorithm.Dijkstra(GameObject.FindGameObjectsWithTag("Node"), gameObject, goal);
			
			foreach(GameObject obj in path)
			{
				Gizmos.DrawWireSphere(obj.transform.position, 1.0f);
				
				Gizmos.DrawLine(current.transform.position, obj.transform.position);
				current = obj;
			}
			yield return 0;
		}
		yield return 0;
	}

	void OnDrawGizmos() //editor function, if gizmos is turned on
	{
		StartCoroutine(DrawNeighbors());
	}

	void FixedUpdate()
	{


	}


}
