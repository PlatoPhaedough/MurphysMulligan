using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerTest : MonoBehaviour {

	bool terrainDone = false;
	int ticker = 0;
	public GameObject Golfer;
	public Vector3 spawn;
	private SelectManager SM;
	private GameObject SM_player;
	private bool showGUI = true;
	private GameManager GM;
	private TerrainGenerator tg;
	public GameObject Terr_ref;
	private JumpingScript JS_Script;
	private SetHolePosition SHP;
	private PlayerController PC;


    //public Texture2D TextureMainMenu;
    //public GUIStyle MainMenuButton;
    //public GUIStyle creditsLabel;
    //public GUIStyle creditsFont;
    //public GUIStyle creditsLargeFont;
    //private string currentMenu;
    //GUIStyle customCreditsBox;
    //GUIStyle customCreditsLabel;
    //GUIStyle customCreditsDrop;

	public bool TutorialMode = false;

	// Use this for initialization
	void Start () 
	{
		tg = GameObject.FindGameObjectWithTag ("TerrainGenerator").GetComponent<TerrainGenerator>();
		GM = GameObject.FindGameObjectWithTag ("gameManager").GetComponent<GameManager> ();;
		//StartCoroutine (WaitForSpawn ());
        //currentMenu = "main";
		spawn = GameObject.Find("Node 3").transform.position;
	}

	void Update()
	{
		if (terrainDone)
		if (ticker < 2) {
			//MoveNodesDown ();
			ticker++;
		}


		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		StartCoroutine (WaitForTerrain ());
		terrainDone = true;
	}



	void OnGUI()
	{
        //if (showGUI) {
        //    // Main Menu Options
        //    if (currentMenu == "main")
        //        MainMenu();
        //    else if (currentMenu == "credits")
        //        Credits();
        //    else if (currentMenu == "exit")
        //        Exit();
        //    /*const int start_buttonWidth = 84;
        //    const int start_buttonHeight = 60;
        //    const int cred_buttonWidth = 84;
        //    const int cred_buttonHeight = 60;
        //    const int exit_buttonWidth = 84;
        //    const int exit_buttonHeight = 60;
			
        //    // Determine the button's place on screen
        //    // Center in X, 2/3 of the height in Y
        //    Rect start_buttonRect = new Rect(
        //        Screen.width / 2 - (start_buttonWidth / 2),
        //        (2 * Screen.height / 6) - (start_buttonHeight / 2),
        //        start_buttonWidth,
        //        start_buttonHeight
        //        );

        //    Rect cred_buttonRect = new Rect(
        //        Screen.width / 2 - (cred_buttonWidth / 2),
        //        (2 * Screen.height / 4) - (cred_buttonHeight / 2),
        //        cred_buttonWidth,
        //        cred_buttonHeight
        //        );

        //    Rect exit_buttonRect = new Rect(
        //        Screen.width / 2 - (cred_buttonWidth / 2),
        //        (2 * Screen.height / 3) - (cred_buttonHeight / 2),
        //        cred_buttonWidth,
        //        cred_buttonHeight
        //        );
			
        //    // Draw a button to start the game
        //    if(GUI.Button(start_buttonRect,"Start Game"))
        //    {
        //        // On Click, load the first level.
        //        // "Stage1" is the name of the first scene we created.

        //        StartCoroutine (WaitForSpawn ());
        //        showGUI = false;
        //    }

        //    if(GUI.Button(cred_buttonRect,"Credits"))
        //    {
        //        // On Click, load the first level.
        //        // "Stage1" is the name of the first scene we created.
				
        //        //StartCoroutine (WaitForSpawn ());
        //        showGUI = false;
        //    }

        //    if(GUI.Button(exit_buttonRect,"Exit"))
        //    {
        //        // On Click, load the first level.
        //        // "Stage1" is the name of the first scene we created.
        //        Application.Quit ();
        //        //StartCoroutine (WaitForSpawn ());
        //        showGUI = false;
        //    }*/
        //}
	}


	public IEnumerator WaitForSpawn()
	{
		//yield return new WaitForSeconds(3.0f);

		GameObject main_c = (GameObject) Instantiate (Golfer, new Vector3(spawn.x, spawn.y + 1f, spawn.z), Quaternion.Euler(new Vector3(0, 120, 0))) as GameObject;
		PC = GameObject.FindGameObjectWithTag ("Holy").GetComponent<PlayerController> ();
		PC.InstanBall ();
		SM_player = GameObject.FindGameObjectWithTag ("SelectManager");
		SM = SM_player.GetComponent<SelectManager> ();
		SM.player = GameObject.FindGameObjectWithTag ("Holy");
		SHP = GameObject.FindGameObjectWithTag ("Hole").GetComponent<SetHolePosition> ();
		SHP.turnOn = true;
		GM.cam_State = CameraState.CS_Player;

		TutorialInstructions temp = GameObject.Find ("TextAboveHead").GetComponent<TutorialInstructions> ();
		//temp.player = main_c;
		//temp.camera = main_c.transform.FindChild ("PlayerCamera").GetComponent<Camera> ();

		//TutorialInstructions temp = GameObject.Find ("TextAboveHead").GetComponent<TutorialInstructions> ();
		//temp.player = main_c;
		//temp.camera = main_c.transform.FindChild ("PlayerCamera").GetComponent<Camera> ();

		yield return 0;
	}

	IEnumerator WaitForTerrain()
	{
		yield return new WaitForSeconds (10.0f);
	}



	void MoveNodesDown()
	{
		GameObject[] nodes = GameObject.FindGameObjectsWithTag ("Node");
		foreach (GameObject node in nodes) {
			float steep = tg.GetSteepnessValue(node.transform.position);
			//Debug.Log (node.name + " " + steep);
			node.transform.position = new Vector3(node.transform.position.x, steep, node.transform.position.z);
			//JS_Script = node.transform.FindChild("Selected").GetComponent<JumpingScript>();
			//JS_Script.getValues = true;
		}

		terrainDone = false;
	}

    //void MainMenu()
    //{
    //    GUI.DrawTexture(new Rect(Screen.width/4,Screen.width/32,Screen.width/2, Screen.height/2 + Screen.height / 4),TextureMainMenu);
    //    GUI.BeginGroup(new Rect(0, (Screen.height / 8) * 7, Screen.width, Screen.height / 4));
    //    if (GUI.Button(new Rect((Screen.width/4) - 90, 0, 180, 45),
    //                   "Start"))
    //    {
    //        //PlayAudioClip(AcceptButtonClick);
    //        // On Click, load the first level.
    //        // "Stage1" is the name of the first scene we created.
    //        TutorialMode = true;
    //        spawn = GameObject.Find("Node 2").transform.position;
    //        float steep = GetYPos (spawn);
    //        spawn = new Vector3(spawn.x, steep, spawn.z);
    //        StartCoroutine(WaitForSpawn());
    //        showGUI = false;
    //    }
		
    //    if (GUI.Button(new Rect((Screen.width/2) -90, 0, 180, 45),
    //                   "Credits"))
    //    {
    //        currentMenu = "credits";
    //    }
		
    //    if (GUI.Button(new Rect(((Screen.width/4) * 3) - 90, 0, 180, 45),
    //                   "Exit"))
    //    {
    //        Application.Quit();
    //    }
		
    //    GUI.EndGroup();
    //}
	
    //void Credits()
    //{
    //    GUI.Label(new Rect(Screen.width/2-20, 15, 30, 100), "Credits", creditsLabel);
		
    //    GUI.Label(new Rect(Screen.width / 2 - 165, 70, 330, 25), "Steven Morgan", creditsLargeFont);
    //    GUI.Label(new Rect(Screen.width / 2 - 165, 90, 330, 50), "-Game Design-\n-Level Design-", creditsFont);
    //    GUI.Label(new Rect(Screen.width / 2 - 165, 160, 330, 25), "Jordan Max", creditsLargeFont);
    //    GUI.Label(new Rect(Screen.width / 2 - 165, 170, 330, 50), "-Lead Programmer-", creditsFont);
    //    GUI.Label(new Rect(Screen.width / 2 - 165, 240, 330, 25), "Alex Cook", creditsLargeFont);
    //    GUI.Label(new Rect(Screen.width / 2 - 165, 250, 330, 50), "-Lead Artist-", creditsFont);
    //    GUI.Label(new Rect(Screen.width / 2 - 165, 320, 330, 25), "Aric Zeeck", creditsLargeFont);
    //    GUI.Label(new Rect(Screen.width / 2 - 165, 340, 330, 50), "-User Interface-\n-Game Design-", creditsFont);
    //    GUI.Label(new Rect(Screen.width / 2 - 165, 410, 330, 25), "Edward Barton", creditsLargeFont);
    //    GUI.Label(new Rect(Screen.width / 2 - 165, 430, 330, 50), "-Music-", creditsFont);
		
    //    if (GUI.Button(new Rect((Screen.width/2) -100, (Screen.height/8) * 7, 200, 40), "Back"))
    //    {
    //        // PlayAudioClip(BackButtonClick);
    //        currentMenu = "main";
    //    }        
    //}
	
    //void Exit()
    //{
    //    Application.Quit ();
    //}

	public float GetYPos(Vector3 temp)
	{
		float steep = tg.GetSteepnessValue(temp);
		return steep;
	}


}




