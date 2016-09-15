using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Scorekeeper))]
public class ResuitScreen : MonoBehaviour {

	public GUISkin skin;
	private Scorekeeper scorekeeper;
	private int state;

	private const int WAIT =0;
	private const int TIMEUP =1;
	private const int SHOWSCORE =2;

	// Use this for initialization
	void Start () {

		scorekeeper = (Scorekeeper)GetComponent (typeof(Scorekeeper));
	
	}

	IEnumerator TimeUP(){
		state = TIMEUP;
		yield return new WaitForSeconds(4.0f);

		state = WAIT;
		yield return new WaitForSeconds(0.5f);

		state = SHOWSCORE;
		while(!Input.GetMouseButtonDown (0))yield return null;

		Application.LoadLevel ("Title");
	}

	void OnGUI(){
		int sw    = Screen.width;
		int sh    = Screen.height;
		GUI.skin  = skin;

		if(state == TIMEUP){
			Rect rect = new Rect(0,0,sw,sh/2);
			GUI.Label(rect,"Time Up!!","Message");
		}else if (state == SHOWSCORE){
			string scoreText ="Your Score is " + scorekeeper.score.ToString();
			GUI.Label(new Rect(0,sh/4,sw,sh/4),scoreText,"Message");
			GUI.Label(new Rect(0,sh/4,sw,sh/4),"Click to Exit","Message");
		}
	}

	

}
