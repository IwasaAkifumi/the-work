//今村.
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollButton : MonoBehaviour {
	public AudioClip audioClip;
	private AudioSource audioSource;
	public AnimationCurve animCurve = AnimationCurve.Linear(0, 0, 1, 1);
	public Vector3 inPosition;        // スライドイン後の位置
	public Vector3 outPosition;      // スライドアウト後の位置
	public float duration = 5.0f;    // スライド時間（秒）
	void Start () {
		//GameObject.Find("Panel").SetActive(false);
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	// スライドイン（Pauseボタンが押されたときに、これを呼ぶ）
	public void SlideIn(){
		StartCoroutine( StartSlidePanel(true) );
		audioSource.clip = audioClip;
		audioSource.Play ();
	}
	
	// スライドアウト
	public void SlideOut(){
		StartCoroutine( StartSlidePanel(false) );
	}
	
	private IEnumerator StartSlidePanel( bool isSlideIn ){
		float startTime = Time.time;    // 開始時間
		RectTransform rectTransform = gameObject.GetComponent< RectTransform >();
		Vector3 startPos = rectTransform.localPosition;  // 開始位置
		Vector3 moveDistance;            // 移動距離および方向
		if (isSlideIn) {
			moveDistance = (inPosition - startPos);
		} else {
			moveDistance = (outPosition - startPos);
		}
		while ((Time.time - startTime) < duration) {
			transform.localPosition = startPos + moveDistance * animCurve.Evaluate ((Time.time - startTime) / duration);
			yield return 0;        // 1フレーム後、再開
		}
	rectTransform.localPosition = startPos + moveDistance;
	}
}

