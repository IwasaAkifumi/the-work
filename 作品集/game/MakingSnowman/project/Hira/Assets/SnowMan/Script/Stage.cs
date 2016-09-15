using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void  Stage1(){
		FadeManager.Instance.LoadLevel("One",1.0f);
	}
	public void  Stage2(){
		FadeManager.Instance.LoadLevel("ma2",1.0f);
	}
	public void  Stage3(){
		FadeManager.Instance.LoadLevel("ma1",1.0f);
	}
	public void  Stage4(){
		FadeManager.Instance.LoadLevel("no1",1.0f);
	}
	public void  Stage5(){
		FadeManager.Instance.LoadLevel("no2",1.0f);
	}
}
