using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class CharacterSet : MonoBehaviour {

	public GameObject mainCamera; //カメラの定義
	public EventSystem eventsystem; //イベントシステム（いろんなことに使う）の定義
	public Ray ray;
	public Ray rayItem;
	public RaycastHit hit;
	public GameObject selectedGameObject;
	UIController UIController;
	public GameObject Chara1;
	public GameObject Chara2;
	public GameObject Chara3;
	public static  int c;
	
	public bool charaisPlaying = true;

	public AudioClip buttonOn;

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteKey ("name");
		Chara1.transform.localScale = new Vector3(0, 0, 1);
		Chara1.SetActive (false);
		Chara2.transform.localScale = new Vector3(0, 0, 1);
		Chara2.SetActive (false);
		Chara3.transform.localScale = new Vector3(0, 0, 1);
		Chara3.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		Chara_c ();
	}
	public void characterSet1(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		c = 1;
		Chara1.SetActive (true);
		iTween.ScaleTo (Chara1, iTween.Hash ("x", 1, "y", 1,"time",0.3));
		charaisPlaying = false;
		Debug.Log ("pikaを押した");
	}
	public void  characterSet1_2(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		iTween.ScaleTo (Chara1, iTween.Hash ("x", 0, "y", 0,"time",0.3));
		Invoke ("BackBtn", 0.3f);
	}
	public void characterSet2(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		c = 2;
		Chara2.SetActive (true);
		iTween.ScaleTo (Chara2, iTween.Hash ("x", 1, "y", 1,"time",0.3));
		charaisPlaying = false;
		Debug.Log ("poを押した");
	}
	public void  characterSet2_2(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		iTween.ScaleTo (Chara2, iTween.Hash ("x", 0, "y", 0,"time",0.3));
		Invoke ("BackBtn", 0.3f);
	}
	public void characterSet3(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		c = 3;
		Chara3.SetActive (true);
		iTween.ScaleTo (Chara3, iTween.Hash ("x", 1, "y", 1,"time",0.3));
		charaisPlaying = false;
		Debug.Log ("numaaを押した");
	}
	public void  characterSet3_2(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		iTween.ScaleTo (Chara3, iTween.Hash ("x", 0, "y", 0,"time",0.3));
		Invoke ("BackBtn", 0.3f);
	}
	public void  Chara_c(){
		switch (c) {
		case 1:
			//Debug.Log ("pikaを押した");
			PlayerPrefs.SetInt ("name", 1);
			break;
		case 2:
			//Debug.Log ("p1を押した");
			PlayerPrefs.SetInt ("name", 2);
			break;
		case 3:
			//	Debug.Log ("numaを押した");
			PlayerPrefs.SetInt ("name", 3);
			break;
		}
	}

	public void  BackBtn(){
		Chara1.SetActive (false);
		Chara2.SetActive (false);
		Chara3.SetActive (false);
		charaisPlaying = true;
	}
}
