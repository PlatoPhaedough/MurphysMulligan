using UnityEngine;
using System.Collections;

public class ThreeSixtyMenuTest : MonoBehaviour {

public GUIStyle DefaultButton;
public GUIStyle SelectedButton;

public GUISkin mainMenuSkin;

public string currentMenu = "main menu";

public bool returnReleased;


    
string[] mainMenuOptions = new string[4] {"Start", "Help", "Credits", "Quit"};

string[] creditsMenuOptions = new string[3] { "Help Menu", "Credits Option 2", "Back" };

string[] helpMenuOptions = new string[3] { "Help Option 1", "Help Option 2", "Back" };

bool switched = false;
// Default selected menu item (in this case, Tutorial).
 int selectedIndex = 0;

  void Start ()
     {
        
     }

// Function to scroll through possible menu items array, looping back to start/end depending on direction of movement.
 public int menuSelection (string[] menuItems, int selectedItem, string direction) {
    if (direction == "up") {
        
        if (selectedItem == 0) {
            selectedItem = menuItems.Length - 1;
        } else {
            selectedItem -= 1;
        }
    }

    if (direction == "down") {
        
        if (selectedItem == menuItems.Length - 1) {
            selectedItem = 0;
        } else {
            selectedItem += 1;
        }
    }
    
    return selectedItem;
}
void Update ()
{
    if ((Input.GetKeyUp(KeyCode.DownArrow) && switched == false) || (Input.GetKeyDown(KeyCode.Joystick1Button4) && switched == false)) {
        if (currentMenu == "main menu")
        {
        selectedIndex = menuSelection(mainMenuOptions, selectedIndex, "down");        
        }

        if (currentMenu == "credits")
        {           
            selectedIndex = menuSelection(creditsMenuOptions, selectedIndex, "down"); 
        }

        if (currentMenu == "help")
        {
            selectedIndex = menuSelection(helpMenuOptions, selectedIndex, "down");
        }

    } // Close IF DOWN statment
    if ((Input.GetKeyUp(KeyCode.UpArrow) && switched == false) || (Input.GetKeyDown(KeyCode.Joystick1Button5) && switched == false)) 
    {
        
        if (currentMenu == "main menu")
        {
            selectedIndex = menuSelection(mainMenuOptions, selectedIndex, "up");
        }

        if (currentMenu == "credits")
        {
            selectedIndex = menuSelection(creditsMenuOptions, selectedIndex, "up"); 
        }
        
        if (currentMenu == "help")
        {
            selectedIndex = menuSelection(helpMenuOptions, selectedIndex, "up");
        }       
    } // Close IF UP statment


    //if (Input.GetButtonDown("A_1"))
    //{
    //    handleSelection();
    //}
    //if (Input.GetAxis("L_YAxis_1") == 0)
    //{
    //    switched = false;
    //}

    
}
void handleSelection()
{
    GUI.FocusControl (mainMenuOptions[selectedIndex]);

    switch (selectedIndex)
    {
        case 0:
               Debug.Log("Selected name: " + GUI.GetNameOfFocusedControl () + " / id: " +selectedIndex);

               break;
        case 1:
               Debug.Log("Selected name: " + GUI.GetNameOfFocusedControl () + " / id: " +selectedIndex);
               break;
        case 2:
               Debug.Log("Selected name: " + GUI.GetNameOfFocusedControl () + " / id: " +selectedIndex);
               break;
        case 3:
               Debug.Log("Selected name: " + GUI.GetNameOfFocusedControl () + " / id: " +selectedIndex);
               break;        
        default:
               Debug.Log ("None of the above selected..");
               break;
    }

}
void OnGUI ()
{
   // GUI.skin = mainMenuSkin;

    if (currentMenu == "main menu")
    {
        MainMenu();
    }

    if (currentMenu == "credits")
    {
        Credits();
    }

    if (currentMenu == "help")
    {
        Help();
    }    
}

void MainMenu()
{
    Event e = Event.current;

    GUI.SetNextControlName("Start");
    if (selectedIndex != 0)
    {
        if (GUI.Button(new Rect(10, 70, 170, 30), "Start"))
        {
            selectedIndex = 0;
            Debug.Log("Start pressed one");
            handleSelection();
        }
    }

    else
    {
        if (GUI.Button(new Rect(10, 70, 170, 30), "Start") || (e.isKey && e.keyCode == KeyCode.Return))
        {
            selectedIndex = 0;
            Debug.Log("Start Pressed");
            handleSelection();
            
        }
    }

    GUI.SetNextControlName("Help");
    if (selectedIndex != 1)
    {
        if (GUI.Button(new Rect(10, 120, 170, 30), "Help"))
        {
            selectedIndex = 1;

            handleSelection();
        }
    }

    else
    {
        if (GUI.Button(new Rect(10, 120, 170, 30), "Help") || (e.isKey && e.keyCode == KeyCode.Return))
        {
            selectedIndex = 1;            
            handleSelection();
            currentMenu = "help";
            selectedIndex = 0;
        }
    }

    GUI.SetNextControlName("Credits");
    if (selectedIndex != 2)
    {
        if (GUI.Button(new Rect(10, 170, 170, 30), "Credits"))
        {
            selectedIndex = 2;
            handleSelection();
        }
    }

    else
    {
        if (GUI.Button(new Rect(10, 170, 170, 30), "Credits") || (e.isKey && e.keyCode == KeyCode.Return))
        {
            selectedIndex = 1;
            handleSelection();
            currentMenu = "credits";
            selectedIndex = 0;
            returnReleased = false;
            
        }
    }

    GUI.SetNextControlName("Quit");
    if (selectedIndex != 3)
    {
        if (GUI.Button(new Rect(10, 220, 170, 30), "Quit"))
        {
            selectedIndex = 3;
            handleSelection();
        }
    }

    else
    {
        if (GUI.Button(new Rect(10, 220, 170, 30), "Quit"))
        {
            selectedIndex = 3;
            handleSelection();
        }
    }
    GUI.FocusControl(mainMenuOptions[selectedIndex]);
}

void Credits()
{
    
    GUI.FocusControl(creditsMenuOptions[selectedIndex]);
    Event e = Event.current;

    if (returnReleased == false)
    {
        //if (
    }

    GUI.SetNextControlName("Help Menu");
    if (selectedIndex != 0)
    {
        if (GUI.Button(new Rect(10, 70, 170, 30), "Help Menu"))
        {
            selectedIndex = 0;
            handleSelection();
        }
    }

    else
    {
        if (GUI.Button(new Rect(10, 70, 170, 30), "Help Menu") || (e.isKey && e.keyCode == KeyCode.Return))
        {
            selectedIndex = 0;
            handleSelection();
            currentMenu = "help";
        }
    }

    GUI.SetNextControlName("Credits Option 2");
    if (selectedIndex != 1)
    {
        if (GUI.Button(new Rect(10, 120, 170, 30), "Credits Option 2"))
        {
            selectedIndex = 1;

            handleSelection();
        }
    }

    else
    {
        if (GUI.Button(new Rect(10, 120, 170, 30), "Credits Option 2"))
        {
            selectedIndex = 1;
            handleSelection();
        }
    }

    GUI.SetNextControlName("Back");
    if (selectedIndex != 2)
    {
        if (GUI.Button(new Rect(10, 170, 170, 30), "Back"))
        {
            selectedIndex = 2;
            handleSelection();
        }
    }

    else
    {
        if (GUI.Button(new Rect(10, 170, 170, 30), "Back") || (e.isKey && e.keyCode == KeyCode.Return))
        {
            selectedIndex = 1;
            Debug.Log("Back Button Pressed");
            handleSelection();
            currentMenu = "main menu";
            selectedIndex = 0; 
        }
    }
}

void Help()
{

}
}
 
