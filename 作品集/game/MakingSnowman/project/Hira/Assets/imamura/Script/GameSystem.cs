//今村.
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class GameSystem : MonoBehaviour {
	public AudioClip audioClip;
	private AudioSource audioSource;
	public string audioClipName = "";
	public float fadeInTime,fadeOutTime;
	public static int x,y;
	BGMPlayer player;
	public GameObject mainCamera; //カメラの定義
	
	//クリックでレイ（光線）とばす
	public Ray ray,rayItem;
	public RaycastHit hit;
	public GameObject selectedGameObject;
	public EventSystem eventsystem;
	public GameObject pausebutton;
	public GameObject returnbutton;
	public GameObject titlebutton;
	public GameObject backbutton;
	public GameObject pauseImage;
	public GameObject Head,Body,Leg,Arm;

	private GUIStyle labelStyle;
	Quaternion gyro;
	bool goal = false;
	public float Speed = 0.3f;
	// Use this for initialization
	void Start () {
		fadeInTime = 0.0f;
		fadeOutTime = 0.0f;
		audioSource = gameObject.GetComponent<AudioSource>();
		x = 0;
		if ( player == null ) {
			player = new BGMPlayer( audioClipName );
			player.playBGM( fadeInTime );
		} else
			player.playBGM();
		eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		
		pauseImage = GameObject.Find ("PauseImage");
//		pauseImage.SetActive (false);
		pausebutton = GameObject.Find ("PauseButton");
//		pausebutton.SetActive (true);
		returnbutton = GameObject.Find ("ReturnButton");
//		returnbutton.SetActive (false);
		titlebutton = GameObject.Find ("TitleButton");
//		titlebutton.SetActive (false);
		backbutton = GameObject.Find ("BackButton");
//		backbutton.SetActive (false);
		Head= GameObject.Find ("Head");
//		Head.SetActive (true);
		
		Body = GameObject.Find ("Body");
//		Body.SetActive (true);
		
		Leg = GameObject.Find ("Leg");
	//	Leg.SetActive (true);
		
		Arm = GameObject.Find ("Arm");
	//	Arm.SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {

		if ( player != null )
			player.update();
		if( ChengBack.m_pos.x <= -150)
			player.stopBGM (fadeOutTime);
		if(Chara.e == 1)
			player.stopBGM (0.0f);
		Debug.Log (BGMPlayer.volume);
		if (Input.GetMouseButtonUp (0)) { //左クリック
			if (eventsystem.currentSelectedGameObject == null) {// UI以外（3D）をさわった
				searchRoom (); //3Dオブジェクトをクリックした時の処理
			} else { // UIをさわった
				switch (eventsystem.currentSelectedGameObject.name) {
				case "PauseButton":
					audioSource.clip = audioClip;
					audioSource.Play ();
					pauseImage.SetActive (true);
					Time.timeScale = 0;
					AudioPlayer.x = 1;
					player.pauseBGM();
					pausebutton.SetActive (false);
					backbutton.SetActive (true);
					titlebutton.SetActive (true);
					returnbutton.SetActive (true);
					
					break;
					
				case "BackButton":
					audioSource.clip = audioClip;
					audioSource.Play ();
					Time.timeScale = 1;
					AudioPlayer.x = 0;
					
					player.playBGM();
					pausebutton.SetActive (true);
					backbutton.SetActive (false);
					titlebutton.SetActive (false);
					pauseImage.SetActive (false);
					returnbutton.SetActive (false);
					
					break;
				case"TitleButton":
						audioSource.clip = audioClip;
					audioSource.Play ();
					Application.LoadLevel ("Title");
					AudioPlayer.x = 0;
					Time.timeScale = 1;
					
					
					Skill.skill=0;
					
					break;
				case"ReturnButton":
						audioSource.clip = audioClip;
					audioSource.Play ();
					Application.LoadLevel ("Game");
					
					Time.timeScale = 1;
					
					Skill.skill=0;
					
					break;
				}
			}
		}
	}
	
	
	
	public void searchRoom(){
		selectedGameObject = null;
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 10000000, 1 << 8)) {
			selectedGameObject = hit.collider.gameObject;
			switch (selectedGameObject.name) {
				
			}
			
		}
	}
	
	public void stop() {
		if (player != null)
			player.stopBGM (fadeOutTime);
	}
	
	
	
	
	
}