using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class GameOver : MonoBehaviour {
	public GameObject selectedGameObject;
	public EventSystem eventsystem; //イベントシステム（いろんなことに使う）の定義
	
	// Use this for initialization
	void Start () {
		eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		
	}
	
	void Update () {
		//画面クリック処理
		if(Input.GetMouseButtonUp(0)){ //左クリック
			if(eventsystem.currentSelectedGameObject==null){// UI以外（3D）をさわった
			}else{ // UIをさわった
				switch(eventsystem.currentSelectedGameObject.name){
				case "GameOver":
					Application.LoadLevel ("title");
					break;
				}
			}
		}
	}
}