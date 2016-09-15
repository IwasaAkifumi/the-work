using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScript : MonoBehaviour {
	public float time = 60;
	public GameObject gameOverText;
	public GameSystem GameSystem;
	public float timeGauge = 60f;
	public GameObject TimeGauge;
	public GameObject StartButton;
	public ballScript ballScript;
	public ScoreScript ScoreScript;
	public bool timeisPlaying;
	public GameObject revivalBtn;
	public GameObject stage;
	public GameObject zin;
	bool One = true;

	[SerializeField]
	private Text _textCountdown;

	public AudioClip buttonOn;
	public AudioClip countOn;
	
	void Start () {
		gameOverText.SetActive(false);
		timeisPlaying = false;
		//初期値60を表示
		//float型からint型へCastし、String型に変換して表示
		GetComponent<Text>().text = ((int)time).ToString();

		_textCountdown.text = "";
		iTween.MoveFrom (stage, iTween.Hash ("x", -200f, "time", 1.5f,"Delay",0.2));
	}
	
	void Update (){
		//1秒に1ずつ減らしていく
		if (ballScript.isPlaying && timeisPlaying) {
			time -= Time.deltaTime;
			if (One) {
				TimeGauge.transform.localScale = new Vector3(time/timeGauge*110, 110, 1);
				//iTween.ScaleTo (TimeGauge, iTween.Hash ("x", 0f, "time",timeGauge, "easetype", "easeInOutQuad"));
			}
			if (time <= 0) {
				StartCoroutine ("GameOver");
				iTween.MoveTo (gameOverText, iTween.Hash ("y", 150f, "time", 1.5f, "easeType", "easeOutBounce", "isLocal", true));
			}
			//マイナスは表示しない
			if (time < 0)time = 0;
			GetComponent<Text> ().text = ((int)time).ToString ();
		}
	}
	IEnumerator GameOver () {
		gameOverText.SetActive(true);
		//exchangeButton.GetComponent<Button>().interactable = false;
		GameSystem.isPlaying = false;
		ballScript.isPlaying = false;
		yield return new WaitForSeconds(2.0f);
		/*if (Input.GetMouseButtonDown (0)) {
			FadeManager.Instance.LoadLevel("Menu",1.0f);
		}*/
		RevivalBtn();
	}
	public void OnClickButtonStart()
	{
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		StartCoroutine(CountdownCoroutine());
		StartButton.SetActive (false);
		ballScript.isPlaying = true;
		stage.SetActive(false);
	}
	
	IEnumerator CountdownCoroutine()
	{
		//_imageMask.gameObject.SetActive(true);
		_textCountdown.gameObject.SetActive(true);

		_textCountdown.text = "3";
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "2";
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "1";
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		yield return new WaitForSeconds(1.0f);
		
		_textCountdown.text = "GO!";
		GetComponent<AudioSource>().PlayOneShot(countOn);
		yield return new WaitForSeconds(1.0f);

		_textCountdown.text = "";
		timeisPlaying = true;
		_textCountdown.gameObject.SetActive(false);

		//timeisPlaying = true;
		yield return new WaitForSeconds(2.0f);
		

		//_imageMask.gameObject.SetActive(false);
	}
	public void  RevivalBtn(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		revivalBtn.SetActive (true);
		iTween.ScaleTo (revivalBtn, iTween.Hash ("x", 1, "y", 1,"time",0.3));
	}
	public void  RevivalScene(){
		FadeManager.Instance.LoadLevel("Main1",1.0f);
	}
}