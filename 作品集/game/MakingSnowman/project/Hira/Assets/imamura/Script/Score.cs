//今村.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {
	public goal goal;
	public GameObject objA,objB;
	static public int score,startTime,timer,y;
	public float x;
	public bool paused = false;
	public Text scoreText; 

	void Start () {
		score=0;
		startTime = 0;
		y = 0;
		x = 0;
		reset();
	}
	void Update(){
		if (goal.Goal) {
			if (Countdown.x == 1)
				x += Time.deltaTime;
			y = 0 + (int)x;
			timer -= y;
			if (timer <= 0) {
				timer = 0;
				paused = true;

			}
			scoreText.text = "時間: " + y.ToString ();
		}
	}
	private void reset()
	{
		timer = startTime;
	}

	

}
