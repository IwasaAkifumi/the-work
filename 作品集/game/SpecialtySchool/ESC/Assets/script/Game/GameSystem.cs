using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class GameSystem : MonoBehaviour {
	
	public GameObject mainCamera; //カメラの定義
	public EventSystem eventsystem; //イベントシステム（いろんなことに使う）の定義
	//クリックでレイ（光線）とばす
	public Ray ray;
	public Ray rayItem;
	public RaycastHit hit;
	public GameObject selectedGameObject;
	//アイテム
	public GameObject item_key;
	public GameObject item_keyA;
	public GameObject item_keyB;
	public GameObject item_key4;
	public GameObject item_NeckStrap;
	public GameObject item_NeckStrap_zoom;
	public GameObject item_RemoteController;
	public GameObject item_USB;	public GameObject item_HDMI;
	public GameObject kinco;
	public GameObject kinco2;
	public GameObject kinco3;
	public GameObject window;
	public GameObject USB_PC;
	public GameObject HDMI_PC;
	public GameObject flont;
	public GameObject flont_HDMI;
	public GameObject pc;
	public GameObject ps2;
	public GameObject ps_pc;

	public GameObject Rocker;
	public GameObject Rocker2;
	public GameObject bag;
	public GameObject bagzoom;
	public GameObject bag2;
	public GameObject Gabage_zoom;
	public GameObject Gabage_zoom2;	
	public GameObject Gabage_zoom3;	
	public GameObject Gabage_right_zoom;
	public GameObject Gabage_senter_zoom;
	public GameObject Gabage_left_zoom;

	public string standName; //現在の立ち位置
	public string myItem;
	public string zoomItem;
	public string ps;
	public string ps_HDMI;
	public string t;
	public string Key;
	public string Key2;
	public string pc_Key;
	public string pc_Key2;
	
	// アイテムボタン
	public GameObject itemBtn_key;
	public GameObject itemBtn_keyA;
	public GameObject itemBtn_keyB;
	public GameObject itemBtn_key4;
	public GameObject itemBtn_NeckStrap;
	public GameObject itemBtn_RemoteController;
	public GameObject itemBtn_USB;
	public GameObject itemBtn_HDMI;
	
	private GameObject cam1;
	private GameObject cam2;
	private GameObject cam3;
	private GameObject cam4;
	private GameObject cam5;
	private GameObject cam6;
	private GameObject camgabagecan;
	private GameObject camgabagecan2;
	private GameObject camgabagecan3;
	private GameObject camNeckStrap;
	private bool checkcam1=true;

	public GameObject leftBtn;
	public GameObject rightBtn;
	public GameObject belowBtn;

	public GameObject message;
	public GameObject message01;
	public GameObject message02;
	public GameObject message03;
	public GameObject message04;
	public GameObject message05;
	public GameObject message06;
	public GameObject message07;
	public GameObject message08;
	public GameObject message09;
	public GameObject message10;
	public GameObject message11;
	public GameObject Time1;
	public GameObject Watch;
	public string timer;
	public GameObject backImage;
	public GameObject button2;
	public GameObject button1;
	public GameObject returnbutton;
	public GameObject menu;
	public GameObject board1;
	public GameObject board2;
	public GameObject board3;


	public Texture image;
	public Texture image2;
	public Texture image3;
	public Texture image4;
	public Texture image5;
	public Texture image6;
	public Texture image7;
	public Texture image8;
	public Texture image9;
	public Texture image0;
	public GameObject trap;
	public GameObject trap2;
	public GameObject trap3;
	public GameObject trap4;
	public int password,password2,password3,password4;
	public int keyCount;
	public int keyCount2;
	public int[] numbers = { 1, 2, 3, 4};
	public string[] img = { "image", "image2", "image3", "image4", "image5", "image6", "image7", "image8", "image9", "image0"};
	public string LightButtan;
	public string board01;
	public GameObject right2;
	public AudioClip Item;
	public AudioClip switc;
	public AudioClip door;
	public AudioClip Garbage;


	void Start () {
		standName = "centerN"; //現在の立ち位置 =　北向き
		eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		item_key = GameObject.Find("key");
		item_key.SetActive(false);
		item_keyA = GameObject.Find("keyA");
		item_keyA.SetActive(false);
		item_keyB = GameObject.Find("keyB");
		item_key4 = GameObject.Find("key4");
		item_NeckStrap = GameObject.Find("NeckStrap");
		item_NeckStrap_zoom = GameObject.Find("NeckStrap_zoom");
		item_RemoteController = GameObject.Find("RemoteController");
		item_USB = GameObject.Find("USB");
		item_HDMI = GameObject.Find("HDMI");



		GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
		GameObject.Find("itemBtn_keyA_plane").GetComponent<Renderer>().enabled = false;
		GameObject.Find("itemBtn_keyB_plane").GetComponent<Renderer>().enabled = false;
		GameObject.Find("itemBtn_key4_plane").GetComponent<Renderer>().enabled = false;
		GameObject.Find("itemBtn_NeckStrap_plane").GetComponent<Renderer>().enabled = false;
		GameObject.Find("itemBtn_RemoteController_plane").GetComponent<Renderer>().enabled = false;
		GameObject.Find("itemBtn_USB_plane").GetComponent<Renderer>().enabled = false;
		GameObject.Find("itemBtn_HDMI_plane").GetComponent<Renderer>().enabled = false;


		itemBtn_key = GameObject.Find("itemBtn_key1");
		itemBtn_keyA = GameObject.Find("itemBtn_keyA");
		itemBtn_keyB = GameObject.Find("itemBtn_keyB");
		itemBtn_key4 = GameObject.Find("itemBtn_key4");
		itemBtn_NeckStrap = GameObject.Find("itemBtn_NeckStrap");
		itemBtn_RemoteController = GameObject.Find("itemBtn_RemoteController");
		itemBtn_USB = GameObject.Find("itemBtn_USB");
		itemBtn_HDMI = GameObject.Find("itemBtn_HDMI");

		itemBtn_key.SetActive(false);
		itemBtn_keyA.SetActive(false);
		itemBtn_keyB.SetActive(false);
		itemBtn_key4.SetActive(false);
		itemBtn_NeckStrap.SetActive(false);
		itemBtn_RemoteController.SetActive(false);
		itemBtn_USB.SetActive(false);
		itemBtn_HDMI.SetActive(false);
		myItem = "noitem";
		zoomItem = "nozoomitem";
		ps = "nops";
		ps_HDMI = "nops";
		Key = "off";
		Key2 = "off";
		pc_Key = "off";
		pc_Key2 = "off";

		kinco = GameObject.Find("kinco");
		kinco.SetActive(false);
		kinco2 = GameObject.Find("kinco2");
		kinco3 = GameObject.Find("kinco3");
		window = GameObject.Find("Window");
		window.SetActive(false);
		USB_PC = GameObject.Find("USB_PC");
		USB_PC.SetActive(false);
		flont = GameObject.Find("flont");
		flont_HDMI = GameObject.Find("flont_HDMI");
		flont_HDMI.SetActive(false);
		pc = GameObject.Find("PC");
		ps2 = GameObject.Find("Ps2");
		ps2.SetActive(false);
		ps_pc = GameObject.Find("Ps_PC");
		ps_pc.SetActive(false);


		Rocker = GameObject.Find("Rocker");	
		Rocker2 = GameObject.Find("Rocker2");
		bag = GameObject.Find("bag");
		bagzoom = GameObject.Find("right2");
		bag2 = GameObject.Find("bag2");	
		Gabage_zoom = GameObject.Find("Gabage_zoom");

		Gabage_right_zoom = GameObject.Find("Gabage_right_zoom");
		Gabage_right_zoom.SetActive(false);
		Gabage_zoom2 = GameObject.Find("Gabage_zoom2");
		Gabage_senter_zoom = GameObject.Find("Gabage_senter_zoom");	
		Gabage_senter_zoom.SetActive(false);
		Gabage_zoom3 = GameObject.Find("Gabage_zoom3");	
		Gabage_left_zoom = GameObject.Find("Gabage_left_zoom");	
		Gabage_left_zoom.SetActive(false);
		
		cam1=GameObject.Find("mainCamera");
		cam2=GameObject.Find("ZoomMainCamera");
		cam3=GameObject.Find("ZoomMainCamera2");
		cam4=GameObject.Find("ZoomMainCamera4");
		cam5=GameObject.Find("ZoomMainCamera5");
		cam6=GameObject.Find("ZoomMainCamera6");
		camgabagecan=GameObject.Find("ZoomMainCameraGabage_can");
		camgabagecan2=GameObject.Find("ZoomMainCameraGabage_can2");	
		camgabagecan3=GameObject.Find("ZoomMainCameraGabage_can3");	
		camNeckStrap=GameObject.Find("ZoomMainCameraNeckStrap");
		cam2.SetActive(false);
		cam3.SetActive(false);
		cam4.SetActive(false);
		cam5.SetActive(false);
		cam6.SetActive(false);	
		camgabagecan.SetActive(false);	
		camgabagecan2.SetActive(false);	
		camgabagecan3.SetActive(false);	
		camNeckStrap.SetActive(false);


		leftBtn = GameObject.Find("leftButton");
		rightBtn = GameObject.Find("rightButton");
		belowBtn = GameObject.Find("belowButton");
		belowBtn.SetActive(false);


		Time1=GameObject.Find("time1");
		Time1.SetActive(false);
		Watch=GameObject.Find("Watch");
		Watch.SetActive(true);
		message= GameObject.Find("Text1");
		message.SetActive(false);
		message01= GameObject.Find("Text01");
		message01.SetActive(false);
		message02= GameObject.Find("Text02");
		message02.SetActive(false);
		message03= GameObject.Find("Text03");
		message03.SetActive(false);
		message04= GameObject.Find("Text04");
		message04.SetActive(false);
		message05= GameObject.Find("Text05");
		message05.SetActive(false);
		message06= GameObject.Find("Text06");
		message06.SetActive(false);
		message07= GameObject.Find("Text07");
		message07.SetActive(false);
		message08= GameObject.Find("Text08");
		message08.SetActive(false);
		message09= GameObject.Find("Text09");
		message09.SetActive(false);
		message10= GameObject.Find("Text10");
		message10.SetActive(false);
		message11= GameObject.Find("Text11");
		message11.SetActive(false);

		board01="off";
		timer = "off";
		backImage = GameObject.Find ("backImage");
		backImage.SetActive (false);
		button2 = GameObject.Find ("Button2");
		button2.SetActive (false);
		button1 = GameObject.Find ("Button3");
		button1.SetActive (false);
		returnbutton = GameObject.Find ("returnbutton");
		returnbutton.SetActive (false);
		menu = GameObject.Find ("menu");
		menu.SetActive (true);
		board1 = GameObject.Find ("board1");
		board1.SetActive (true);
		board2 = GameObject.Find ("board2");
		board2.SetActive (true);
		board3 = GameObject.Find ("board3");
		board3.SetActive (true);


		trap = GameObject.Find("1");
		trap2 = GameObject.Find("2");
		trap3 = GameObject.Find("3");
		trap4 = GameObject.Find("4");
		password = 0;
		password2 = 0;
		password3 = 0;
		password4 = 0;
		keyCount = 0;
		keyCount2 = 0;
		LightButtan  = "off";
	
		right2 = GameObject.Find("right2");
	}

	
	// Update is called once per frame
	void Update () {


		TimeScript.time -= Time.deltaTime;//時間管理
		if (TimeScript.time <= 240) {
			board01="on";
		}
		//テキスト処理アンドウ
		if (Input.GetMouseButtonUp (0)) {
			message01.SetActive (false);
			message02.SetActive (false);
			text01.currentLine=0;
			text02.currentLine=0;
			message03.SetActive(false);
			message04.SetActive(false);
			message05.SetActive(false);
			message06.SetActive(false);
			message07.SetActive(false);
			message08.SetActive(false);
			message09.SetActive(false);
			message10.SetActive(false);
			message11.SetActive(false);
		}
		if(text01.currentLine>=1){
			
			text01.currentLine=0;
			message01.SetActive(false);

		}
		if(text02.currentLine>=1){
			
			text02.currentLine=0;
			message02.SetActive(false);

		}
		if(text03.currentLine>=1){
			
			text03.currentLine=0;
			message03.SetActive(false);

		}
		if(text04.currentLine>=1){
			
			text04.currentLine=0;
			message04.SetActive(false);

		}
		if(text05.currentLine>=1){
			
			text05.currentLine=0;
			message05.SetActive(false);

		}
		if(text06.currentLine>=1){
			
			text06.currentLine=0;
			message06.SetActive(false);

		}
		if(text07.currentLine>=1){
			
			text07.currentLine=0;
			message07.SetActive(false);

		}
		if(text08.currentLine>=1){
			
			text08.currentLine=0;
			message08.SetActive(false);
			
		}
		if(text09.currentLine>=1){
			
			text09.currentLine=0;
			message09.SetActive(false);
			
		}
		if(text10.currentLine>=1){
			
			text10.currentLine=0;
			message10.SetActive(false);
			
		}
		if(text11.currentLine>=1){
			
			text11.currentLine=0;
			message11.SetActive(false);
			
		}
		if(TextMessage.currentLine>=1){
			
			TextMessage.currentLine=0;
			message.SetActive(false);

		}

		if(keyCount == 1 && keyCount2 == 1){
			itemBtn_key4.SetActive(true);//アイテム欄のKeyが表示される
		}

		//画面クリック処理
		if(Input.GetMouseButtonUp(0)){ //左クリック
			if(eventsystem.currentSelectedGameObject==null){// UI以外（3D）をさわった
				searchRoom(); //3Dオブジェクトをクリックした時の処理
			}else{ // UIをさわった
				switch(eventsystem.currentSelectedGameObject.name){

				case "leftButton":
					turnL();
					break;
				case "rightButton":
					turnR();
					break;
				case "belowButton":
					turnB();
					leftBtn.SetActive(true);
					rightBtn.SetActive(true);
					belowBtn.SetActive(false);
					break;
				case"returnbutton":
						returnbutton.SetActive(false);
					button1.SetActive(false);
					button2.SetActive(false);
					backImage.SetActive(false);
					Time.timeScale=1;
					break;
				case "menu":
					returnbutton.SetActive(true);
					button1.SetActive(true);
					button2.SetActive(true);
					backImage.SetActive(true);
					Time.timeScale=0;
					break;
				}
			}
		}
	}

	public void turnL () {
		switch(standName){
		case "centerN"://北を向いているとき
			GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, -90, 0);
			standName = "centerW";
			break;
		case "centerW"://西を向いているとき
			GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 180, 0);
			standName = "centerS";
			break;
		case "centerS"://南を向いているとき
			GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 90, 0);
			standName = "centerE";
			break;
		case "centerE"://東を向いているとき
			GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 0, 0);
			standName = "centerN";
			break;
		}
	}

	public void turnR () {
		switch(standName){
		case "centerN"://北を向いているとき
			GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 90, 0);
			standName = "centerE";
			break;
		case "centerE"://東を向いているとき
			GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 180, 0);
			standName = "centerS";
			break;
		case "centerS"://南を向いているとき
			GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, -90, 0);
			standName = "centerW";
			break;
		case "centerW"://西を向いているとき
			GameObject.Find("mainCamera").transform.rotation = Quaternion.Euler(0, 0, 0);
			standName = "centerN";
			break;
		}
	}

	public void turnB () {
		if(checkcam1==false){
				cam1.SetActive(true);
			    checkcam1=true;
		}
		if(checkcam1 == true){
			cam2.SetActive(false);
			cam3.SetActive(false);
			cam4.SetActive(false);
			cam5.SetActive(false);
			cam6.SetActive(false);
			camgabagecan.SetActive(false);
			camgabagecan2.SetActive(false);
			camgabagecan3.SetActive(false);
			kinco2.SetActive(true);
			Gabage_zoom.SetActive(true);
			Gabage_zoom2.SetActive(true);
			Gabage_zoom3.SetActive(true);
			Gabage_right_zoom.SetActive(false);
			Gabage_senter_zoom.SetActive(false);
			Gabage_left_zoom.SetActive(false);
			item_keyA.SetActive(false);

			}
		}
		public void searchRoom(){
		selectedGameObject=null;
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 10000000,1 << 8)) {
			selectedGameObject = hit.collider.gameObject;
			switch(selectedGameObject.name){
				// シングルトンインスタンスを取得する
			
			case "PC"://パソコンを押したとき

				if(myItem == "USB" && checkcam1==false){
					window.SetActive(true);
					USB_PC.SetActive(true);
				}
				if(myItem == "HDMI" && checkcam1==false){
					ps_HDMI = "onps";
					pc_Key2 = "on";
					flont_HDMI.SetActive(true);
				}
				{
					if(checkcam1==true){
						leftBtn.SetActive(false);
						rightBtn.SetActive(false);
						belowBtn.SetActive(true);
						cam1.SetActive(false);
						cam3.SetActive(true);
						checkcam1=false;
						//pc.SetActive(false);
					}
				}
				break;

			case "board1":
				message04.SetActive(true);
				break;
			case "board2":
				if(board01=="off"){
				message03.SetActive(true);
				}
				if(TimeScript.time<=240 && board01=="on"){
					message05.SetActive(true);
				}
				break;
			case "board3":
				message08.SetActive(true);
				break;


			case "key"://鍵を押したとき
				message11.SetActive(true);
				audio.PlayOneShot(Item);
				item_key.SetActive(false);//Keyが消える
				itemBtn_key.SetActive(true);//アイテム欄のKeyが表示される
				Key = "on";
				break;

			case "keyA"://鍵を押したとき
				message10.SetActive(true);
				audio.PlayOneShot(Item);
				item_keyA.SetActive(false);//Keyが消える
				itemBtn_keyA.SetActive(true);//アイテム欄のKeyが表示される
				Key2 = "on";
				break;

			case "keyB"://鍵を押したとき
				audio.PlayOneShot(Item);
				item_keyB.SetActive(false);//Keyが消える
				itemBtn_keyB.SetActive(true);//アイテム欄のKeyが表示される
				break;

			case "NeckStrap"://ネックストラップを押したとき
				audio.PlayOneShot(Item);
				message02.SetActive(true);//セリフ
				right2.SetActive(false);//ネックストラップが消える
				item_NeckStrap.SetActive(false);
				itemBtn_NeckStrap.SetActive(true);//アイテム欄のネックストラップが表示される
				break;

			case "NeckStrap_zoom"://ネックストラップを押したとき

				item_NeckStrap_zoom.SetActive(false);//ネックストラップ表が消える
				break;

			case "NeckStrapBack_zoom"://ネックストラップ裏を押したとき
				item_NeckStrap_zoom.SetActive(true);//ネックストラップ表表示
				break;

			case "RemoteController"://リモコンを押したとき
				message06.SetActive(true);
				audio.PlayOneShot(Item);
				item_RemoteController.SetActive(false);//リモコンが消える
				itemBtn_RemoteController.SetActive(true);//アイテム欄のリモコンが表示される
				break;

			case "USB"://USBを押したとき
				message07.SetActive(true);
				audio.PlayOneShot(Item);
				item_USB.SetActive(false);//USBが消える
				itemBtn_USB.SetActive(true);//アイテム欄のUSBが表示される
				break;

			case "HDMI"://HDMIを押したとき
				message01.SetActive(true);
				audio.PlayOneShot(Item);
				item_HDMI.SetActive(false);//HDMIが消える
				itemBtn_HDMI.SetActive(true);//アイテム欄のHDMIが表示される
				break;

			case "Window"://Windowを押したとき
				ps_pc.SetActive(true);
				ps = "onps";
				pc_Key = "on";
				if(LightButtan=="on" && ps_HDMI == "onps"){
					ps2.SetActive(true);
				}
				break;

			case "Projector"://Projectorを押したとき

				if(myItem == "HDMI" && LightButtan=="on" && ps == "onps"){
					ps2.SetActive(true);
				}else if(myItem == "HDMI"){
					flont_HDMI.SetActive(true);
					ps_HDMI = "onps";
					pc_Key2 = "on";
				}
				break;

			case "switch"://switchを押したとき
				audio.PlayOneShot(switc);
				if(LightButtan == "on"){
					flont.SetActive(true);
					ps2.SetActive(false);
					LightButtan = "off";
				}else if(ps == "onps" && ps_HDMI == "onps"){
					ps2.SetActive(true);
					flont.SetActive(false);
					LightButtan = "on";
				}else{
					flont.SetActive(false);
					LightButtan = "on";
				}
				break;

			case "door"://ドアを押したとき
				if(myItem == "key"){
					ScreenFadeManager fadeManager = ScreenFadeManager.Instance;

					// フェードアウト
					fadeManager.FadeOut(1.5f, Color.white, () => {
					
					Application.LoadLevel("gameclear");//ゲームクリア
						// フェードアウト後に行う処理
						Debug.Log("フェードアウト完了");
					});
				}else{
					message.SetActive(true);
				}
				break;

			case "Trap"://トラップを押したとき
			{
				if(checkcam1==true)
				{
					belowBtn.SetActive(true);
					leftBtn.SetActive(false);
					rightBtn.SetActive(false);
					cam1.SetActive(false);
					cam2.SetActive(true);
					checkcam1=false;
				}
			}
				break;

			case "kinco"://金庫を押したとき
				audio.PlayOneShot(door);
			{
				if(password == 2 && password2 == 9 && password3 == 9 && password4 == 5){
					
					kinco.SetActive(false);
					trap.SetActive(true);
					trap2.SetActive(true);
					trap3.SetActive(true);
					trap4.SetActive(true);
					item_key.SetActive(false);
					kinco3.SetActive(true);
				}
			}
				break;

			case "kinco2"://金庫を押したとき
				audio.PlayOneShot(door);
			{
				if(checkcam1==true){
					leftBtn.SetActive(false);
					rightBtn.SetActive(false);
					belowBtn.SetActive(true);
					cam1.SetActive(false);
					cam4.SetActive(true);
					checkcam1=false;
					kinco2.SetActive(false);
				}
			}
				break;

			case "kinco3"://金庫を押したとき
				audio.PlayOneShot(door);
			{
					if(password == 2 && password2 == 9 && password3 == 9 && password4 == 5 && pc_Key == "on" && pc_Key2 == "on"){
					message09.SetActive(true);
					kinco.SetActive(true);
					kinco3.SetActive(false);
					trap.SetActive(false);
					trap2.SetActive(false);
					trap3.SetActive(false);
					trap4.SetActive(false);
				}
					if(Key == "off" && password2 == 9 && password3 == 9 && password4 == 5 && pc_Key == "on" && pc_Key2 == "on"){
						item_key.SetActive(true);
					}
			}
				break;

			case "Watch":
				if(timer == "off"){
					
					Time1.SetActive(true);
					timer = "on";
					if(Time1==true){
						
					}
				}else {
					Time1.SetActive(false);
					timer = "off";
				}			
				break;

			case "bag"://鞄を押したとき
			{
				if(checkcam1==true){
					bag.SetActive(false);
					cam1.SetActive(false);
					cam6.SetActive(true);
					belowBtn.SetActive(true);
					leftBtn.SetActive(false);
					rightBtn.SetActive(false);
					checkcam1=false;
				}
			}
				break;

			case "bagzoom":
			{
				if(checkcam1 == false){
				bagzoom.SetActive(false);
				}
			}
				break;
				                                                                                                                                                            
			case "Rocker":
				if(myItem == "key4"){
				Rocker.SetActive(false);
				}
				break;

			case "Garbage can"://ゴミ箱を押したとき
				if(checkcam1==true){
					cam1.SetActive(false);
					camgabagecan.SetActive(true);
					belowBtn.SetActive(true);
					leftBtn.SetActive(false);
					rightBtn.SetActive(false);
					checkcam1=false;
				}
				break;

			case "Gabage_zoom":
				audio.PlayOneShot(Garbage);
				Gabage_zoom.SetActive(false);
				Gabage_zoom2.SetActive(true);
				Gabage_zoom3.SetActive(true);
				Gabage_right_zoom.SetActive(true);
				Gabage_senter_zoom.SetActive(false);
				Gabage_left_zoom.SetActive(false);
				if(Key2 == "off"){
					item_keyA.SetActive(true);
				}

				break;

			case "Garbage can2"://ゴミ箱2を押したとき
				if(checkcam1==true){
					cam1.SetActive(false);
					camgabagecan2.SetActive(true);
					belowBtn.SetActive(true);
					leftBtn.SetActive(false);
					rightBtn.SetActive(false);
					checkcam1=false;
				}
				break;

			case "Gabage_zoom2":
				audio.PlayOneShot(Garbage);
				Gabage_zoom2.SetActive(false);
				Gabage_zoom.SetActive(true);
				Gabage_zoom3.SetActive(true);
				Gabage_senter_zoom.SetActive(true);
				Gabage_right_zoom.SetActive(false);
				Gabage_left_zoom.SetActive(false);
				item_keyA.SetActive(false);
				break;

			case "Garbage can3"://ゴミ箱3を押したとき
				if(checkcam1==true){
					cam1.SetActive(false);
					camgabagecan3.SetActive(true);
					belowBtn.SetActive(true);
					leftBtn.SetActive(false);
					rightBtn.SetActive(false);
					checkcam1=false;
				}
				break;

			case "Gabage_zoom3":
				audio.PlayOneShot(Garbage);
				Gabage_zoom3.SetActive(false);
				Gabage_zoom.SetActive(true);
				Gabage_zoom2.SetActive(true);
				Gabage_left_zoom.SetActive(true);
				Gabage_senter_zoom.SetActive(false);
				Gabage_right_zoom.SetActive(false);
				item_keyA.SetActive(false);
				break;

			case "Whiteboard"://ホワイトボードを押したとき
			{
				if(myItem == "key2" && checkcam1==false){
					kinco.SetActive(false);
				}
				if(checkcam1==true){
					leftBtn.SetActive(false);
					rightBtn.SetActive(false);
					belowBtn.SetActive(true);
					cam1.SetActive(false);
					cam5.SetActive(true);
					checkcam1=false;
				}
			}
				break;
				
			case "1":
				password = (password + 1)%10;
				if(password == 0)
					trap.renderer.material.mainTexture = image0; //0を反映する
				if(password == 1)
					trap.renderer.material.mainTexture = image; //1を反映する
				if(password == 2)
					trap.renderer.material.mainTexture = image2; //2を反映する
				if(password == 3)
					trap.renderer.material.mainTexture = image3; //3を反映する
				if(password == 4)
					trap.renderer.material.mainTexture = image4; //4を反映する
				if(password == 5)
					trap.renderer.material.mainTexture = image5; //5を反映する
				if(password == 6)
					trap.renderer.material.mainTexture = image6; //6を反映する
				if(password == 7)
					trap.renderer.material.mainTexture = image7; //7を反映する
				if(password == 8)
					trap.renderer.material.mainTexture = image8; //8を反映する
				if(password == 9)
					trap.renderer.material.mainTexture = image9; //9を反映する
				break;

			case "2":
				password2 = (password2 + 1)%10;
				numbers[1] = password2;
				if(password2 == 0)
					trap2.renderer.material.mainTexture = image0; //0を反映する
				if(password2 == 1)
					trap2.renderer.material.mainTexture = image; //1を反映する
				if(password2 == 2)
					trap2.renderer.material.mainTexture = image2; //2を反映する
				if(password2 == 3)
					trap2.renderer.material.mainTexture = image3; //3を反映する
				if(password2 == 4)
					trap2.renderer.material.mainTexture = image4; //4を反映する
				if(password2 == 5)
					trap2.renderer.material.mainTexture = image5; //5を反映する
				if(password2 == 6)
					trap2.renderer.material.mainTexture = image6; //6を反映する
				if(password2 == 7)
					trap2.renderer.material.mainTexture = image7; //7を反映する
				if(password2 == 8)
					trap2.renderer.material.mainTexture = image8; //8を反映する
				if(password2 == 9)
					trap2.renderer.material.mainTexture = image9; //9を反映する
				break;

			case "3":
				password3 = (password3 + 1)%10;
				if(password3 == 0)
					trap3.renderer.material.mainTexture = image0; //0を反映する
				if(password3 == 1)
					trap3.renderer.material.mainTexture = image; //1を反映する
				if(password3 == 2)
					trap3.renderer.material.mainTexture = image2; //2を反映する
				if(password3 == 3)
					trap3.renderer.material.mainTexture = image3; //3を反映する
				if(password3 == 4)
					trap3.renderer.material.mainTexture = image4; //4を反映する
				if(password3 == 5)
					trap3.renderer.material.mainTexture = image5; //5を反映する
				if(password3 == 6)
					trap3.renderer.material.mainTexture = image6; //6を反映する
				if(password3 == 7)
					trap3.renderer.material.mainTexture = image7; //7を反映する
				if(password3 == 8)
					trap3.renderer.material.mainTexture = image8; //8を反映する
				if(password3 == 9)
					trap3.renderer.material.mainTexture = image9; //9を反映する
				break;

			case "4":
				password4 = (password4 + 1)%10;
				if(password4 == 0)
					trap4.renderer.material.mainTexture = image0; //0を反映する
				if(password4 == 1)
					trap4.renderer.material.mainTexture = image; //1を反映する
				if(password4 == 2)
					trap4.renderer.material.mainTexture = image2; //2を反映する
				if(password4 == 3)
					trap4.renderer.material.mainTexture = image3; //3を反映する
				if(password4 == 4)
					trap4.renderer.material.mainTexture = image4; //4を反映する
				if(password4 == 5)
					trap4.renderer.material.mainTexture = image5; //5を反映する
				if(password4 == 6)
					trap4.renderer.material.mainTexture = image6; //6を反映する
				if(password4 == 7)
					trap4.renderer.material.mainTexture = image7; //7を反映する
				if(password4 == 8)
					trap4.renderer.material.mainTexture = image8; //8を反映する
				if(password4 == 9)
					trap4.renderer.material.mainTexture = image9; //9を反映する
				break;	
			}
		}
		rayItem = GameObject.Find ("ItemCamera").GetComponent<Camera> ().ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(rayItem, out hit, 10000000,1 << 9)) {
			selectedGameObject = hit.collider.gameObject;
			switch(selectedGameObject.name){
			case "itemBtn_key1":
				if(myItem == "key"){
					GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
					myItem="noitem";
				}else{
					GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = true;
					myItem="key";
					GameObject.Find("itemBtn_keyA_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_key4_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_NeckStrap_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_RemoteController_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_USB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_HDMI_plane").GetComponent<Renderer>().enabled = false;
					keyCount = 0;
					keyCount2 = 0;
				}
				break;

			case "itemBtn_keyA":
				if(myItem == "keyA"){
					GameObject.Find("itemBtn_keyA_plane").GetComponent<Renderer>().enabled = false;
					myItem="noitem";

				}else{
					GameObject.Find("itemBtn_keyA_plane").GetComponent<Renderer>().enabled = true;
					myItem="key2";
					GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_key4_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_NeckStrap_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_RemoteController_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_USB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_HDMI_plane").GetComponent<Renderer>().enabled = false;
					keyCount = 1;
				}
				break;

			case "itemBtn_keyB":
				if(myItem == "keyB"){
					GameObject.Find("itemBtn_keyB_plane").GetComponent<Renderer>().enabled = false;
					myItem="noitem";
				}else{
					GameObject.Find("itemBtn_keyB_plane").GetComponent<Renderer>().enabled = true;
					myItem="key3";
					GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyA_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_key4_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_NeckStrap_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_RemoteController_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_USB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_HDMI_plane").GetComponent<Renderer>().enabled = false;
					keyCount2 = 1;
				}
				break;

			case "itemBtn_key4":
				if(myItem == "key4"){
					GameObject.Find("itemBtn_key4_plane").GetComponent<Renderer>().enabled = false;
					myItem="noitem";
				}else{
					GameObject.Find("itemBtn_key4_plane").GetComponent<Renderer>().enabled = true;
					myItem="key4";
					GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyA_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_NeckStrap_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_RemoteController_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_USB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_HDMI_plane").GetComponent<Renderer>().enabled = false;
					keyCount = 0;
					keyCount2 = 0;
				}
				break;

			case "itemBtn_NeckStrap":
				if(myItem == "NeckStrap" && zoomItem == "NeckStrap"){
					GameObject.Find("itemBtn_NeckStrap_plane").GetComponent<Renderer>().enabled = false;
					camNeckStrap.SetActive(false);
					cam1.SetActive(true);
					leftBtn.SetActive(true);
					rightBtn.SetActive(true);
					myItem="noitem";
					zoomItem="noitem";
				}else if(myItem != "NeckStrap"){
					GameObject.Find("itemBtn_NeckStrap_plane").GetComponent<Renderer>().enabled = true;
					myItem="NeckStrap";
					GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyA_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_key4_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_RemoteController_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_USB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_HDMI_plane").GetComponent<Renderer>().enabled = false;
					keyCount = 0;
					keyCount2 = 0;
				}else{
					zoomItem="NeckStrap";
					leftBtn.SetActive(false);
					rightBtn.SetActive(false);
					camNeckStrap.SetActive(true);
					cam1.SetActive(false);
					cam2.SetActive(false);
					cam3.SetActive(false);
					cam4.SetActive(false);
					cam5.SetActive(false);
					cam6.SetActive(false);
					camgabagecan.SetActive(false);
					camgabagecan2.SetActive(false);
					camgabagecan3.SetActive(false);
					belowBtn.SetActive(false);
					checkcam1 = true;
				}
				break;

			case "itemBtn_RemoteController":
				if(myItem == "RemoteController"){
					GameObject.Find("itemBtn_RemoteController_plane").GetComponent<Renderer>().enabled = false;
					myItem="noitem";
				}else{
					GameObject.Find("itemBtn_RemoteController_plane").GetComponent<Renderer>().enabled = true;
					myItem="RemoteController";
					GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyA_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_key4_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_NeckStrap_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_USB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_HDMI_plane").GetComponent<Renderer>().enabled = false;
					keyCount = 0;
					keyCount2 = 0;
				}
				break;

			case "itemBtn_USB":
				if(myItem == "USB"){
					GameObject.Find("itemBtn_USB_plane").GetComponent<Renderer>().enabled = false;
					myItem="noitem";
				}else{
					GameObject.Find("itemBtn_USB_plane").GetComponent<Renderer>().enabled = true;
					myItem="USB";
					GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyA_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_key4_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_NeckStrap_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_RemoteController_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_HDMI_plane").GetComponent<Renderer>().enabled = false;
					keyCount = 0;
					keyCount2 = 0;
				}
				break;

			case "itemBtn_HDMI":
				if(myItem == "HDMI"){
					GameObject.Find("itemBtn_HDMI_plane").GetComponent<Renderer>().enabled = false;
					myItem="noitem";
				}else{
					GameObject.Find("itemBtn_HDMI_plane").GetComponent<Renderer>().enabled = true;
					myItem="HDMI";
					GameObject.Find("itemBtn_key1_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyA_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_keyB_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_key4_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_NeckStrap_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_RemoteController_plane").GetComponent<Renderer>().enabled = false;
					GameObject.Find("itemBtn_USB_plane").GetComponent<Renderer>().enabled = false;
					keyCount = 0;
					keyCount2 = 0;
				}
				break;
			}	
		}
	}
}
