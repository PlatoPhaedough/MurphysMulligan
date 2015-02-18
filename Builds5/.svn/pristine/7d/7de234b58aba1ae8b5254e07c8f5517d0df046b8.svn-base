using UnityEngine;
using System.Collections;

public class CameraSmoothFollow : MonoBehaviour {
	
	public GameObject target; // object to look at or follow
	//public GameObject player; // player object for moving
	
	public float smoothTime = 0.1f; // time for dampen
	public bool cameraFollowX = true; // camera follows on horizontal
	public bool cameraFollowY = true; // camera follows on vertical
	public bool cameraFollowHeight = true; // camera follow CameraTarget object height
	public float cameraHeight = 2.5f; // height of camera adjustable
	public Vector3 velocity; // speed of camera movement
	
	private Transform thisTransform; // camera Transform
	
	// Use this for initialization
	void Start () {
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (cameraFollowX){
			transform.LookAt (target.transform.position);
			//transform.rotation = Quaternion.LookRotation(target.transform.position);

				//transform.LookAt(target.transform.position);
			//thisTransform.position.x = Mathf.SmoothDamp (thisTransform.position.x, cameraTarget.transform.position.x, ref velocity.x, smoothTime); // Here i get the error
			thisTransform.position = new Vector3 (Mathf.SmoothDamp (thisTransform.position.x, target.transform.position.x, ref velocity.x, smoothTime), 
			                                      Mathf.SmoothDamp (thisTransform.position.y, target.transform.position.y, ref velocity.y, smoothTime), 
			                                      Mathf.SmoothDamp (thisTransform.position.z, target.transform.position.z, ref velocity.z, smoothTime));

		}
		if (cameraFollowY) {
			// to do    
		}
		if (!cameraFollowX & cameraFollowHeight) {
			// to do
		}
	}
}
