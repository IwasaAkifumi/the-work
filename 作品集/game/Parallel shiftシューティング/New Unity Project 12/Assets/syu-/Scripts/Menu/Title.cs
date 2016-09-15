using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;

public class Title : MonoBehaviour {
	private Ui		c93_Ui;
	//public GameObject selectedGameObject;
	public EventSystem eventsystem; //イベントシステム（いろんなことに使う）の定義
	public GameObject[]	sen_obj;		// 格納する配列
	public GameObject[]	sen_obj2;		// 格納する配列
	public GameObject[]	sen_obj3;		// 格納する配列
	public GameObject[]	sen_obj4;		// 格納する配列
	public GameObject[]	sen_obj5;		// 格納する配列
	public GameObject[]	sen_obj6;		// 格納する配列
	public GameObject[]	sen_obj7;		// 格納する配列
	public GameObject[]	sen_obj8;		// 格納する配列
	public GameObject[]	sin_obj;		// 格納する配列
	public GameObject[]	dou_obj;		// 格納する配列
	public GameObject[]	rule_obj;		// 格納する配列
	public GameObject[]	rule1_obj;		// 格納する配列
	public GameObject[]	rule2_obj;		// 格納する配列
	public GameObject[]	rule3_obj;		// 格納する配列

	private AudioSource audioSource;
	public AudioClip sound;


	private Image Menu;

	// Use this for initialization
	void Start () {
		eventsystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
		//Menu = GameObject.Find ("GameRoot").GetComponent<Title> ();
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.loop = false;
	}

void Update () {
	//画面クリック処理
	if(Input.GetMouseButtonUp(0)){ //左クリック
		if(eventsystem.currentSelectedGameObject==null){// UI以外（3D）をさわった
		}else{ // UIをさわった
			//	audioSource.PlayOneShot (sound);
			switch(eventsystem.currentSelectedGameObject.name){
			case "Start":
					FadeManager.Instance.LoadLevel("Menu",1.0f);
				break;
				case "Button1":
					enabled_SingleObject();		// 選択に関わるオブジェクトを表示させる
					enabled_DoubleObject_out();
					enabled_RuleObject_out();

					enabled_RuleObject2_out();
					enabled_RuleObject3_out();
					break;
				case "Button2":

					enabled_SingleObject_out();
					enabled_RuleObject_out();
					enabled_DoubleObject();		// 選択に関わるオブジェクトを表示させる

					enabled_RuleObject2_out();
					enabled_RuleObject3_out();
					break;
				case "Button4":
					enabled_RuleObject();
					
					enabled_SingleObject_out();
					enabled_DoubleObject_out();
					break;
				case "taisen":
					FadeManager.Instance.LoadLevel("aa",1.0f);
					break;
				case "Stage1":
					//Menu.sprite = "1";
					enabled_SenObject();		// 選択に関わるオブジェクトを表示させる

					enabled_SenObject2_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject3_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject4_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject5_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject6_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject7_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject8_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "Stage2":
					enabled_SenObject2();		// 選択に関わるオブジェクトを表示させる

					enabled_SenObject_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject3_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject4_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject5_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject6_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject7_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject8_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "Stage3":
					enabled_SenObject3();		// 選択に関わるオブジェクトを表示させる

					enabled_SenObject_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject2_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject4_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject5_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject6_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject7_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject8_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "Stage4":
					enabled_SenObject4();		// 選択に関わるオブジェクトを表示させる

					enabled_SenObject_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject2_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject3_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject5_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject6_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject7_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject8_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "Stage5":
					enabled_SenObject5();		// 選択に関わるオブジェクトを表示させる

					enabled_SenObject_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject2_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject3_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject4_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject6_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject7_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject8_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "Stage6":
					enabled_SenObject6();		// 選択に関わるオブジェクトを表示させる

					enabled_SenObject_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject2_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject3_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject4_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject5_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject7_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject8_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "Stage7":
					enabled_SenObject7();		// 選択に関わるオブジェクトを表示させる
					enabled_SenObject_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject2_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject3_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject4_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject5_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject6_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject8_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "Stage8":
					enabled_SenObject8();		// 選択に関わるオブジェクトを表示させる

					enabled_SenObject_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject2_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject3_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject4_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject5_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject6_out();		// 選択に関わるオブジェクトを非表示させる
					enabled_SenObject7_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "yes1":
					FadeManager.Instance.LoadLevel("Stage1",1.0f);
					break;
				case "yes2":
					FadeManager.Instance.LoadLevel("Stage2",1.0f);
					break;
				case "yes3":
					FadeManager.Instance.LoadLevel("Stage3",1.0f);
					break;
				case "yes4":
					FadeManager.Instance.LoadLevel("Stage4",1.0f);
					break;
				case "yes5":
					FadeManager.Instance.LoadLevel("Stage5",1.0f);
					break;
				case "yes6":
					FadeManager.Instance.LoadLevel("Stage6",1.0f);
					break;
				case "yes7":
					FadeManager.Instance.LoadLevel("Stage7",1.0f);
					break;
				case "yes8":
					FadeManager.Instance.LoadLevel("Stage8",1.0f);
					break;
				case "no1":
					enabled_SenObject_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "no2":
					enabled_SenObject2_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "no3":
					enabled_SenObject3_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "no4":
					enabled_SenObject4_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "no5":
					enabled_SenObject5_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "no6":
					enabled_SenObject6_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "no7":
					enabled_SenObject7_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "no8":
					enabled_SenObject8_out();		// 選択に関わるオブジェクトを非表示させる
					break;
				case "Rule1_Button":
					enabled_RuleObject1();
					enabled_RuleObject2_out();
					enabled_RuleObject3_out();
					break;
				case "Rule2_Button":
					enabled_RuleObject2();
					enabled_RuleObject1_out();
					enabled_RuleObject3_out();
					break;
				case "Rule3_Button":
					enabled_RuleObject3();
					enabled_RuleObject1_out();
					enabled_RuleObject2_out();
					break;
				}
			}
		}

	}
	//1
	private void enabled_SenObject(){
		foreach(GameObject s in sen_obj){
			s.SetActive(true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_SenObject_out(){
		foreach(GameObject s in sen_obj){
			s.SetActive(false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//2
	private void enabled_SenObject2(){
		foreach(GameObject s in sen_obj2){
			s.SetActive(true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_SenObject2_out(){
		foreach(GameObject s in sen_obj2){
			s.SetActive(false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//3
	private void enabled_SenObject3(){
		foreach(GameObject s in sen_obj3){
			s.SetActive(true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_SenObject3_out(){
		foreach(GameObject s in sen_obj3){
			s.SetActive(false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//4
	private void enabled_SenObject4(){
		foreach(GameObject s in sen_obj4){
			s.SetActive(true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_SenObject4_out(){
		foreach(GameObject s in sen_obj4){
			s.SetActive(false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//5
	private void enabled_SenObject5(){
		foreach(GameObject s in sen_obj5){
			s.SetActive(true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_SenObject5_out(){
		foreach(GameObject s in sen_obj5){
			s.SetActive(false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//6
	private void enabled_SenObject6(){
		foreach(GameObject s in sen_obj6){
			s.SetActive(true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_SenObject6_out(){
		foreach(GameObject s in sen_obj6){
			s.SetActive(false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//7
	private void enabled_SenObject7(){
		foreach(GameObject s in sen_obj7){
			s.SetActive(true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_SenObject7_out(){
		foreach(GameObject s in sen_obj7){
			s.SetActive(false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//8
	private void enabled_SenObject8(){
		foreach(GameObject s in sen_obj8){
			s.SetActive(true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_SenObject8_out(){
		foreach(GameObject s in sen_obj8){
			s.SetActive(false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//シングルボタン
	private void enabled_SingleObject(){
		foreach (GameObject s in sin_obj) {
			s.SetActive (true);	// ゲームオブジェクトをアクティブ化
		}
	}
	//シングルボタン
	private void enabled_SingleObject_out(){
		foreach (GameObject s in sin_obj) {
			s.SetActive (false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//ダブルボタン
	private void enabled_DoubleObject(){
		foreach (GameObject s in dou_obj) {
			s.SetActive (true);	// ゲームオブジェクトをアクティブ化
		}
	}
	//ダブルボタン
	private void enabled_DoubleObject_out(){
		foreach (GameObject s in dou_obj) {
			s.SetActive (false);	// ゲームオブジェクトをアクティブ化
		}
	}



	//ルール
	private void enabled_RuleObject(){
		foreach (GameObject s in rule_obj) {
			s.SetActive (true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_RuleObject_out(){
		foreach (GameObject s in rule_obj) {
			s.SetActive (false);	// ゲームオブジェクトをアクティブ化
		}
	}



	private void enabled_RuleObject1(){
		foreach (GameObject s in rule1_obj) {
			s.SetActive (true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_RuleObject1_out(){
		foreach (GameObject s in rule1_obj) {
			s.SetActive (false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//ルール
	private void enabled_RuleObject2(){
		foreach (GameObject s in rule2_obj) {
			s.SetActive (true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_RuleObject2_out(){
		foreach (GameObject s in rule2_obj) {
			s.SetActive (false);	// ゲームオブジェクトをアクティブ化
		}
	}
	//ルール
	private void enabled_RuleObject3(){
		foreach (GameObject s in rule3_obj) {
			s.SetActive (true);	// ゲームオブジェクトをアクティブ化
		}
	}
	private void enabled_RuleObject3_out(){
		foreach (GameObject s in rule3_obj) {
			s.SetActive (false);	// ゲームオブジェクトをアクティブ化
		}
	}
}