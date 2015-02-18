using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {

    int screenNumber;
    public Texture2D ScreenOne;
    public Texture2D ScreenTwo;
    public Texture2D ScreenThree;
    public Texture2D ScreenFour;
    public Texture2D ScreenFive;
    public Texture2D ScreenSix;
    public Texture2D ScreenSeven;
    public Texture2D ScreenEight;
    public Texture2D ScreenNine;

    public GUIStyle hintFont;

    public GUISkin TransitionScreenStyle;

    

	// Use this for initialization
	void Start () 
    {
        screenNumber = Random.Range(1, 9);
	}
    
	
	// Update is called once per frame
	void Update () {
        
    }

        void OnGUI ()
        {
            GUI.skin = TransitionScreenStyle;
            if (screenNumber == 1)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), ScreenOne);
                GUI.Label(new Rect(0, (Screen.height / 32) * 25, Screen.width, Screen.height), "Hint 1 here", hintFont);
            }

            if (screenNumber == 2)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), ScreenTwo);
                GUI.Label(new Rect(0, (Screen.height / 32) * 25, Screen.width, Screen.height), "Hint 2 here", hintFont);
            }

            if (screenNumber == 3)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), ScreenThree);
                GUI.Label(new Rect(0, (Screen.height / 32) * 25, Screen.width, Screen.height), "Hint 3 here", hintFont);
            }
            if (screenNumber == 4)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), ScreenFour);
                GUI.Label(new Rect(0, (Screen.height / 32) * 25, Screen.width, Screen.height), "Hint 4 here", hintFont);
            }
            if (screenNumber == 5)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), ScreenFive);
                GUI.Label(new Rect(0, (Screen.height / 32) * 25, Screen.width, Screen.height), "Hint 5 here", hintFont);
            }
            if (screenNumber == 6)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), ScreenSix);
                GUI.Label(new Rect(0, (Screen.height / 32) * 25, Screen.width, Screen.height), "Hint 6 here", hintFont);
            }
            if (screenNumber == 7)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), ScreenSeven);
                GUI.Label(new Rect(0, (Screen.height / 32) * 25, Screen.width, Screen.height), "Hint 7 here", hintFont);
            }
            if (screenNumber == 8)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), ScreenEight);
                GUI.Label(new Rect(0, (Screen.height / 32) * 25, Screen.width, Screen.height), "Hint 8 here", hintFont);
            }
            if (screenNumber == 9)
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), ScreenNine);
                GUI.Label(new Rect(0, (Screen.height / 32) * 25, Screen.width, Screen.height), "Hint 9 here", hintFont);
            }
           
        }
	
}
