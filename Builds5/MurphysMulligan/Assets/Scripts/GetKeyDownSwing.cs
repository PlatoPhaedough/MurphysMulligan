using UnityEngine;
using System.Collections;

public class GetKeyDownSwing : MonoBehaviour {
	
	Animator myAnim;
	private Traj trajScript;
	private int _int_onlyHitonce = 0;
	private SelectManager SM;
	private GameObject GM;
	private GameManager GM_Script;
	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
		GM = GameObject.FindGameObjectWithTag ("gameManager");
		SM = GameObject.FindGameObjectWithTag ("SelectManager").GetComponent<SelectManager>();
		GM_Script = GM.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update(){
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			//animator.
/*<<<<<<< .mine
=======
			//GM_Script.HitText.SetActive(false);
>>>>>>> .r1012*/
			trajScript = GameObject.FindGameObjectWithTag ("golfBall").GetComponent<Traj> ();
			myAnim.SetBool ("KeyPressed", true);
			SM.blnGrabbedOriginal = false;
			StartCoroutine(Swing());

		}
	}
	
	IEnumerator Swing()
	{
		yield return new WaitForSeconds (1);
        trajScript.setTraj ();
		myAnim.SetBool ("KeyPressed", false);
		yield return 0;
	}
}