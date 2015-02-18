using UnityEngine;
using System.Collections;

public class TargetFollowForMiniMap : MonoBehaviour {
	
	private GameObject player, hole;
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		GameManager GM = GameObject.Find ("gameManager").GetComponent<GameManager> ();
		if (GM.cam_State == CameraState.CS_NodeSelect || GM.cam_State == CameraState.CS_Ball || 
		    GM.cam_State == CameraState.CS_Player) {
			if (gameObject.name == "miniMapPlayer") {
				player = GameObject.FindGameObjectWithTag ("Holy");
				transform.position = new Vector3 (player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
			}
			
			if (gameObject.name == "miniMapHole") {
				hole = GameObject.FindGameObjectWithTag ("Hole");
				transform.position = new Vector3 (hole.transform.position.x, gameObject.transform.position.y, hole.transform.position.z);
			}
		}

		
	}
}
