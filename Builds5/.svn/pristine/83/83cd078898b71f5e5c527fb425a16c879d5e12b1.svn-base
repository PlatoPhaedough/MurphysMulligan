using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenuManager : MonoBehaviour
{
    public float audioSFXSliderValue;
    public float audioMusicSliderValue;

    public string gamePrefsName = "DefaultGame";

    public float default_width = 720;
    public float default_height = 480;

    public float graphicsSliderValue;

    private int detailLevels = 6;   
    
    int groupWidth = 750;                   // width of the main GUI group   
    Rect buttnRect = new Rect(0, 120, 130, 30);  

    public AudioClip MenuMusic;
    public AudioClip AcceptButtonClick;
    public AudioClip BackButtonClick;

    public GUISkin mainMenuSkin;

    public Texture2D TextureMainMenu;

    private string currentMenu;
    
    // Main Menu
    public GUIStyle MainMenuButton;
    public GUIStyle creditsLabel;
    public GUIStyle creditsFont;
    public GUIStyle creditsLargeFont;
    public GUIStyle murphysFont;
    public GUIStyle mulliganFont;

    public GUIStyle menuButton;

    // Credits
    public GUIStyle customCreditsBox;
    public GUIStyle customCreditsLabel;
    public GUIStyle customCreditsDrop;

    // Options

    
    // Use this for initialization
    void Start()
    {
        currentMenu = "main";
        // Setup default options, if they have been saved out to prefs already
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

    }


    void OnGUI()
    {
        float resX = Screen.width / default_width;
        float resY = Screen.height / default_height;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0),
            Quaternion.identity, new Vector3(resX, resY, 1));

        GUI.skin = mainMenuSkin;
        // Main Menu Options
        if (currentMenu == "main")
            MainMenu();
        else if (currentMenu == "options")
            Options();
        else if (currentMenu == "audio")
            Audio();
        else if (currentMenu == "graphics")
            Graphics();
        else if (currentMenu == "credits")
            Credits();        
        else if (currentMenu == "confirmQuit")
            ConfirmQuit();
    }

    void MainMenu()
    {
        GUI.DrawTexture(new Rect((default_width / 2) - 225, (default_height /2) - 250, 450, 400), TextureMainMenu);

        //GUI.Label(new Rect(0, (default_height / 32) * 2, default_with, default_height / 3), "", murphysFont);
        //GUI.Label(new Rect((default_width / 2) -75, default_height / 6, default_width / 2,default_height / 4), "", mulliganFont);
        Event e = Event.current;

        GUI.BeginGroup(new Rect((default_width/2) - ((default_width / 12) *5), (default_height / 16) * 1, default_width, 500));
        if (GUI.Button(new Rect(0,320,250,35),
            "Start", "button") || (e.isKey && e.keyCode == KeyCode.Return))
        {
            PlayAudioClip(AcceptButtonClick);
            Debug.Log("hh");
            // LoadLevel (SceneNameHere); 
			Application.LoadLevel ("SimpleProceduralTerrain");
        }

        if (GUI.Button(new Rect(0,380,250,35),
            "Options"))
        {
            PlayAudioClip(AcceptButtonClick);
            currentMenu = "options";
        }

        if (GUI.Button(new Rect(350,320,250,35),
            "Credits"))
        {
            PlayAudioClip(AcceptButtonClick);
            currentMenu = "credits";
        }

        if (GUI.Button(new Rect(350,380,250,35),
            "Exit"))
        {
            PlayAudioClip(AcceptButtonClick);
            currentMenu = "confirmQuit";
        }

        GUI.EndGroup();
    }

    void Options()
    {

        GUI.BeginGroup(new Rect(default_width / 4, 0, (default_height / 4) * 3, Screen.height));
        GUI.Label(new Rect((default_width / 4) - 90, (default_height / 32) * 1, 180, 100),
            "Options", creditsLabel);
        GUI.Box(new Rect(0, (default_height / 32) * 3, (default_width / 4) * 2, (default_height / 32) * 30), "");

        
        if (GUI.Button(new Rect(((default_width / 4) - 150), (default_height / 32) * 6, 300, 50),
            "Audio"))
        {
            PlayAudioClip(AcceptButtonClick);
            currentMenu = "audio";
        }
        if (GUI.Button(new Rect(((default_width / 4) -150), (default_height / 32) * 11, 300, 50),
            "Video"))
        {
            PlayAudioClip(AcceptButtonClick);
            currentMenu = "graphics";
        }
        if (GUI.Button(new Rect(default_width / 4 - 150, (default_height / 32) * 26, 300, 50),
            "Back to Main Menu"))
        {
            PlayAudioClip(BackButtonClick);
            currentMenu = "main";
        }
        GUI.EndGroup();     // end settings group
    }

    void Credits()
    {
        GUI.BeginGroup(new Rect(default_width / 4, 0, (default_width / 4) * 3, Screen.height));
        GUI.Label(new Rect((default_width / 4) - 90, (default_height / 32) * 1, 180, 100),
            "Credits", creditsLabel);
        GUI.Box(new Rect(0, (default_height / 32) * 3, (default_width / 4) * 2, (default_height / 32) * 30), "");

        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 5, 330, 25), "Steven Morgan\n", creditsLargeFont);
        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 6, 330, 50), "- Game Design -\n- Level Design -", creditsFont);

        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 9, 330, 25), "Jordan Max", creditsLargeFont);
        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 10, 330, 50), "- Lead Programmer -", creditsFont);

        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 12, 330, 25), "Alex Cook", creditsLargeFont);
        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 13, 330, 50), "- Lead Artist -", creditsFont);

        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 15, 330, 25), "Aric Zeeck", creditsLargeFont);
        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 16, 330, 50), "- User Interface -\n- Game Design -", creditsFont);

        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 19, 330, 25), "Emily Saliba", creditsLargeFont);
        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 20, 330, 50), "- Technichal Artist -", creditsFont);

        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 22, 330, 25), "Edward Barton", creditsLargeFont);
        GUI.Label(new Rect(default_width / 4 - 165, (default_height / 32) * 23, 330, 50), "- Music -", creditsFont);


        if (GUI.Button(new Rect(default_width / 4 - 150, (default_height / 32) * 26, 300, 50),
            "Back to Main Menu"))
        {
           PlayAudioClip(BackButtonClick);
            currentMenu = "main";
        }        
    }

   
    void ConfirmQuit()
    {
        GUI.BeginGroup(new Rect(default_width / 4, (default_height / 2) - ((default_height / 32) * 11 ), (default_height / 4) * 3, Screen.height));
        GUI.Label(new Rect((default_width / 4) - 67, (default_height / 32) * 1, 134, 100),
            "Exit Game?", creditsLabel);
        GUI.Box(new Rect(0, (default_height / 32) * 4, (default_width / 4) * 2, (default_height / 32) * 22), "");       
        

        if (GUI.Button(new Rect(default_width / 4 - 150, (default_height / 32) * 7, 300, 50), "Yes, Quit"))
        {
            PlayAudioClip(AcceptButtonClick);
            Application.Quit();
        }

        if (GUI.Button(new Rect(default_width / 4 - 150, (default_height / 32) * 13, 300, 50), "No, Don't Quit"))
        {
            PlayAudioClip(BackButtonClick);
            currentMenu = "main";
        }
        GUI.EndGroup();
    }

    void Audio()
    {
        GUI.BeginGroup(new Rect(default_width / 4, 0, (default_height / 4) * 3, Screen.height));
        GUI.Label(new Rect((default_width / 4) - 90, (default_height / 32) * 1, 180, 100),
            "Audio Options", creditsLabel);
        GUI.Box(new Rect(0, (default_height / 32) * 3, (default_width / 4) * 2, (default_height / 32) * 30), "");       
        

        GUI.Label(new Rect(25, (default_height / 32) * 6, 300, 20), "SFX Volume:");
        audioSFXSliderValue = GUI.HorizontalSlider(new Rect(25, (default_height / 32) * 8, 300, 50), audioSFXSliderValue, 0.0f, 1f);

        GUI.Label(new Rect(25, (default_height / 32) * 11, 300, 20), "Music Volume:");
        audioMusicSliderValue = GUI.HorizontalSlider(new Rect(25, (default_height / 32) * 13, 300, 50), audioMusicSliderValue, 0.0f, 1f);

        if (GUI.Button(new Rect(default_width / 4 - 150, (default_height / 32) * 26, 300, 50),
            "Back to Options"))
        {
            SaveOptionsPrefs();
            PlayAudioClip(BackButtonClick);
            currentMenu = "options";
        }
        GUI.EndGroup();
    }

    void Graphics()
    {
        GUI.BeginGroup(new Rect(default_width / 4, 0, (default_height / 4) * 3, Screen.height));
        GUI.Label(new Rect((default_width / 4) - 110, (default_height / 32) * 1, 220, 100),
            "Graphics Options", creditsLabel);
        GUI.Box(new Rect(0, (default_height / 32) * 3, (default_width / 4) * 2, (default_height / 32) * 30), "");

        GUI.Label(new Rect(25, (default_height / 32) * 6, 300, 20), "Graphics Quality:");
        graphicsSliderValue = Mathf.RoundToInt(GUI.HorizontalSlider(new Rect(30, (default_height / 32) * 8, 300, 50), graphicsSliderValue, 0, detailLevels));

        if (GUI.Button(new Rect(default_width / 4 - 150, (default_height / 32) * 26, 300, 50),
             "Back to Options"))
        {
            SaveOptionsPrefs();
            PlayAudioClip(BackButtonClick);
            currentMenu = "options";
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
} 