using UnityEngine;
using System.Collections;
using System;
using System.Data;
using System.Data.SqlClient;
using SimpleJSON;
using System.Text.RegularExpressions;

public class Database : MonoBehaviour {

		// Use this for initialization
		
		void Start()
		{
			string url = "http://jdmdev.net/service.php";
			WWW www = new WWW(url);
			StartCoroutine(WaitForRequest(www));
		}
		
		IEnumerator WaitForRequest(WWW www)
		{
			yield return www;
			
			// check for errors
			if (www.error == null)
			{
				JSONNode N = JSON.Parse (www.data);
				for(int i = 0; i < N.Count; i++)
				{
					string[] cb_remove = N[i].ToString().Split('{');
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
						if(item2 != null)
							Debug.Log (item2);
					}
				}
			} else {
				Debug.Log("WWW Error: "+ www.error);
			}    
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
