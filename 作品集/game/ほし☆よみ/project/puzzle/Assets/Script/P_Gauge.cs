using UnityEngine;
using System.Collections;

public class P_Gauge : MonoBehaviour {
	private float P_gaugeMax;
	private float P_gaugeNow;
	public GameObject gameOverText;
	public GameSystem GameSystem;
	public ballScript ballScript;
	public TimeScript TimeScript;
	Transform t1;
	Transform t1_2;

	public GameObject revivalBtn;
	public AudioClip gameoverOn;

	bool One = true;

	public AudioClip buttonOn;
	
	// Use this for initialization
	void Start () {
		t1 = transform.FindChild("Controller1");
		t1_2 = transform.FindChild("Controller1_2");
		GameObject GameSystem = GameObject.Find("GameSystem");
		revivalBtn.transform.localScale = new Vector3(0, 0, 1);
		revivalBtn.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (P_gaugeNow < 0) P_gaugeNow = 0;
		iTween.ScaleUpdate (t1.gameObject, iTween.Hash ("x", P_gaugeNow / P_gaugeMax, "time", 2.0f, "easetype", "easeInCubic"));
		Invoke ("PlayerHP_2", 3.0f);
		if (P_gaugeNow <= 0) {

			PlayerFadeOut();
			StartCoroutine ("GameOver");
			iTween.MoveTo(gameOverText, iTween.Hash("y", 150f,"time", 1.5f, "easeType", "easeOutBounce","delay", 1f,"isLocal",true));
			ballScript.isPlaying = false;
			if (One) {
				iTween.Stop(TimeScript.TimeGauge);
				One = false;
			}
		}

	}





	public void P_SetNow(float value) {
		P_gaugeNow = value;
	}
	
	public void P_SetMax(float value) {
		P_gaugeMax = value;
	}
	IEnumerator GameOver () {
		gameOverText.SetActive(true);
		GetComponent<AudioSource>().PlayOneShot(gameoverOn);
		//exchangeButton.GetComponent<Button>().interactable = false;
		yield return new WaitForSeconds(4.0f);
			RevivalBtn();
		
	}
	void PlayerFadeOut() {
		// SetValue()を毎フレーム呼び出して、１秒間に１から０までの値の中間値を渡す
		iTween.FadeTo(GameSystem.P_damageMotion, iTween.Hash("alpha", 0, "time", 1));
	}
	void PlayerHP_2() {
		iTween.ScaleUpdate (t1_2.gameObject, iTween.Hash ("x", P_gaugeNow / P_gaugeMax, "time", 3.0f, "easetype", "easeInOutExpo"));
	}
	public void  RevivalBtn(){
		revivalBtn.SetActive (true);
		iTween.ScaleTo (revivalBtn, iTween.Hash ("x", 1, "y", 1,"time",0.3));
	}
	public void  RevivalScene(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		FadeManager.Instance.LoadLevel("Main1",1.0f);
	}
	public void  RevivalScene2(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		FadeManager.Instance.LoadLevel("Main2",1.0f);
	}
	public void  RevivalScene3(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		FadeManager.Instance.LoadLevel("Main3",1.0f);
	}
}