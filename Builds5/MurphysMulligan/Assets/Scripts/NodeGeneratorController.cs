using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeGeneratorController : MonoBehaviour {
	
	
	public GameObject _original, clone, companion;
	public int intNodeCount;
	private int _intPreviousNodeCount, _intTemp, _trash;
	private NodeCloneController NCC;
	public bool blnNodeProbablyDone = false, begin = false;
	private bool Stop = false;
	private RaycastHit  _checkForGroundHit;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (!blnNodeProbablyDone) {
			_intPreviousNodeCount = intNodeCount;
			StartCoroutine (CheckIfDone ());
		}
	}
	
	void FixedUpdate()
	{

		if(begin && 1 > _trash)
		{
			StartCoroutine(Begin ());
			_trash++;
		}
		if (!Stop) {
			if (blnNodeProbablyDone) {
				StartCoroutine(MoveNodesDownCorrectYCoordinate());
				PlayerTest pt = GameObject.FindGameObjectWithTag("gameManager").GetComponent<PlayerTest>();
				//pt.spawn = GameObject.Find ("Node 2");
				MoveAllToParent();
				Stop = true;
			}
		}
	}

	IEnumerator Begin()
	{
		Vector3 temp = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Debug.Log (temp);
		Instantiate(clone, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
		intNodeCount++;
		_original = GameObject.FindGameObjectWithTag("Node");
		Debug.Log ("hui");
		yield return 0;
	}
	
	void MoveAllToParent()
	{
		GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");
		GameObject parent = GameObject.FindGameObjectWithTag("NodeGenerator");
		foreach(GameObject node in nodes)
		{
			node.transform.parent = parent.transform;
		}
	}
	
	IEnumerator test()
	{
		yield return new WaitForSeconds (1);
	}
	
	IEnumerator CheckIfDone()
	{
		//Debug.Log ("int previous: " + _intPreviousNodeCount + " node count " + intNodeCount);
		yield return new WaitForSeconds (2);
		//Debug.Log ("DOS int previous: " + _intPreviousNodeCount + " node count " + intNodeCount);
		if (_intPreviousNodeCount == intNodeCount) {
			_intTemp++;
			if(_intTemp > 10)
			{
				//Debug.Log ("Done?");
				blnNodeProbablyDone = true;
			}
		}
		yield return 0;
	}


	IEnumerator MoveNodesDownCorrectYCoordinate()
	{
		TerrainGenerator tg = GameObject.FindGameObjectWithTag ("TerrainGenerator").GetComponent<TerrainGenerator> ();

		GameObject[] nodes = GameObject.FindGameObjectsWithTag ("Node");
		foreach (GameObject node in nodes) {
			float steep = tg.GetSteepnessValue(node.transform.position);
			//Debug.Log (node.name + " " + steep);
			node.transform.position = new Vector3(node.transform.position.x, steep, node.transform.position.z);
			//JS_Script = node.transform.FindChild("Selected").GetComponent<JumpingScript>();
			//JS_Script.getValues = true;
		}
		yield return 0;
	}
	
	void SetInitAllEnemyOutOfIdle()
	{

		
		return;
	}
	
	
}