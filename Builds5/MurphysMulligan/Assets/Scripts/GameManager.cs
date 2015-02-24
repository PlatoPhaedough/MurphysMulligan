using UnityEngine;
using System.Collections;

public enum CameraState
{
	CS_PreGame, CS_NodeSelect, CS_Player, CS_Ball, CS_Par, CS_EndGame
}

public enum GameState
{
	GS_MenuSelect, GS_NodeSelect, GS_Swing, GS_BallInAir, GS_BallLanded, GS_EndGame
}

public class GameManager : MonoBehaviour {

	public CameraState cam_State;
	public GameState game_State;
	public Camera PreGameCam, NodeSelectCam, PlayerCam, BallCam, EndGameCam, ParCam, miniMapCam;

	//private GameCamera BallFollow;
	private CameraSmoothFollow BallFollow;
	private SelectManager SM;
	private PlayerController PC;
	public GameObject TutText, UpText, SelectText, HitText, ParText;

	public bool showTutText = false, showUpText = false, KeepUpText = true, showHitText = false;
	private PlayerController _playercont;
	private int copyCount = 0;

	// Use this for initialization
	void Start () {
		cam_State = CameraState.CS_PreGame;
		SM = GameObject.FindGameObjectWithTag ("SelectManager").GetComponent<SelectManager>();
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (CamStateMachine ());
		StartCoroutine (GameStateMachine ());
		if (gameObject.GetComponent<PlayerTest> ().TutorialMode) {
			//TutText.SetActive(true);
			if(copyCount < 1)
				CopyTerrainForMiniMap();
			/*if(KeepUpText)
				showUpText = true;*/
				
		}
		Debug.Log ("We made a change!");
		//StartCoroutine (GameStateMachine ());
	}

	public void TurnOffTexts()
	{
		/*showUpText = false;
		showHitText = false;
		KeepUpText = false;
		UpText.SetActive (false);
		SelectText.SetActive (false);
		HitText.SetActive (false);*/

	}

	public void initPlayerMove(Vector3 movePos)
	{
		_playercont = GameObject.FindGameObjectWithTag("Holy").GetComponent<PlayerController>();
		Destroy (GameObject.FindGameObjectWithTag("Holy"));
		GameObject hole = GameObject.FindGameObjectWithTag ("Hole");
		GameObject holy = (GameObject)Resources.Load ("Holy") as GameObject;
		PlayerTest pt = GameObject.FindGameObjectWithTag("gameManager").GetComponent<PlayerTest>();
		float steep = pt.GetYPos(movePos);
		GameObject go_holy = (GameObject) Instantiate (holy, new Vector3(movePos.x, steep + 1.0f, movePos.z), Quaternion.identity) as GameObject;
		PC = go_holy.GetComponent<PlayerController> ();
		PC.InstanBall ();
		go_holy.transform.LookAt (hole.transform);

		//SM.blnGrabbedOriginal = false;
		SM.player = go_holy;
		SM.ClearPath ();
		//change camera here
	}



	void CopyTerrainForMiniMap()
	{
		GameObject terr = GameObject.FindGameObjectWithTag ("MainTerrain");
		GameObject temp = new GameObject ();
		temp = (GameObject)Instantiate (terr, terr.transform.position, terr.transform.rotation) as GameObject;
		temp.transform.position = new Vector3 (terr.transform.position.x, terr.transform.position.y - 10, terr.transform.position.z);
		temp.layer = 8;
		temp.GetComponent<Terrain> ().castShadows = false;
		temp.GetComponent<Terrain> ().heightmapPixelError = 80;
		temp.GetComponent<Terrain> ().detailObjectDensity = 0.0f;
		temp.GetComponent<Terrain> ().treeMaximumFullLODCount = 0;
		copyCount++;
	}

	IEnumerator CamStateMachine()
	{
		StartCoroutine (cam_State.ToString ());

		yield return 0;
	}

	IEnumerator GameStateMachine()
	{
		StartCoroutine (game_State.ToString ());
		Debug.Log (game_State.ToString ());
		yield return 0;
	}
	IEnumerator GS_MenuSelect()
	{
		Debug.Log ("here");
		yield return 0;
	}
	
	IEnumerator GS_NodeSelect()
	{
		Debug.Log ("here");
		yield return 0;
	}

	IEnumerator GS_Swing()
	{
		Debug.Log ("here");
		yield return 0;
	}
	
	IEnumerator GS_BallInAir()
	{
		Debug.Log ("in ball in air");
		PC.SelectedNode = null;
		yield return 0;
	}

	IEnumerator CS_PreGame()
	{
		DisableOtherCams (PreGameCam);
		SplashScreen PGC = GameObject.FindGameObjectWithTag ("PreGameCam").GetComponent<SplashScreen> ();
		PGC.init = true;
		yield return 0;
	}

	IEnumerator CS_Par()
	{
		DisableOtherCams (ParCam);
		yield return new WaitForSeconds (9.0f);
		SM = GameObject.FindGameObjectWithTag ("SelectManager").GetComponent<SelectManager>();
		SM.ClearPath ();
		cam_State = CameraState.CS_Player;

		//ParText.SetActive (false);
		yield return 0;
	}

	IEnumerator CS_Player()
	{

		GameObject player = GameObject.FindGameObjectWithTag ("Holy");
		PlayerCam = player.transform.Find ("PlayerCamera").GetComponent<Camera> ();
		DisableOtherCams (PlayerCam);
		game_State = GameState.GS_NodeSelect;
		yield return 0;
	}

	IEnumerator CS_Ball()
	{
		yield return new WaitForSeconds (0.3f);
		DisableOtherCams (BallCam);
		
		yield return 0;
	}

	void DisableOtherCams(Camera ignoreCam)
	{
		Camera[] cams = Camera.allCameras;
		ignoreCam.gameObject.SetActive (true);
		foreach(Camera cam in cams)
		{
			if(cam != ignoreCam){
				if(cam.gameObject.tag != "MiniMapCam"){
					cam.gameObject.SetActive(false);
				}
				//cam.GetComponent(typeof(AudioListener)) as AudioListener).enabled = false;
			} 
			
			if(ignoreCam.name == "ParCam") {
				if(cam != ignoreCam){
					cam.gameObject.SetActive(false);
				}
			}else{
				EnableCam(miniMapCam);
			}
		}
		
		if (cam_State == CameraState.CS_Ball) {
			BallFollow = GameObject.FindGameObjectWithTag ("BallCam").GetComponent<CameraSmoothFollow>() ;
			BallFollow.target = GameObject.FindGameObjectWithTag ("golfBall");
		}

	}

	void EnableCam(Camera enable)
	{
		enable.gameObject.SetActive (true);
	}
}
