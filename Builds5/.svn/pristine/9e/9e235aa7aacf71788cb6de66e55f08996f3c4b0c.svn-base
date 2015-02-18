using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PreGameInstructions : MonoBehaviour
{
    bool displayHowToPlay;

    public int hintPageNumber;

    public Texture2D HintPageOne;
    public Texture2D HintPageTwo;
    public Texture2D HintPageThree;
    public Texture2D HintPageFour;
   
    public AudioClip AcceptButtonClick;
    public AudioClip BackButtonClick;

    public GUISkin InGameMenuSkin;
    public bool test = true;

    public GUIStyle creditsLabel;
    public GUIStyle creditsFont;
    public GUIStyle creditsLargeFont;
    //public GUIStyle holeDoneFont;    

    public float default_width = 720;
    public float default_height = 480;    
 
    
	// Use this for initialization
	void Start () 
    {
        
        displayHowToPlay = true;
        hintPageNumber = 1;      
    }
	
	
	// Update is called once per frame
    void Update()
    {
       
    }


    void OnGUI()
    {
        float resX = Screen.width / default_width;              // Makes menu
        float resY = Screen.height / default_height;            // change size  
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0),        // with screen
            Quaternion.identity, new Vector3(resX, resY, 1));   // resolution

        GUI.skin = InGameMenuSkin;        

        if (displayHowToPlay)
                HowToPlay();
            if (!displayHowToPlay)
            { }
    }
        

   

    void HowToPlay()    {        
        
        GUI.BeginGroup(new Rect((default_width / 2) - 350, (default_height / 2) - 235, 700, 550));
        GUI.Box(new Rect(10, 10, 700, 550), "");
        GUI.Label(new Rect(302, (default_height / 32) * 3, 96, 30), "How To Play");
        Debug.Log("Hint page # = " + hintPageNumber);

        if (hintPageNumber == 1)
        {
            GUI.DrawTexture(new Rect(100, (default_height / 32) * 5, 500, (default_height / 32) * 17), HintPageOne);
            GUI.Label(new Rect(0, (default_height / 32) * 21, default_width, 40), "How to play instruction 1", creditsFont);
            //if (GUI.Button(new Rect((default_width / 3 * 1) - 125, (default_height / 32) * 25, 250, 50),
            // "Back to Options"))
            //{
            //    //PlayAudioClip(BackButtonClick);
            //    hintPageNumber =1;
            //    displayHowToPlay = false;                
            //}

            if (GUI.Button(new Rect((default_width / 2) - 125, (default_height / 32) * 25, 250, 50),
                 "Next"))
            {
                //PlayAudioClip(AcceptButtonClick);
                Debug.Log("Hint page # = " + hintPageNumber);
                hintPageNumber = 2;
                Debug.Log("Hint page # = " + hintPageNumber);
            }
        }

            if (hintPageNumber == 2)
            {
                GUI.DrawTexture(new Rect(100, (default_height / 32) * 5, 500, (default_height / 32) * 17), HintPageTwo);
                GUI.Label(new Rect(0, (default_height / 32) * 21, default_width, 40), "How to play instruction 2", creditsFont);
                if (GUI.Button(new Rect((default_width / 3 * 1) - 125, (default_height / 32) * 25, 250, 50),
                 "Back"))
                {
                    //PlayAudioClip(BackButtonClick);
                    hintPageNumber = 1;                    
                }

                if (GUI.Button(new Rect((default_width / 3 * 2) - 125, (default_height / 32) * 25, 250, 50),
                     "Next"))
                {
                    //PlayAudioClip(AcceptButtonClick);
                    hintPageNumber = 3;
                }
            }

            if (hintPageNumber == 3)
            {
                GUI.DrawTexture(new Rect(100, (default_height / 32) * 5, 500, (default_height / 32) * 17), HintPageThree);
                GUI.Label(new Rect(0, (default_height / 32) * 21, default_width, 40), "How to play instruction 3", creditsFont);
                if (GUI.Button(new Rect((default_width / 3 * 1) - 125, (default_height / 32) * 25, 250, 50),
                 "Back"))
                {
                    //PlayAudioClip(BackButtonClick);
                    hintPageNumber = 2;
                }

                if (GUI.Button(new Rect((default_width / 3 * 2) - 125, (default_height / 32) * 25, 250, 50),
                     "Next"))
                {
                    //PlayAudioClip(AcceptButtonClick);
                    hintPageNumber = 4;
                }
            }

            if (hintPageNumber == 4)
            {
                GUI.DrawTexture(new Rect(100, (default_height / 32) * 5, 500, (default_height / 32) * 17), HintPageFour);
                GUI.Label(new Rect(0, (default_height / 32) * 21, default_width, 40), "How to play instruction 4", creditsFont);
                if (GUI.Button(new Rect((default_width / 3 * 1) - 125, (default_height / 32) * 25, 250, 50),
                 "Back"))
                {
                    //PlayAudioClip(BackButtonClick);
                    hintPageNumber = 3;
                }

                if (GUI.Button(new Rect((default_width / 3 * 2) - 125, (default_height / 32) * 25, 250, 50),
                     "Done"))
                {
                   // PlayAudioClip(AcceptButtonClick);
                    hintPageNumber = 1;
                    displayHowToPlay = false;
                    PlayerTest PT = GameObject.FindGameObjectWithTag("gameManager").GetComponent<PlayerTest>();
					Vector3 tempPos = GameObject.Find("Node 3").transform.position;
					Vector3 convert = new Vector3();
					convert.x = tempPos.x;
					convert.y = PT.GetYPos(tempPos);
					convert.z = tempPos.z;
					Debug.Log (convert);
					PT.spawn = convert;
					
					StartCoroutine(PT.WaitForSpawn());
                }
            }
        GUI.EndGroup();
    }
} // Closes Script
