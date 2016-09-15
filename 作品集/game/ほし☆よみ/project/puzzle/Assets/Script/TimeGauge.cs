using UnityEngine;
using System.Collections;

public class TimeGauge : MonoBehaviour {
	float time = 5f;
	bool One = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		iTween.ScaleTo (this.gameObject,iTween.Hash("x",0f,"time",time));
	}
	/*void timerStart(){
		float time = 5f;
		iTween.ScaleTo (this.gameObject,iTween.Hash("x",0f,"time",time));
		//iTween.ScaleUpdate (this.gameObject, iTween.Hash ("x", 0f, "time", time));
	}*/
}
