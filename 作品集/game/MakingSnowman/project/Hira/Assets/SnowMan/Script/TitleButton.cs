//今村.
using UnityEngine;
using System.Collections;

public class TitleButton : MonoBehaviour {
	public AudioClip audioClip;
	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		//GameObject.Find("Panel").SetActive(false);
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Button() {
		//audioSource.clip = audioClip;
		//audioSource.Play ();
		FadeManager.Instance.LoadLevel("One",1.0f);
	}
	public void Button2() {
		//audioSource.clip = audioClip;
		//audioSource.Play ();
		FadeManager.Instance.LoadLevel("Quest",1.0f);
	}
	public void QuestButton() {
		//audioSource.clip = audioClip;
		//audioSource.Play ();
		FadeManager.Instance.LoadLevel("Quest",1.0f);
	}
	public void GameButton() {
	//	audioSource.clip = audioClip;
		//audioSource.Play ();
		FadeManager.Instance.LoadLevel("Game",1.0f);
	}
	public void Game2() {
		//audioSource.clip = audioClip;
	//	audioSource.Play ();
		FadeManager.Instance.LoadLevel("ma2",1.0f);
	}
	public void Game3() {
		//audioSource.clip = audioClip;
		//audioSource.Play ();
		FadeManager.Instance.LoadLevel("ma1",1.0f);
	}
	public void Game4() {
		//audioSource.clip = audioClip;
		//audioSource.Play ();
		FadeManager.Instance.LoadLevel("no1",1.0f);
	}
	public void Game5() {
		//audioSource.clip = audioClip;
		//audioSource.Play ();
		FadeManager.Instance.LoadLevel("no2",1.0f);
	}
	public void Title_Button() {
		//audioSource.clip = audioClip;
		//audioSource.Play ();
		FadeManager.Instance.LoadLevel("Title",1.0f);
	}
}
