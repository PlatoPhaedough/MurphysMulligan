using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InGameMenu : MonoBehaviour
{
   

    bool finalHole;

    bool displayPopUpMenu;
    bool displayOptionsMenu;
    bool displayCredits;
    bool displayConfirmQuit;
    bool displayVideoOptions;
    bool displayAudioOptions;
    //bool displayHoleDoneMenu;
    bool displayHowToPlay;

    public int hintPageNumber =1;

    public Texture2D HintPageOne;
    public Texture2D HintPageTwo;
    public Texture2D HintPageThree;
    public Texture2D HintPageFour;

    //public Texture2D ScoreCard;

    public AudioClip AcceptButtonClick;
    public AudioClip BackButtonClick;

    public GUISkin InGameMenuSkin;

    public GUIStyle creditsLabel;
    public GUIStyle creditsFont;
    public GUIStyle creditsLargeFont;
    public GUIStyle holeDoneFont;

    //public GUIStyle scoreCardLabel;
    //public GUIStyle scoreCardFont;

    public float audioSFXSliderValue;
    public float audioMusicSliderValue;

    public string gamePrefsName = "DefaultGame";

    public float default_width = 720;
    public float default_height = 480;

    public float graphicsSliderValue;

    private int detailLevels = 6;

    //public int HoleOnePar = 3;
    //public int HoleTwoPar = 4;
    //public int HoleThreePar = 5;
    //public int HoleFourPar = 3;
    //public int HoleFivePar = 4;
    //public int HoleSixPar = 5;
    //public int HoleSevenPar = 3;
    //public int HoleEightPar = 4;
    //public int HoleNinePar = 5;

    //public int HoleOneScore = 1;
    //public int HoleTwoScore = 2;
    //public int HoleThreeScore = 3;
    //public int HoleFourScore = 4;
    //public int HoleFiveScore = 5;
    //public int HoleSixScore = 1;
    //public int HoleSevenScore = 2;
    //public int HoleEightScore = 3;
    //public int HoleNineScore = 4;

    //public int TotalHolePars;
    //public int TotalScore;
 
    
	// Use this for initialization
	void Start () 
    {
        //TotalHolePars = (HoleOnePar + HoleTwoPar  + HoleThreePar + HoleFourPar + HoleFivePar + HoleSixPar + HoleSevenPar + HoleEightPar + HoleNinePar);
        //    Debug.Log(TotalHolePars);
        //    TotalScore = (HoleOneScore + HoleTwoScore + HoleThreeScore + HoleFourScore + HoleFiveScore + HoleSixScore + HoleSevenScore + HoleEightScore + HoleNineScore);
        //    Debug.Log(TotalScore);
        displayPopUpMenu = false;
        displayOptionsMenu = false;
        displayCredits = false;
        displayConfirmQuit = false;
        displayVideoOptions = false;
        displayAudioOptions = false;
        //displayHoleDoneMenu = false;
        displayHowToPlay = false;
        hintPageNumber = 1;
        finalHole = false;

        // Placeholder Variables
        //currentHoleNumber = 18;
        //currentHoleStrokes = 4;
        //currentHolePar = 5;

        if (PlayerPrefs.HasKey(gamePrefsName + "_SFXVol"))
        {
            audioSFXSliderValue = PlayerPrefs.
                GetFloat(gamePrefsName + "_SFXVol");
        } 
        else 
        {
            audioSFXSliderValue = 1;
        }

        if (PlayerPrefs.HasKey(gamePrefsName + "_MusicVol"))
        {
            audioMusicSliderValue = PlayerPrefs.
                GetFloat(gamePrefsName + "_MusicVol");
        }
        else
        {
            audioMusicSliderValue = 1;
        }

        if (PlayerPrefs.HasKey(gamePrefsName + "_GraphicsDetail"))
        {
            graphicsSliderValue = PlayerPrefs.
                GetFloat(gamePrefsName + "_GraphicsDetail");
        }
        else
        {
            string[] names = QualitySettings.names;
            detailLevels = names.Length;
            graphicsSliderValue = detailLevels;
        }

        // set the quality setting
        QualitySettings.SetQualityLevel((int)graphicsSliderValue,
            true);
    }
	
	
	// Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Escape)) || ((Input.GetKeyDown(KeyCode.Joystick1Button7)))) // Displays Menu when ESC is pressed
            
            
            {
                if (displayPopUpMenu)
                {
                    displayPopUpMenu = false;
                    displayOptionsMenu = false;
                    displayConfirmQuit = false;
                    
                    displayAudioOptions = false;
                    displayVideoOptions = false;
                }

                else
                {
                    displayPopUpMenu = true;                    
                }
            }


        // Remove this code. It is only for testing
            //if ((Input.GetKeyUp(KeyCode.A) && displayPopUpMenu == false) || ((Input.GetKeyDown(KeyCode.Joystick1Button6) && displayPopUpMenu == false))) // Hole Finished Menu
            //{
            //    if (displayHoleDoneMenu)
            //    {
            //        displayHoleDoneMenu = false;
            //    }

            //    else
            //    {
            //        displayHoleDoneMenu = true;
            //    }
            //}
    }


    void OnGUI()
    {
        float resX = Screen.width / default_width;              // Makes menu
        float resY = Screen.height / default_height;            // change size  
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0),        // with screen
            Quaternion.identity, new Vector3(resX, resY, 1));   // resolution

        GUI.skin = InGameMenuSkin;

        if (displayPopUpMenu == true)
            PopUpMenu();      

            if (!displayPopUpMenu)
            {}

        if (displayOptionsMenu)            
            OptionsMenu();

            if (!displayOptionsMenu)
            { }
        
        if (displayCredits)
            Credits();

            if (!displayCredits)
            { }

        if (displayConfirmQuit)
            ConfirmQuit();

            if (!displayConfirmQuit)
            { }

        if (displayVideoOptions)
            VideoOptions();

            if (!displayVideoOptions)
            { }
  
        if (displayAudioOptions)
            SoundOptions();

            if (!displayAudioOptions)
            { }

        //if (displayHoleDoneMenu)
        //        HoleDone();
        //    if (!displayHoleDoneMenu)
        //    { }

        if (displayHowToPlay)
                HowToPlay();
            if (!displayHowToPlay)
            { }
    }
        

    void PopUpMenu()
    {
        GUI.BeginGroup(new Rect((default_width / 2) - 160, (default_height / 2) - 235, 320, 575));
        GUI.Box(new Rect(10, 0, 300, 575), "");
        GUI.Label(new Rect(107, (default_height / 32) * 3, 106, 40), "Pause Menu");
        if (GUI.Button(new Rect(35, (default_height / 32) * 5, 250, 50),
            "Options"))
        {
            //PlayAudioClip(AcceptButtonClick);
            displayOptionsMenu = true;            
        }

        if (GUI.Button(new Rect(35, (default_height / 32) * 10, 250, 50),
            "How to Play"))
        {
            //PlayAudioClip(AcceptButtonClick);
            hintPageNumber = 1;
            displayHowToPlay = true;
        }

        if (GUI.Button(new Rect(35, (default_height / 32) * 15, 250, 50),
            "Credits"))
        {
            //PlayAudioClip(AcceptButtonClick);
            displayCredits = true;
        }

        if (GUI.Button(new Rect(35, (default_height / 32) * 20, 250, 50), "Quit to main menu"))
        {
           // PlayAudioClip(AcceptButtonClick);
            displayConfirmQuit = true;
        }

        if (GUI.Button(new Rect(35, (default_height / 32) * 25, 250, 50), "Return To Game"))
        {
            //PlayAudioClip(BackButtonClick);
            displayPopUpMenu = false;
        }

        GUI.EndGroup();
    } // Closes PopUpMenu  

    void OptionsMenu()
    {
        displayPopUpMenu = false;
        GUI.BeginGroup(new Rect((default_width / 2) - 160, (default_height / 2) - 235, 320, 575));
        GUI.Box(new Rect(10, 0, 300, 575), "");
        GUI.Label(new Rect(107, (default_height / 32) * 3, 106, 40), "Options Menu");

        if (GUI.Button(new Rect(35, (default_height / 32) * 5, 250, 50),
            "Audio"))
        {
           // PlayAudioClip(AcceptButtonClick);
            displayAudioOptions = true;
        }
        if (GUI.Button(new Rect(35, (default_height / 32) * 10, 250, 50),
            "Video"))
        {
            //PlayAudioClip(AcceptButtonClick);
            displayVideoOptions = true;
        }
        if (GUI.Button(new Rect(35, (default_height / 32) * 25, 250, 50),
            "Back to Pause Menu"))
        {
            //PlayAudioClip(BackButtonClick);
            displayOptionsMenu = false;
            displayPopUpMenu = true;
        }
        GUI.EndGroup();     // end settings group
    }

    void Credits()
    {
        displayPopUpMenu = false;
        GUI.BeginGroup(new Rect((default_width / 2) - 160, (default_height / 2) - 235, 320, 575));
        GUI.Box(new Rect(10, 0, 300, 575), "");
        GUI.Label(new Rect(135, (default_height / 32) * 3, 50, 40), "Credits");

        GUI.Label(new Rect(0, (default_height / 32) * 5, 330, 25), "Steven Morgan\n", creditsLargeFont);
        GUI.Label(new Rect(0, (default_height / 32) * 6, 320, 50), "- Game Design -\n- Level Design -", creditsFont);

        GUI.Label(new Rect(0, (default_height / 32) * 9, 330, 25), "Jordan Max", creditsLargeFont);
        GUI.Label(new Rect(0, (default_height / 32) * 10, 330, 50), "- Lead Programmer -", creditsFont);

        GUI.Label(new Rect(0, (default_height / 32) * 12, 330, 25), "Alex Cook", creditsLargeFont);
        GUI.Label(new Rect(0, (default_height / 32) * 13, 330, 50), "- Lead Artist -", creditsFont);

        GUI.Label(new Rect(0, (default_height / 32) * 15, 330, 25), "Aric Zeeck", creditsLargeFont);
        GUI.Label(new Rect(0, (default_height / 32) * 16, 330, 50), "- User Interface -\n- Game Design -", creditsFont);

        GUI.Label(new Rect(0, (default_height / 32) * 19, 330, 25), "Emily Saliba", creditsLargeFont);
        GUI.Label(new Rect(0, (default_height / 32) * 20, 330, 50), "- Technichal Artist -", creditsFont);

        GUI.Label(new Rect(0, (default_height / 32) * 22, 330, 25), "Edward Barton", creditsLargeFont);
        GUI.Label(new Rect(0, (default_height / 32) * 23, 330, 50), "- Music -", creditsFont);

        GUI.EndGroup();

        if (GUI.Button(new Rect(default_width / 2 - 125, (default_height / 32) * 25, 250, 50),
            "Back to Options"))
        {
            //PlayAudioClip(BackButtonClick);
            displayCredits = false;
            displayPopUpMenu = true;
        }     
   
    }

    void ConfirmQuit()
    {
        displayPopUpMenu = false;
        GUI.BeginGroup(new Rect((default_width / 2) - 160, (default_height / 2) - 175, 320, 350));
        GUI.Box(new Rect(10, 10, 300, 350), "");
        GUI.Label(new Rect(90, 40, 144, 30), "Quit to main Menu?");
        if (GUI.Button(new Rect(35, 75, 250, 50),
            "Yes, Quit to Main Menu"))
        {
            //PlayAudioClip(AcceptButtonClick);
            //Application.LoadLevel(MainMenu);
        }

        if (GUI.Button(new Rect(35, 150, 250, 50),
            "No"))
        {
            //PlayAudioClip(BackButtonClick);
            displayConfirmQuit = false;
            displayPopUpMenu = true;
        }
        GUI.EndGroup();
    }

    void VideoOptions()
    {
        displayOptionsMenu = false;
        displayPopUpMenu = false;
        GUI.BeginGroup(new Rect((default_width / 2) - 160, (default_height / 2) - 235, 320, 550));
        GUI.Box(new Rect(10, 10, 300, 550), "");
        GUI.Label(new Rect(106, (default_height / 32) * 3,108 , 30), "Video Options");

        GUI.Label(new Rect(30, (default_height / 32) * 6, 300, 20), "Graphics quality:");
        graphicsSliderValue = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(30, (default_height / 32) * 8, 260, 50), graphicsSliderValue, 0, detailLevels));

        GUI.EndGroup();

        if (GUI.Button(new Rect(default_width / 2 - 125, (default_height / 32) * 25, 250, 50),
             "Back to Options"))
        {
            SaveOptionsPrefs();
            //PlayAudioClip(BackButtonClick);
            displayVideoOptions = false;
            displayOptionsMenu = true;
        }        
    }

    void SoundOptions()
    {
        displayOptionsMenu = false;
        displayPopUpMenu = false;
        GUI.BeginGroup(new Rect((default_width / 2) - 160, (default_height / 2) - 235, 320, 550));
        GUI.Box(new Rect(10, 10, 300, 550), "");
        GUI.Label(new Rect(106, (default_height / 32) * 3, 108, 30), "Video Options");

        GUI.Label(new Rect(30, (default_height / 32) * 6, 300, 20), "SFX volume:");
        audioSFXSliderValue = GUI.HorizontalSlider(new Rect(25, (default_height / 32) * 8, 260, 50), audioSFXSliderValue, 0.0f, 1f);

        GUI.Label(new Rect(30, (default_height / 32) * 11, 300, 20), "Music volume:");
        audioMusicSliderValue = GUI.HorizontalSlider(new Rect(25, (default_height / 32) * 13, 260, 50), audioMusicSliderValue, 0.0f, 1f);

        GUI.EndGroup();

        if (GUI.Button(new Rect(default_width / 2 - 125, (default_height / 32) * 25, 250, 50),
             "Back to Options"))
        {
            SaveOptionsPrefs();
            //PlayAudioClip(BackButtonClick);
            displayAudioOptions = false;
            displayOptionsMenu = true;
        }
    }

    //void HoleDone()
    //{        
    //        GUI.BeginGroup(new Rect((default_width / 2) - 300, (default_height / 2) - 235, 600, 550));
    //        GUI.Box(new Rect(10, 10, 600, 550), "");
    //        GUI.Label(new Rect(236, (default_height / 32) * 3, 128 , 30), "Hole " + currentHoleNumber + " Complete");

    //        GUI.Label(new Rect(100, (default_height / 32) * 8, 26, 30), "Par");
    //        GUI.Label(new Rect(95, (default_height / 32) * 10,40, 60), "" + currentHolePar, holeDoneFont);

    //        GUI.Label(new Rect(90, (default_height / 32) * 16, 58, 30), "Strokes");
    //        GUI.Label(new Rect(95, (default_height / 32) * 18, 40, 60), "" + currentHoleStrokes, holeDoneFont);

    //        GUI.EndGroup();

    //        GUI.BeginGroup(new Rect(225, 70, 400, 300));       
    //        GUI.DrawTexture(new Rect(0, 0, 400, 300), ScoreCard);

    //    // Score Card Labels
    //        GUI.Label(new Rect(25,7,100,30), "Hole Number", scoreCardLabel);
    //        GUI.Label(new Rect(185, 7, 25, 30), "Par", scoreCardLabel);
    //        GUI.Label(new Rect(310, 7, 25, 30), "Score", scoreCardLabel);
    //    GUI.Label(new Rect(25, 262, 100, 30), "Total", scoreCardLabel);

    //    // Hole Numbers
    //        GUI.Label(new Rect(25, 30, 100, 30), "1", scoreCardLabel);
    //        GUI.Label(new Rect(25, 55, 100, 30), "2", scoreCardLabel);
    //        GUI.Label(new Rect(25, 80, 100, 30), "3", scoreCardLabel);
    //        GUI.Label(new Rect(25, 107, 100, 30), "4", scoreCardLabel);
    //        GUI.Label(new Rect(25, 132, 100, 30), "5", scoreCardLabel);
    //        GUI.Label(new Rect(25, 159, 100, 30), "6", scoreCardLabel);
    //        GUI.Label(new Rect(25, 185, 100, 30), "7", scoreCardLabel);
    //        GUI.Label(new Rect(25, 210, 100, 30), "8", scoreCardLabel);
    //        GUI.Label(new Rect(25, 238, 100, 30), "9", scoreCardLabel);            
            
    //   // Hole Pars
    //        GUI.Label(new Rect(175, 30, 50, 30), "" + HoleOnePar, scoreCardFont);
    //        GUI.Label(new Rect(175, 55, 50, 30), "" + HoleTwoPar, scoreCardFont);
    //        GUI.Label(new Rect(175, 80, 50, 30), "" + HoleThreePar, scoreCardFont);
    //        GUI.Label(new Rect(175, 107, 50, 30), "" + HoleFourPar, scoreCardFont);
    //        GUI.Label(new Rect(175, 132, 50, 30), "" + HoleFivePar, scoreCardFont);
    //        GUI.Label(new Rect(175, 159, 50, 30), "" + HoleSixPar, scoreCardFont);
    //        GUI.Label(new Rect(175, 185, 50, 30), "" + HoleSevenPar, scoreCardFont);
    //        GUI.Label(new Rect(175, 210, 50, 30), "" + HoleEightPar, scoreCardFont);
    //        GUI.Label(new Rect(175, 238, 50, 30), "" + HoleNinePar, scoreCardFont);
    //        GUI.Label(new Rect(175, 262, 50, 30), "" + TotalHolePars, scoreCardFont);

    //    // Hole Scores
    //        GUI.Label(new Rect(300, 30, 50, 30), "" + HoleOneScore, scoreCardFont);
    //        GUI.Label(new Rect(300, 55, 50, 30), "" + HoleTwoScore, scoreCardFont);
    //        GUI.Label(new Rect(300, 80, 50, 30), "" + HoleThreeScore, scoreCardFont);
    //        GUI.Label(new Rect(300, 107, 50, 30), "" + HoleFourScore, scoreCardFont);
    //        GUI.Label(new Rect(300, 132, 50, 30), "" + HoleFiveScore, scoreCardFont);
    //        GUI.Label(new Rect(300, 159, 50, 30), "" + HoleSixScore, scoreCardFont);
    //        GUI.Label(new Rect(300, 185, 50, 30), "" + HoleSevenScore, scoreCardFont);
    //        GUI.Label(new Rect(300, 210, 50, 30), "" + HoleEightScore, scoreCardFont);
    //        GUI.Label(new Rect(300, 238, 50, 30), "" + HoleNineScore, scoreCardFont);
    //        GUI.Label(new Rect(300, 262, 50, 30), "" + TotalScore, scoreCardFont);

    //        GUI.EndGroup();

    //        if (!finalHole)
    //        {
    //            if (GUI.Button(new Rect((default_width / 2) - 125, (default_height / 32) * 25, 250, 50),
    //                "Next Hole"))
    //            {
    //                PlayAudioClip(AcceptButtonClick);
    //                //Application.LoadLevel(NextHole);
    //            }
    //        }

    //    if (finalHole)
    //    {
    //        if (GUI.Button(new Rect((default_width / 2) - 125, (default_height / 32) * 25, 250, 50),
    //            "Main Menu"))
    //        {
    //            PlayAudioClip(AcceptButtonClick);
    //            //Application.LoadLevel(NextHole);
    //        }
    //    }
    //    GUI.EndGroup();
    //}

    void HowToPlay()
    {        
        displayPopUpMenu = false;
        GUI.BeginGroup(new Rect((default_width / 2) - 350, (default_height / 2) - 235, 700, 550));
        GUI.Box(new Rect(10, 10, 700, 550), "");
        GUI.Label(new Rect(302, (default_height / 32) * 3, 96, 30), "How To Play");
        Debug.Log("Hint page # = " + hintPageNumber);

        if (hintPageNumber == 1)
        {
            GUI.DrawTexture(new Rect(100, (default_height / 32) * 5, 500, (default_height / 32) * 17), HintPageOne);
            GUI.Label(new Rect(0, (Screen.height / 32) * 24, default_width, 40), "How to play instruction 1", creditsFont);
            if (GUI.Button(new Rect((default_width / 3 * 1) - 125, (default_height / 32) * 25, 250, 50),
             "Back to Options"))
            {
                //PlayAudioClip(BackButtonClick);
                hintPageNumber =1;
                displayHowToPlay = false;
                displayPopUpMenu = true;
            }

            if (GUI.Button(new Rect((default_width / 3 * 2) - 125, (default_height / 32) * 25, 250, 50),
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
                GUI.Label(new Rect(0, (Screen.height / 32) * 24, default_width, 40), "How to play instruction 2", creditsFont);
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
                GUI.Label(new Rect(0, (Screen.height / 32) * 24, default_width, 40), "How to play instruction 3", creditsFont);
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
                GUI.Label(new Rect(0, (Screen.height / 32) * 24, default_width, 40), "How to play instruction 4", creditsFont);
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
                    displayPopUpMenu = false;
                }
            }       

        GUI.EndGroup();
    }

    void SaveOptionsPrefs()
    {
        PlayerPrefs.SetFloat(gamePrefsName + "_SFXVol", audioSFXSliderValue);
        PlayerPrefs.SetFloat(gamePrefsName + "_MusicVol", audioMusicSliderValue);
        PlayerPrefs.SetFloat(gamePrefsName + "_GraphicsDetail", graphicsSliderValue);

        // Set the quality setting
        QualitySettings.SetQualityLevel((int)graphicsSliderValue, true);
    }

    void PlayAudioClip(AudioClip audioClip)
    {
        audio.clip = audioClip;
        audio.Play();
    }   

} // Closes Script
