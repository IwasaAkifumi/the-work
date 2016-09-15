using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class tyu : MonoBehaviour {
	public GameObject tyuu;
	public AudioClip buttonOn;
	// Use this for initialization
	void Start () {
		tyuu.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void  Tuu(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		tyuu.SetActive (false);
		//iTween.MoveTo  (tyuu, iTween.Hash ("x", -250, "time",0.3,"Delay",0.1,"isLocal",true));
	}
}
