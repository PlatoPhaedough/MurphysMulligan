using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TutorialInstructions : MonoBehaviour {

	GUIText instructions;
	List<string> textForPositions;
	int numberOfControls;
	public GameObject player;
	//public Camera camera;
	Vector3 playerPosition;

	// Use this for initialization
	void Start () 
	{
		textForPositions = new List<string> ();
		player = GameObject.FindGameObjectWithTag ("Holy");
		instructions = GameObject.Find ("TextAboveHead").guiText;
		//camera = GameObject.FindGameObjectWithTag ("MainCamera").camera;

		textForPositions.Add ("W");
		textForPositions.Add ("X");
		textForPositions.Add ("Y");
		textForPositions.Add ("Z");
		instructions.enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{
		player = GameObject.FindGameObjectWithTag ("Holy");
		if (player != null) {
			instructions.enabled = true;

			//if player is in a certain spot
			//change instructions above head
			
			if(Input.GetKeyDown (KeyCode.A))
			{
				instructions.text = "W";
			}
		}

	}


}

//playerPosition = camera.WorldToScreenPoint(player.transform.position);
//playerPosition.y = Screen.height - playerPosition.y;
//instructions.transform.position = playerPosition;