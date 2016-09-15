//今村.
using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

	}
	public void OnImage(){
		FadeManager.Instance.LoadLevel ("Main", 1.0f);
		//Sounds.x = 0;
	}
}
