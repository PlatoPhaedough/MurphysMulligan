using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using SimpleJSON;
using System.Text.RegularExpressions;

public class ScoreCard : MonoBehaviour {

    public int currentHoleNumber;
    public int currentHolePar;
    public int currentHoleStrokes;

    public AudioClip AcceptButtonClick;
    public AudioClip BackButtonClick;

    bool finalHole;

    bool displayScore = false;

    public Texture2D ScoreCardImage;

    public GUISkin InGameMenuSkin;

    public GUIStyle holeDoneFont;
    public GUIStyle scoreCardLabel;
    public GUIStyle scoreCardFont;

    public float default_width = 720;
    public float default_height = 480;

    public int HoleOnePar = 3;

    public int HoleOneScore = 1;

    public int TotalHolePars;
    public int TotalScore;

	public List<string> l_o_holeValue;
	public List<int> l_o_holeID, l_o_Score;
	private bool checkDBForScore = true;

	// Use this for initialization
	void Start () 
    {
		TotalHolePars = 10;
        //Debug.Log(TotalHolePars);
		TotalScore = 10;
        //Debug.Log(TotalScore);

        currentHoleNumber = 18;
        currentHoleStrokes = 4;
        currentHolePar = 5;
		l_o_holeValue = new List<string> ();
		l_o_holeID = new List<int> ();
		l_o_Score = new List<int> ();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            displayScore = true;
        }
    }

    void OnGUI()
    {
        float resX = Screen.width / default_width;              // Makes menu
        float resY = Screen.height / default_height;            // change size  
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0),        // with screen
            Quaternion.identity, new Vector3(resX, resY, 1));   // resolution

        GUI.skin = InGameMenuSkin;

        if (displayScore == true)
        {
            GUI.BeginGroup(new Rect((default_width / 2) - 300, (default_height / 2) - 235, 600, 550));
            GUI.Box(new Rect(10, 10, 600, 550), "");
            GUI.Label(new Rect(236, (default_height / 32) * 3, 128, 30), "Hole " + currentHoleNumber + " Complete");

            GUI.Label(new Rect(100, (default_height / 32) * 8, 26, 30), "Par");
            GUI.Label(new Rect(95, (default_height / 32) * 10, 40, 60), "" + currentHolePar, holeDoneFont);

            GUI.Label(new Rect(90, (default_height / 32) * 16, 58, 30), "Strokes");
            GUI.Label(new Rect(95, (default_height / 32) * 18, 40, 60), "" + currentHoleStrokes, holeDoneFont);

            GUI.EndGroup();

            GUI.BeginGroup(new Rect(225, 70, 400, 300));
            GUI.DrawTexture(new Rect(0, 0, 400, 300), ScoreCardImage);

            // Score Card Labels
            GUI.Label(new Rect(25, 7, 100, 30), "Hole Number", scoreCardLabel);
            GUI.Label(new Rect(185, 7, 25, 30), "Par", scoreCardLabel);
            GUI.Label(new Rect(310, 7, 25, 30), "Score", scoreCardLabel);
            GUI.Label(new Rect(25, 262, 100, 30), "Total", scoreCardLabel);

			if(checkDBForScore)
			{
				//db connect
				string url = "http://jdmdev.net/service.php";
				WWW www = new WWW(url);
				StartCoroutine(WaitForRequest(www));
				checkDBForScore = false;
			}

            // Hole Numbers
            GUI.Label(new Rect(25, 30, 100, 30), "1", scoreCardLabel);

            // Hole Pars
            GUI.Label(new Rect(175, 30, 50, 30), "" + HoleOnePar, scoreCardFont);

            // Hole Scores
            GUI.Label(new Rect(300, 30, 50, 30), "" + HoleOneScore, scoreCardFont);

            GUI.EndGroup();

            if (!finalHole)
            {
                if (GUI.Button(new Rect((default_width / 2) - 125, (default_height / 32) * 25, 250, 50),
                    "Next Hole"))
                {
                    PlayAudioClip(AcceptButtonClick);
                    //Application.LoadLevel(NextHole);
                }
            }

            if (finalHole)
            {
                if (GUI.Button(new Rect((default_width / 2) - 125, (default_height / 32) * 25, 250, 50),
                    "Main Menu"))
                {
                    PlayAudioClip(AcceptButtonClick);
                    //Application.LoadLevel(NextHole);
                }
            }
            GUI.EndGroup();
        }
        else
        {
        }
    }

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			JSONNode N = JSON.Parse (www.data);
			//Debug.Log (N.ToString ());
			for(int i = 0; i < N.Count; i++)
			{
				Debug.Log (N[i]["HoleID"].ToString ());
				Debug.Log (N[i]["HoleValue"].ToString ());
				Debug.Log (N[i]["Score"].ToString ());
				l_o_holeID.Add(Convert.ToInt32 (N[i]["HoleID"]));
				l_o_holeValue.Add(N[i]["HoleValue"].ToString ());
				l_o_Score.Add(Convert.ToInt32 (N[i]["Score"]));


				/*string[] cb_remove = N[i].ToString().Split('{');
				string cb_remove2 = cb_remove[1].Split ('}')[0];
				string[] get_final_array = cb_remove2.Split (',');
				
				string[] list_of_data = new string[get_final_array.Length];
				int idx = 0;
				int array_count = 0;
				
				foreach(string item in get_final_array)
				{
					if(idx % 4 == 0)
					{
						array_count++;
						string key = item.Split ('\"')[1];
						string value = item.Split ('\"')[3];
						list_of_data[array_count] += key + "  " + value + Environment.NewLine;
						//list_of_data[array_count] += "key: " + key + " value: " + value + Environment.NewLine;
						
					} else {
						string key = item.Split ('\"')[1];
						string value = item.Split ('\"')[3];
						list_of_data[array_count] += key + "  " + value + Environment.NewLine;
						//list_of_data[array_count] += "key: " + key + " value: " + value + Environment.NewLine;
					}
					idx++;
				}
				
				foreach(string item2 in list_of_data)
				{
					//if(item2 != null)
					//Debug.Log (item2);
				}*/
			}
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

    
void PlayAudioClip(AudioClip audioClip)
    {
        audio.clip = audioClip;
        audio.Play();
    }   
}

