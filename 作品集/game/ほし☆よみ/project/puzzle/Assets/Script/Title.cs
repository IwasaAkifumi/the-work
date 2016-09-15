using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	public GameSystem GameSystem;

	public GameObject character;
	Hashtable left = new Hashtable();      // ハッシュテーブルを用意
	Hashtable right = new Hashtable();      // ハッシュテーブルを用意
	bool iTweenMoving = false;

	public AudioClip buttonOn;



	// Use this for initialization
	void Start () {

		right.Add ("x", 400);            // xを10まで移動
		right.Add ("time", 0.8f);        // トゥイーン時間は3秒
		right.Add ("oncomplete", "CompleteHandler");
		right.Add ("oncompletetarget", gameObject);
		left.Add ("x", -400);            // xを10まで移動
		left.Add ("time", 0.8f);        // トゥイーン時間は3秒
		left.Add ("oncomplete", "CompleteHandler");
		left.Add ("oncompletetarget", gameObject);
	}

	void Update () {


	}

	public void  TitleScene(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		FadeManager.Instance.LoadLevel("Title",1.0f);
	}
	public void  MenuScene(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		FadeManager.Instance.LoadLevel("Menu",1.0f);
		//StartCoroutine ("LoadNextLevel");
		//StopCoroutine ("LoadNextLevel");
	}
	public void  MainScene(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		FadeManager.Instance.LoadLevel("Main1",1.0f);
	}
	public void  MainScene2(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		FadeManager.Instance.LoadLevel("Main2",1.0f);
	}
	public void  MainScene3(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		FadeManager.Instance.LoadLevel("Main3",1.0f);
	}
	public void  EndScene(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		FadeManager.Instance.LoadLevel("End",1.0f);
	}
	public void  RightButton(){
		if (iTweenMoving) {
			iTweenMoving = true;
			if (Slide.c <= 1) {
				Slide.c = Slide.c + 1;
				Debug.Log (Slide.c);
				iTween.MoveBy (character, left);
			//	Invoke ("OnCompleteHandler", 1.0f);
			}
		}
	}
	public void  LeftButton(){
		if (iTweenMoving) {
			iTweenMoving = true;
			if (Slide.c > 0) {
				Slide.c = Slide.c - 1;
				Debug.Log (Slide.c);
				iTween.MoveBy (character, right);
				//Invoke ("OnCompleteHandler", 1.0f);
			}
		}
	}
	void OnCompleteHandler(){
		iTweenMoving = false;
	}
	IEnumerator LoadNextLevel() {
		AsyncOperation ao = Application.LoadLevelAsync("Menu");
		ao.allowSceneActivation = false;
		while( ao.progress < 0.9f || 10< 5) {
			//演出などで確実に待ちを入れたい場合は ( ao.progress < 0.9f || 読み込み時間 < 確実に待たせたい時間 ) みたいな感じで判定
			yield return new WaitForEndOfFrame();
		}
		//次のレベルに遷移
		ao.allowSceneActivation = true;
		//ao.isDoneはfalseのまま
		yield return null;
	}
	IEnumerator LoadScene(){
		
		AsyncOperation async = Application.LoadLevelAsync("Menu");
		async.allowSceneActivation = false;    // シーン遷移をしない
		
		while (async.progress < 0.9f) {
			Debug.Log(async.progress);
			//loadingText.text = (async.progress * 100).ToString("F0") + "%";
			//loadingBar.fillAmount = async.progress;
			yield return new WaitForEndOfFrame();
		}
		
		Debug.Log("Scene Loaded");
		
		//loadingText.text = "100%";
		//loadingBar.fillAmount = 1;
		
		yield return new WaitForSeconds(1);
		
		async.allowSceneActivation = true;    // シーン遷移許可
		
	}
}