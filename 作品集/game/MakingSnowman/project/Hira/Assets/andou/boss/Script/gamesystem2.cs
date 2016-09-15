//安藤.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class gamesystem2 : MonoBehaviour {
	public AudioClip kt;
	public AudioClip sute;
	public AudioClip kaminari;
	public AudioClip zan;
	public AudioClip kaminari1;
	public AudioClip baku;
	public AudioClip koin;
	public int count=0;
	public string flag;
	public GameObject mainCamera;
	public GameObject board;
	public ScaleChange _change;
	public static string flag01;
	public string flag02;
	public string flag03;
	public string flag04;
	public string flag05;
	public static string hikariflag;
	public static string falseflag;
	public static string idouflag;
	public static string cutinflag;
	public static string cutinflag01;
	public static string cutinflag02;
	public static string cutinflag03;
	public static string cutinflag04;
	public GameObject Red_Plate;
	public GameObject by;
	public GameObject by1;
	public GameObject by2;
	public GameObject by3;
	public GameObject ketu;
	public GameObject koakuma;
	public GameObject Iyashi;
	public GameObject Cool;
	public GameObject back1;
	public GameObject clear02;
	public GameObject Ycutin;
	public GameObject Acutin;
	public GameObject Ncutin;
	public GameObject McutinWaza;
	public GameObject NcutinBack;
	public GameObject NcutinWaza;
	public GameObject YcutinBack;
	public GameObject YcutinWaza;
	public GameObject AcutinBack;
	public GameObject AcutinWaza;
	public GameObject 雷撃エフェクト_0;
	public GameObject 雷撃エフェクト_1;
	public GameObject flash;
 	public GameObject 斬撃エフェクト_0;
    public GameObject 斬撃エフェクト_1;
    public GameObject 斬撃エフェクト_2;
    public GameObject 斬撃エフェクト_3;
    public GameObject ステータスアップエフェクト_0;
	public GameObject ステータスアップエフェクト_1;
	public GameObject ステータスアップエフェクト_2;
	public GameObject ステータスアップエフェクト_3;
	public GameObject ボスカットイン;
	public GameObject 高得点装備エフェクト_0;
	public GameObject fire_0;
    public GameObject fire_1;
	public GameObject s01;
	public GameObject Text01;
	public GameObject Text02;
	public GameObject clear;
	public GameObject clear1;
	public GameObject over;
	public GameObject Glass;
	public GameObject upbluee;
	public GameObject upyellow;
	public GameObject upred;
	public GameObject upgreen;
	public GameObject Image01;
	public GameObject Image1;
	public GameObject Image2;
	public GameObject Image3;
	public GameObject Attack;
	public PingPongMove _pingPong;
	public GameObject start;
	public GameObject Boss;
	public GameObject cutin;
	public GameObject Player1;
	public GameObject Player01;
	public GameObject Player02;
	public GameObject Player03;
	public GameObject Boss_HP;
	public GameObject HP01;
	public GameObject boss_cutin;
	public GameObject Power;
	public GameObject Power1;
	public GameObject warning;
	public GameObject run;
    public GameObject BGM;
    public GameObject カットインSE;
	public GameObject カットインSE1;
    public GameObject 雷撃SE;
    public float time01=0.0f;
	public float time02=0.0f;
	public float time03=0.0f;
	public float time04=0.0f;
	public float time05=0.0f;
	public float time06=0.0f;
	public float time07=0.0f;
	//クリックでレイ（光線）とばす
	public Ray ray;
	public Ray rayItem;
	public RaycastHit hit;
	public GameObject selectedGameObject;
	public EventSystem eventsystem;
	// Use this for initialization
	void Start () {
		hikariflag="off";
		Iyashi= GameObject.Find("Iyashi");
		Iyashi.SetActive(false);
		Cool= GameObject.Find("Cool");
		Cool.SetActive(false);
		koakuma= GameObject.Find("koakuma");
		koakuma.SetActive(false);
		ketu= GameObject.Find("ketu");
		ketu.SetActive(false);
		board=GameObject.Find("board");
		board.SetActive (false);
		by=GameObject.Find("by");
		by1=GameObject.Find("by1");
		by2=GameObject.Find("by2");
		by3=GameObject.Find("by3");
		back1=GameObject.Find("back1");
		back1.SetActive (false);
		clear02 = GameObject.Find ("clear02");
		clear02.SetActive (false);
		_change=this.gameObject.GetComponent<ScaleChange>();
		Ycutin = GameObject.Find ("Ycutin");
		Ncutin = GameObject.Find ("Ncutin");
		Acutin = GameObject.Find ("Acutin");
		YcutinBack = GameObject.Find ("YcutinBack");
		YcutinBack.SetActive (false);
		NcutinBack = GameObject.Find ("NcutinBack");
		NcutinBack.SetActive (false);
		AcutinBack = GameObject.Find ("AcutinBack");
		AcutinBack.SetActive (false);
		YcutinWaza = GameObject.Find ("YcutinWaza");
		AcutinWaza = GameObject.Find ("AcutinWaza");
		NcutinWaza = GameObject.Find ("NcutinWaza");
		McutinWaza = GameObject.Find ("McutinWaza");
		flash = GameObject.Find ("flash");
		flash.SetActive (false);
		高得点装備エフェクト_0=GameObject.Find("高得点装備エフェクト_0");
		高得点装備エフェクト_0.SetActive (false);
		斬撃エフェクト_0= GameObject.Find ("斬撃エフェクト_0");
		斬撃エフェクト_0.SetActive (false);
        斬撃エフェクト_1 = GameObject.Find("斬撃エフェクト_1");
        斬撃エフェクト_1.SetActive(false);
        斬撃エフェクト_2 = GameObject.Find("斬撃エフェクト_2");
        斬撃エフェクト_2.SetActive(false);
        斬撃エフェクト_3 = GameObject.Find("斬撃エフェクト_3");
        斬撃エフェクト_3.SetActive(false);
        雷撃エフェクト_0 = GameObject.Find ("雷撃エフェクト_0");
		雷撃エフェクト_0.SetActive (false);
		雷撃エフェクト_1 = GameObject.Find ("雷撃エフェクト_1");
		雷撃エフェクト_1.SetActive (false);
		ステータスアップエフェクト_0 = GameObject.Find ("ステータスアップエフェクト_0");
		ステータスアップエフェクト_0.SetActive (false);
		ステータスアップエフェクト_1 = GameObject.Find ("ステータスアップエフェクト_1");
		ステータスアップエフェクト_1.SetActive (false);
		ステータスアップエフェクト_2 = GameObject.Find ("ステータスアップエフェクト_2");
		ステータスアップエフェクト_2.SetActive (false);
		ステータスアップエフェクト_3 = GameObject.Find ("ステータスアップエフェクト_3");
		ステータスアップエフェクト_3.SetActive (false);
		ボスカットイン = GameObject.Find ("ボスカットイン");
        BGM = GameObject.Find("BGM");
        BGM.SetActive(false);
        カットインSE = GameObject.Find("カットインSE");
        カットインSE.SetActive(false);
		カットインSE1 = GameObject.Find("カットインSE1");
		カットインSE1.SetActive(false);
        雷撃SE = GameObject.Find("雷撃SE");
        雷撃SE.SetActive(false);
        cutinflag01 = "off";
		falseflag="off";
		cutinflag02="off";
		cutinflag03="off";
		cutinflag04="off";
		cutinflag="off";
		idouflag="off";
		flag="off";
		flag01="off";
		flag02="off";
		flag03="off";
		flag05="off";

		time01 = 0.0f;
		time02 = 0.0f;
		time03 = 0.0f;
		time04 = 0.0f;
		time05 = 0.0f;
		time06 = 0.0f;
		run=GameObject.Find("run");
		s01=GameObject.Find("s01");
		s01.SetActive (false);
		fire_0=GameObject.Find("fire_0");
		fire_0.SetActive (false);
        fire_1 = GameObject.Find("fire_1");
        fire_1.SetActive(false);
        Red_Plate = GameObject.Find ("Red_Plate");
		Red_Plate.SetActive (true);
		clear= GameObject.Find ("clear");
		clear.SetActive (false);
		Text01= GameObject.Find ("Text01");
		Text01.SetActive (false);
		Text02= GameObject.Find ("Text02");
		Text02.SetActive (false);
		clear1= GameObject.Find ("clear1");
		clear1.SetActive (false);
		over = GameObject.Find ("over");
		over.SetActive (false);
		upbluee= GameObject.Find ("upbluee");
		upbluee.SetActive (false);
		upyellow= GameObject.Find ("upyellow");
		upyellow.SetActive (false);
		upgreen = GameObject.Find ("upgreen");
		upgreen.SetActive (false);
		upred= GameObject.Find ("upred");
		upred.SetActive (false);

		cutin = GameObject.Find ("cutin");

		Image01 = GameObject.Find ("Image01");
		Image01.SetActive (false);
		Image1 = GameObject.Find ("Image1");
		Image1.SetActive (false);
		Image2 = GameObject.Find ("Image2");
		Image2.SetActive (false);
		Image3 = GameObject.Find ("Image3");
		Image3.SetActive (false);
		Attack = GameObject.Find ("Attack");
		Attack.SetActive (false);
		_pingPong = GameObject.Find("Power").GetComponent<PingPongMove>();
		Power = GameObject.Find ("Power");
		Power.SetActive (false);
		Power1 = GameObject.Find ("Power1");
		Power1.SetActive (false);
		start = GameObject.Find ("start");
		start.SetActive (true);
	
		Player01 = GameObject.Find ("Player01");
		Player01.SetActive (true);
		Player02 = GameObject.Find ("Player02");
		Player02.SetActive (true);
		Player03 = GameObject.Find ("Player03");
		Player03.SetActive (true);
		warning = GameObject.Find ("warning");
		warning.SetActive (true);
		Boss = GameObject.Find ("Boss");
		Boss.SetActive (false);
		HP01 = GameObject.Find ("HP01");
		HP01.SetActive (false);
		boss_cutin = GameObject.Find ("boss_cutin");
		boss_cutin.SetActive (false);
		Boss_HP = GameObject.Find ("Boss_HP");
		Boss_HP.SetActive (false);
		eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

	}
	
	// Update is called once per frame
	void Update () {
		if (hikariflag == "on") {

			高得点装備エフェクト_0.SetActive (false);
		}
		if (_pingPong.stop >= 0.05f) {
			高得点装備エフェクト_0.GetComponent<AudioSource>().PlayOneShot(koin);
			高得点装備エフェクト_0.SetActive (true);
		}
		if (_pingPong.stop >= 0.3f) {
			高得点装備エフェクト_0.SetActive (false);
		}
		time07 += Time.deltaTime;
		if (time07 >= 2.0f) {
			BGM.SetActive (true);
			start.SetActive (false);
			warning.SetActive (false);
			Image01.SetActive (true);
			flag = "on";
			Red_Plate.SetActive (false);
		}
		if (HP.skill == 0 && flag04 == "on") {
			BGM.SetActive (false);
			time05 += Time.deltaTime;
			if (time05 >= 1.0f) {
				//  Sound.StopBGM();
				over.SetActive (true);

			}
		}
		if (Image01 == true && flag == "on") {
			time01 += Time.deltaTime;

			if (time01 >= 1.5f) {

				雷撃エフェクト_0.SetActive (true);
				雷撃SE.SetActive (true);
				GetComponent<AudioSource>().PlayOneShot(kaminari);

			}

			if (time01 >= 2.6f) {

				雷撃エフェクト_0.SetActive (false);
			}

			if (time01 >= 2.7f) {

				flash.SetActive (true);
			}
			if (time01 >= 3.0f) {

				flash.SetActive (false);
				Boss.SetActive (true);
				Image01.SetActive (false);
			}
			if (time01 >= 4.3f) {
			this.GetComponent<AudioSource>().Stop();
			}
			if (time01 >= 5.0f) {
				雷撃SE.SetActive (false);
				Image1.SetActive (true);
				cutinflag = "on";
				カットインSE1.GetComponent<AudioSource>().PlayOneShot(kt);
				カットインSE1.SetActive (true);
			}
			if (time01 >= 6.0f) {
				カットインSE1.GetComponent<AudioSource>().Stop();
			}
			if (time01 >= 7.0f) {

				Image1.SetActive (false);
				カットインSE1.SetActive (false);
				ボスカットイン.SetActive (false);
				flag01 = "on";
			}


		}
		if (BossHP.skill >= 0 && flag03 == "on") {

			time03 += Time.deltaTime;
			if (time03 >= 1.0f) {
				斬撃エフェクト_1.SetActive (true);
				斬撃エフェクト_1.GetComponent<AudioSource>().PlayOneShot(zan);
			}
			if (time03 >= 1.8f) {
				斬撃エフェクト_1.SetActive (false);
				斬撃エフェクト_1.GetComponent<AudioSource>().Stop();
				BossHP.skill = 5;
			}

			if (time03 >= 3.8f) { 
				boss_cutin.SetActive (true);
				Image1.SetActive (true);
			}
			if (time03 >= 7.0f) {
				boss_cutin.SetActive (false);
				Image1.SetActive (false);
				雷撃エフェクト_1.SetActive (true);
				雷撃エフェクト_1.GetComponent<AudioSource>().PlayOneShot(kaminari1);
                    
				if (time03 >= 10.0f) {
					HP.skill = 0;
					flag04 = "on";
					雷撃エフェクト_1.SetActive (false);
					雷撃エフェクト_1.GetComponent<AudioSource>().Stop();
					fire_1.SetActive (true);
					fire_1.GetComponent<AudioSource>().PlayOneShot(baku);
					fire_1.GetComponent<AudioSource>().Stop();
				}
/*                if (time03 >= 8.5f)
                {
                    fire_1.SetActive(false);
                		
				}*/
			}
		}
		if (cutin == true && flag05 == "on") {
			time04 += Time.deltaTime;
			if (time04 >= 0.1f) {
				Image2.GetComponent<AudioSource>().PlayOneShot(kt);

			}
			Image2.GetComponent<AudioSource>().PlayOneShot(kt);
			if (time04 >= 0.6f) {
				Image2.GetComponent<AudioSource>().Stop();
			}
			if (time04 >= 0.85f) {
				AcutinBack.GetComponent<AudioSource>().PlayOneShot(kt);
				cutinflag02 = "on";
				AcutinBack.SetActive (true);	
			}
			if (time04 >= 1.1f) {
				カットインSE.SetActive (false);
				McutinWaza.SetActive (false);
		
				cutin.SetActive (false);
				Image2.SetActive (false);

				if (time04 >= 1.3f) {
					AcutinBack.GetComponent<AudioSource>().Stop();
				}
				if (time04 >= 1.8f) {
					NcutinBack.GetComponent<AudioSource>().PlayOneShot(kt);
					cutinflag03 = "on";
					NcutinBack.SetActive (true);
				}
				if (time04 >= 2.05f) {
					NcutinBack.GetComponent<AudioSource>().Stop();
				}
				if (time04 >= 2.1f) {

					AcutinBack.SetActive (false);
					AcutinWaza.SetActive (false);
					Acutin.SetActive (false);
				}
				if (time04 >= 2.25f) {
					NcutinBack.GetComponent<AudioSource>().Stop();
				}
				if (time04 >= 2.8f) {
					YcutinBack.GetComponent<AudioSource>().PlayOneShot(kt);
					cutinflag04 = "on";
					YcutinBack.SetActive (true);
				}
				if (time04 >= 3.1f) {

					Ncutin.SetActive (false);
					NcutinBack.SetActive (false);
					NcutinWaza.SetActive (false);
				}
				if (time04 >= 3.15f) {
					YcutinBack.GetComponent<AudioSource>().Stop();
				}
				if (time04 >= 4.1f) {

					Ycutin.SetActive (false);
					YcutinBack.SetActive (false);
					YcutinWaza.SetActive (false);
				}
				if (time04 >= 5.1f) {
					斬撃エフェクト_0.SetActive (true);
					斬撃エフェクト_0.GetComponent<AudioSource>().PlayOneShot(zan);
				}
					
					       if (time04 >= 5.4f)
					  {
					       
					      }
					//        if (time04 >= 5.5f)
					//       {
					//         斬撃エフェクト_2.SetActive(true);
					//        }
					//        if (time04 >= 5.6f)
					//       {
					//           斬撃エフェクト_3.SetActive(true);
				
				if (time04 >= 6.1f) {
					BossHP.skill = 0;
					斬撃エフェクト_0.GetComponent<AudioSource>().Stop();
					斬撃エフェクト_0.SetActive (false);
					if (time04 >= 7.1f) {
						fire_0.SetActive (true);
						fire_0.GetComponent<AudioSource>().PlayOneShot(baku);

						if (time04 >= 8.1f) {
							fire_0.GetComponent<AudioSource>().Stop();
							fire_0.SetActive (false);
							Boss.SetActive (false);
						}
						if (time04 >= 9.1f) {
							BGM.SetActive (false);
							falseflag = "on";
							clear1.SetActive (true);
						}
						if (time04 >= 10.1f) {
							back1.SetActive (true);
						}
						if (time04 >= 12.1f) {
							clear02.SetActive (true);

						}
						if (time04 >= 16.1f) {
							by.SetActive (false);
							by1.SetActive (false);
							by2.SetActive (false);
							by3.SetActive (false);
							clear.SetActive (true);
							clear1.SetActive (false);
							clear02.SetActive (false);
							back1.SetActive (false);
						}
					}
				}
			}
		


		}
		if (Boss == true && flag01 == "on") {
			time02 += Time.deltaTime;
			if (time02 >= 2.0f) {
				idouflag = "on";
			}
			if (time02 >= 4.0f) {
				s01.SetActive (true);
			}
			if (time02 >= 5.5f) {
				s01.SetActive (false);
			}
			if (time02 >= 5.6f) {
				board.SetActive (true);
				HP01.SetActive (true);
				Boss_HP.SetActive (true);
			}
			if (time02 >= 6.4f) {
				ステータスアップエフェクト_3.GetComponent<AudioSource>().PlayOneShot(sute);
				ステータスアップエフェクト_3.SetActive (true);
				upgreen.SetActive (true);
			
				Cool.SetActive (true);
			}

			if (time02 >= 7.3f) {
				Cool.SetActive (false);
				ステータスアップエフェクト_3.SetActive (false);
				ステータスアップエフェクト_3.GetComponent<AudioSource>().Stop();
				ステータスアップエフェクト_2.GetComponent<AudioSource>().PlayOneShot(sute);
				ステータスアップエフェクト_2.SetActive (true);
				upgreen.SetActive (false);
				ketu.SetActive (true);
				upred.SetActive (true);
			}

			if (time02 >= 8.2f) {
				ketu.SetActive (false);
				ステータスアップエフェクト_0.GetComponent<AudioSource>().PlayOneShot(sute);
				ステータスアップエフェクト_2.GetComponent<AudioSource>().Stop();
				ステータスアップエフェクト_2.SetActive (false);
				ステータスアップエフェクト_0.SetActive (true);
				upred.SetActive (false);
				Iyashi.SetActive (true);
				upyellow.SetActive (true);
			}

			if (time02 >= 9.1f) {
				Iyashi.SetActive (false);
				ステータスアップエフェクト_1.GetComponent<AudioSource>().PlayOneShot(sute);
				ステータスアップエフェクト_0.GetComponent<AudioSource>().Stop();
				ステータスアップエフェクト_0.SetActive (false);
				ステータスアップエフェクト_1.SetActive (true);
				upyellow.SetActive (false);
				koakuma.SetActive (true);
				upbluee.SetActive (true);
			}

			if (time02 >= 10.0f) {
				ステータスアップエフェクト_1.GetComponent<AudioSource>().Stop();
				ステータスアップエフェクト_1.SetActive (false);
				upbluee.SetActive (false);
				koakuma.SetActive (false);
				Attack.SetActive (true);
				Power.SetActive (true);
				Power1.SetActive (true);
			}	

			
		}

		if (Input.GetMouseButtonUp (0)) { //左クリック
			if (eventsystem.currentSelectedGameObject == null) {// UI以外（3D）をさわった
				searchRoom (); //3Dオブジェクトをクリックした時の処理
			} else { // UIをさわった
				switch (eventsystem.currentSelectedGameObject.name) {
				case"Attack":
			
					ScaleChange.resultValue = _pingPong.value;
				
					ScaleChange.isTapped = true;
					if (ScaleChange.resultValue <= 49.999999999f) {
						flag03 = "on";             
						//雷撃エフェクト_1.SetActive(true);
					}

					if (ScaleChange.resultValue >= 50.0f) {
						cutinflag01 = "on";
						Image2.SetActive (true);
						カットインSE.SetActive (true);
						flag03 = "off";
						flag05 = "on";
						BossHP.skill = 10;
						Attack.SetActive (false);
					}
					break;

				

				case "over":
					BossHP.skill = 100;
					HP.skill = 100;
					ScaleChange.isTapped = false;
					ScaleChange.resultValue = 0; 
					_pingPong.value = 0;
					Application.LoadLevel ("Main");

					break;
				case "clear":
					BossHP.skill = 100;
					ScaleChange.isTapped = false;
					ScaleChange.resultValue = 0;
					_pingPong.value = 0;

					Application.LoadLevel ("Main");
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
			case"Attack":
					
					ScaleChange.resultValue = _pingPong.value;
				
				ScaleChange.isTapped = true;
				if (ScaleChange.resultValue <= 49.999999999f) {
					flag03 = "on";
					hikariflag="on";
					_pingPong.stop=-0.1f;
					高得点装備エフェクト_0.SetActive(false);
					//雷撃エフェクト_1.SetActive(true);
				}
				
				if (ScaleChange.resultValue >= 50.0f) {
					cutinflag01 = "on";
					Image2.SetActive (true);
					カットインSE.SetActive (true);
					flag03 = "off";
					flag05 = "on";
					BossHP.skill = 10;
					Attack.SetActive (false);
					hikariflag="on";
					_pingPong.stop=-0.1f;

					高得点装備エフェクト_0.SetActive(false);
				}
				break;



			case "高得点装備エフェクト_0":

				cutinflag01 = "on";
				Image2.SetActive (true);
				カットインSE.SetActive (true);
				flag03 = "off";
				flag05 = "on";
				BossHP.skill = 10;
				Attack.SetActive (false);
				ScaleChange.isTapped=true;
				hikariflag="on";
				_pingPong.stop=-0.1f;
				高得点装備エフェクト_0.SetActive(false);
				break;
				
			}
			
		}
	}


}
