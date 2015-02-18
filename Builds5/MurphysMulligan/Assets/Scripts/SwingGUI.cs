using UnityEngine;
using System.Collections;

public class SwingGUI : MonoBehaviour
{
    public int curveBarWidth = 50;
    public int curveBarLength = 300;
    public int curveBarVirticalPosition = 350;
    public int curveBarHorizontalPosition = 50;

    public int customBarWidths = 25;

    public int powerBarWidth = 50;
    public int powerBarLength = 300;
    public int powerBarVirticalPosition = 0;
    public int powerBarHorizontalPosition = 0;
    private int finalPower, finalCurve;
    
    public float default_width = 720;
    public float default_height = 480;

    //* Menu Logic Bools    
    public bool displaySwingGUI;    // Displays Swing GUI when ENTER is pressed
    public bool spaceBarReleased;   // Insures spacebar is released between curve and power input
    public bool returnReleased;
    public bool inPreSwing;         // 1. Allows player to input desired curve and power
    public bool inSwingCurve;       // 2. Player attempts to hit perfect curve
    public bool inSwingPower;       // 3. Player attempts to hit perfect power    
    public bool inPostSwing;        // 4. Calculates power and curve during post swing

    //* GUI STYLES
        public GUISkin _theSkin = null;

        //** Curve GUI Styles
        public GUIStyle customCurve;            // Dark blue bar
        public GUIStyle customeFullCurve;       // Light blue bar
        public GUIStyle customDesiredCurve;     // Red portion of desired curve bar
        public GUIStyle customPerfectCurve;     // Green portion of desired curve bar

        //** Power GUI Styles
        public GUIStyle customPower;            // Dark Blue bar
        public GUIStyle customFullPower;        // Light Blue Bar
        public GUIStyle customDesiredPower;     // Red portion of desired power bar
        public GUIStyle customPerfectPower;     // Green portion of desired power bar

    //* CURVE AND POWER VARIABLEs
        //** Curve variables
            public float finalSwingCurve;                 // Final calculated curve that should be passed to nodes to determine where ball actually curves too
            public float desiredCurve;                    // Should be passed to node generator to determine target node
            public int currentSwingCurve = 1;                  // Swing curve selected by player via flucuating GUI bar

            private int maxSwingCurve = 300;
            private int minSwingCurve = 0;
            public float swingCurveBarLength;       
            public bool swingCurveIncrease;             // Deterimines if the swing curve bar should increase

        //** Power Variables
            public float finalSwingPower;                 // Final calculated power that should be passed to nodes to determine where ball actually goes.
            public float desiredPower;                // Should be passed to node generator to determine taget node
            int currentSwingPower = 1;                 // Swing Power selected by player via flucuating GUI bar

            public float selected_value, offset;

            int maxSwingPower = 300;
            int minSwingPower = 0;   
            public float swingPowerBarLength;
            public bool swingPowerIncrease;
			public int powerDifference;// Determines if the swing power bar should increase

    // Use this for initialization
    void Start()
    {
        displaySwingGUI = false;
        inPreSwing = true;
        inSwingPower = false;
        inSwingCurve = false;
        inPostSwing = false;
        swingPowerIncrease = false;
        swingCurveIncrease = false;
    }

    // Update is called once per frame
    void Update()
    {
       
       
        if (Input.GetKey(KeyCode.Return)) // Displays GUI when ENTER is pressed
        {
            displaySwingGUI = true;
            returnReleased = false;
        }

        if (displaySwingGUI)
        {           
            if (!returnReleased) // insures spacebar is released before allowing swing
            {
                if (Input.GetKeyUp(KeyCode.Return))
                {
                    returnReleased = true;
                }
            }
            if (returnReleased == true)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    displaySwingGUI = false;
                }
            }
            if (inPreSwing)
            {
                // Add code to set desired power and curve
                if (Input.GetKey(KeyCode.Space)) 
                {
                    spaceBarReleased = false;
                    inPreSwing = false;
                    inSwingCurve = true;
                    inSwingPower = false;
                    swingCurveIncrease = true;
                    // = Convert.ToInt32(((desiredCurve / 3) + 50)));
                }

                if (Input.GetKey(KeyCode.RightArrow)) // moves desired curve right
                {
                    for (int i = 0; i < 2; i++) // Chaange i < X to change how quickly the bar moves
                    {
                        desiredCurve++;
                    }
                    if (desiredCurve >= 150)            // Right most limit of curve bar
                    {
                        desiredCurve = 150;  // Prevents curve from moving further right
                    }
                }

                if (Input.GetKey(KeyCode.LeftArrow))    // Moves desired curve left
                {
                    for (int i = 0; i < 2; i++)         // Change i < X to change how quickly and  in what incrament the bar moves
                    {
                        desiredCurve--;
                    }
                    if (desiredCurve <= -150)      // Left most limit of curve bar
                    {
                        desiredCurve = -150;  // Prevents curve from moving further left
                    }
                }

                if (Input.GetKey(KeyCode.UpArrow))      // Moves desired power up
                {
                    for (int i = 0; i < 2; i++)         // change 1 < X to change how quickly and in what incramnet the bar moves
                    {
                        desiredPower++;
                    }
                    if (desiredPower >= 300)
                    {
                        desiredPower = 300;
                    }
                }
                if (Input.GetKey(KeyCode.DownArrow))    // Moves desired power down
                {
                    for (int i = 0; i < 2; i++)         // change 1 < X to change how quickly and in what incramnet the bar moves
                    {
                        desiredPower--;
                    }
                    if (desiredPower <= 0)
                    {
                        desiredPower = 0;
                    }
                }
            } // Close PreSwing

            // inSwingCurve
            if (inSwingCurve)
            {
                if (!spaceBarReleased) // insures spacebar is released before allowing swing
                {
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        spaceBarReleased = true;
                    }
                }
                if ((Input.GetKeyDown(KeyCode.Space) && spaceBarReleased))
                {                    
                    swingCurveIncrease = false;
                    inSwingPower = true;
                    swingPowerIncrease = true;
                    inSwingCurve = false;
                    spaceBarReleased = false;

                }

                if (swingCurveIncrease)     //Increases swing curve
                {
                    IncreaseSwingCurve(0);
                    IncreaseSwingCurve(0);
                }

                if (!swingCurveIncrease)    // Decreases swing curve
                {
                    DecreaseSwingCurve(0);
                    DecreaseSwingCurve(0);
                }
            } // Close inSwingCurve

            if (inSwingPower)
            {
                if (!spaceBarReleased) // insures spacebar is released before proceeding to swing power
                {
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        spaceBarReleased = true;
                    }
                }

                if ((Input.GetKeyDown(KeyCode.Space) && spaceBarReleased))
                {
                    swingPowerIncrease = false;
                    inSwingPower = false;
                    inPostSwing = true;
                }

                if (swingPowerIncrease)     // Increases swing power
                {
                    IncreaseSwingPower(0);
                    IncreaseSwingPower(0);
                    IncreaseSwingPower(0);
                    IncreaseSwingPower(0); 
                }

                if (!swingPowerIncrease)    // Decreases swing power
                {
                    DecreaseSwingPower(0);
                    DecreaseSwingPower(0);
                    DecreaseSwingPower(0);
                    DecreaseSwingPower(0);
                }
            } // Close inSwingPower

            if (inPostSwing)
            {
               
                
                int finalPower;

                powerDifference = ((int)desiredPower/3) - (currentSwingPower/3);
                
                if (powerDifference < 0)
                {
                    powerDifference = -powerDifference;
                }
                Debug.Log("Power Difference = " + powerDifference);

                if (powerDifference > 10)
                {
                    Debug.Log("Awful Power");
                }

                if (powerDifference > 5)
                {
                    Debug.Log("Mediocre Power");

                }
                else
                {
                    Debug.Log("Perfect Power");
                }

                int curveDifference;
                int finalCurve;

                curveDifference = ((int)((desiredCurve / 3) + 50) - (currentSwingCurve / 3));

                if (curveDifference < 0)
                {
                    curveDifference = -curveDifference;
                }
                Debug.Log("Curve Difference = " + curveDifference);

                if (curveDifference > 10)
                {
                    Debug.Log("Awful Curve");
                }

                if (curveDifference > 5)
                {
                    Debug.Log("Mediocre Curve");

                }
                else
                {
                    Debug.Log("Perfect Curve");
                }
                
               
                displaySwingGUI = false;
            } // Close post Swing

            swingPowerBarLength = -300 * (currentSwingPower / (float)maxSwingPower);
           
            swingCurveBarLength = 300 * (currentSwingCurve  / (float)maxSwingCurve);

        } // Close displayGUI
    } // Close Update Method   

    void OnGUI()
    {

        int converted_DP = (int)desiredPower;
        int converted_DC = (int)desiredCurve;

        float resX = Screen.width / default_width;              // Makes menu
        float resY = Screen.height / default_height;            // change size  
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0),        // with screen
            Quaternion.identity, new Vector3(resX, resY, 1));   // resolution

        if (_theSkin != null)
        {
            GUI.skin = _theSkin;
        }

    //public int curveBarWidth = 50;
    //public int curveBarLength = 300;
    //public int curveBarVirticalPosition = 350;
    //public int curveBarHorizontalPosition = 0;

    //public int powerBarWidth = 50;
    //public int powerBarLength = 300;
    //public int powerBarVirticalPosition = 100;
    //public int powerBarHorizontalPosition = 0;

        if (displaySwingGUI)
        {
            GUI.BeginGroup(new Rect((default_width / 2) - 200, (default_height / 2) - 250, 400, 500));
            
            
            // Swing Curve Bars        
            GUI.Box(new Rect(curveBarHorizontalPosition,curveBarVirticalPosition + 12,curveBarLength, customBarWidths),                                        // Full Curve bar Length in background
                "", customeFullCurve);           

            GUI.Box(new Rect(desiredCurve + 175, curveBarVirticalPosition,50, curveBarWidth),                                         // Desired Curve
                ((converted_DC / 3) + 50).ToString(), customDesiredCurve);

            GUI.Box(new Rect(desiredCurve + 190, curveBarVirticalPosition,20, curveBarWidth),                                         // Perfect Curve
               "", customPerfectCurve);

            GUI.Box(new Rect(50, curveBarVirticalPosition + 12, swingCurveBarLength, customBarWidths),                                       // Curve bar that fluctuates after pressing space
                "" + (currentSwingCurve / 3), customCurve);

            // Swing Power Bars
            GUI.Box(new Rect(powerBarHorizontalPosition + 12, powerBarVirticalPosition,customBarWidths, powerBarLength), "", customFullPower);                    // Full Power bar length in background

            GUI.Box(new Rect(powerBarHorizontalPosition , -desiredPower +325 , powerBarWidth, 50),                                         // Desired Power marker
                (converted_DP/3).ToString(), customDesiredPower);

            GUI.Box(new Rect(powerBarHorizontalPosition, -desiredPower + 340, powerBarWidth, 20),                                           // Perfect Power marker
                "", customPerfectPower);

            GUI.Box(new Rect(powerBarHorizontalPosition + 12, 350, customBarWidths, swingPowerBarLength),                                          // Power bar that fluctuates following swing curve
                "" + (currentSwingPower / 3), customPower);

            GUI.EndGroup(); // End displayGUI Group
        } //Close displayGUI
    } // Close onGUI    

   //* Methods 
    public void IncreaseSwingCurve(int adj)
    {        
        currentSwingCurve += adj;
        currentSwingCurve++;
        if (currentSwingCurve >= maxSwingCurve)
        {
            currentSwingCurve = maxSwingCurve;
            swingCurveIncrease = false;
        }
    }

    public void DecreaseSwingCurve(int adj)
    {        
        currentSwingCurve--;       
        if (currentSwingCurve <= 0)
        {
            currentSwingCurve = 0;
            swingCurveIncrease = true;
        }
    }

    public void IncreaseSwingPower(int adj)
    {
        currentSwingPower += adj;
        currentSwingPower++;


        if (currentSwingPower >= maxSwingPower)
        {
            currentSwingPower = maxSwingPower;
            swingPowerIncrease = false;
        }
    }

    public void DecreaseSwingPower(int adj)
    {
        currentSwingPower--;

        if (currentSwingPower <= 0)
        {
            currentSwingPower = 0;
            swingPowerIncrease = true;
        }
    }
} // Close Swing GUI