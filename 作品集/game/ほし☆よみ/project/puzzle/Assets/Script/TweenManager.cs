using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using uTools;
public class TweenManager : MonoBehaviour {

	public GameSystem GameSystem;
	public TimeScript TimeScript;

	public GameObject UIControllerPref;
	public GameObject ahebtn;
	public GameObject titlebtn;
	public GameObject menubtn;
	public GameObject helpbtn;
	public GameObject tyuu;
	public GameObject backbtn;
	public GameObject Menufade;
	public GameObject TitleBack;
	public GameObject MenuBack;
	public GameObject aheBack;
	public GameObject MenuBar;
	public GameObject EnemyCount;
	
	public GameObject[] Buttons;
	private uTweenPosition[] uTweenPositions;
	private Vector3[] originalPosition;
	public ballScript ballScript;
	private Rigidbody2D rb1;
	private Rigidbody2D rb;
	private Vector2   _angularVelocity;

	public AudioClip buttonOn;

	// Use this for initialization

	void Awake () {
		// charm of iTween 
		//iTween.Init(this.gameObject);
	}

	void Start () {
		ahebtn.SetActive (false);

		titlebtn.SetActive (false);

		menubtn.SetActive (false);
		helpbtn.SetActive (false);
		backbtn.SetActive (false);
		Menufade.SetActive (false);

		TitleBack.transform.localScale = new Vector3(0, 0, 1);
		TitleBack.SetActive (false);
		MenuBack.transform.localScale = new Vector3(0, 0, 1);
		MenuBack.SetActive (false);
		aheBack.transform.localScale = new Vector3(0, 0, 1);
		aheBack.SetActive (false);
		MenuBar.SetActive (false);


		
		if (Buttons.Length > 0) {
			uTweenPositions = new uTweenPosition[Buttons.Length];
			originalPosition = new Vector3[Buttons.Length];
			for (int i = 0; i < Buttons.Length; i++) {
				uTweenPositions [i] = Buttons [i].GetComponent<uTweenPosition> ();
				Vector3 from =  Buttons [i].transform.localPosition;
				from.x = 600;
				originalPosition [i] = from;
				Vector3 to = Buttons [i].transform.localPosition;
				uTweenPositions [i].from = from;
				uTweenPositions [i].to = to;

			}
		}
	}

	public void StartTweens(){
		if (ballScript.isPlaying && TimeScript.timeisPlaying) {
			StopCoroutine ("IStartTweens");
			initPosition ();
			StartCoroutine ("IStartTweens");
			MenuBtn ();
		}

	}
	
	private IEnumerator IStartTweens(){
		if (uTweenPositions.Length > 0) {
			for(int i=0; i<  uTweenPositions.Length;i++){
				
				uTweenPositions[i].RePlay ();
				yield return new WaitForSeconds (0.1f);

					
			}
		}
	}
	
	private void initPosition(){
		if (uTweenPositions.Length > 0) {
			for(int i=0; i<  Buttons.Length;i++){
				Buttons [i].transform.localPosition = originalPosition [i];
				
			}
		}
	}
	
	private void resetTweens(){
		if (uTweenPositions.Length > 0) {
			foreach (uTweenPosition tp in uTweenPositions) {
				float temp = tp.duration;
				tp.duration = 0f;
				tp.ResetTimeBeforePlay ();
				tp.duration = temp;
			}
		}
	}
	public void  MenuBtn(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		ahebtn.SetActive (true);
		titlebtn.SetActive (true);
		menubtn.SetActive (true);
		helpbtn.SetActive (true);
		backbtn.SetActive (true);
		Menufade.SetActive (true);
		ballScript.isPlaying = false;
		TimeScript.timeisPlaying = false;
		Menubar ();
		GameObject[] Drop = GameObject.FindGameObjectsWithTag ("Block");
		foreach (GameObject obs in Drop) {
			Vector3 localGravity;
			Rigidbody2D rb = obs.GetComponent<Rigidbody2D> ();
			rb.isKinematic = true;
		}
		GameObject[] Drope = GameObject.FindGameObjectsWithTag ("EnemyDrop");
		foreach (GameObject obs in Drope) {
			Vector3 localGravity;
			Rigidbody2D rb = obs.GetComponent<Rigidbody2D> ();
			rb.isKinematic = true;
		}

		iTween.Stop(TimeScript.TimeGauge);
	}
	public void  BackBtn(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		ahebtn.SetActive (false);
		titlebtn.SetActive (false);
		menubtn.SetActive (false);
		helpbtn.SetActive (false);
		backbtn.SetActive (false);
		Menufade.SetActive (false);
		ballScript.isPlaying = true;
		TimeScript.timeisPlaying = true;
		BackFalse ();
		Menubar2();
		GameObject[] Drop = GameObject.FindGameObjectsWithTag ("Block");
		foreach (GameObject obs in Drop) {
			Vector3 localGravity;
			Rigidbody2D rb = obs.GetComponent<Rigidbody2D> ();
			rb.isKinematic = false;
		}
		GameObject[] Drope = GameObject.FindGameObjectsWithTag ("EnemyDrop");
		foreach (GameObject obs in Drope) {
			Vector3 localGravity;
			Rigidbody2D rb = obs.GetComponent<Rigidbody2D> ();
			rb.isKinematic = false;
		}
		//Time.timeScale = 1;
	}
	public void  TitleBackBtn(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		TitleBack.SetActive (true);
		iTween.ScaleTo (TitleBack, iTween.Hash ("x", 1, "y", 1,"time",0.3));
	}
	public void  TitleBackBtn2(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		iTween.ScaleTo (TitleBack, iTween.Hash ("x", 0, "y", 0,"time",0.3));
		Invoke ("BackFalse", 0.3f);
	}
	public void  MenuBackBtn(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		MenuBack.SetActive (true);
		iTween.ScaleTo (MenuBack, iTween.Hash ("x", 1, "y", 1,"time",0.3));
	}
	public void  MenuBackBtn2(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		iTween.ScaleTo (MenuBack, iTween.Hash ("x", 0, "y", 0,"time",0.3));
		Invoke ("BackFalse", 0.3f);
	}
	public void  aheBackBtn(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		aheBack.SetActive (true);
		iTween.ScaleTo (aheBack, iTween.Hash ("x", 1, "y", 1,"time",0.3));
	}
	public void  helpBackBtn(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		tyuu.SetActive (true);
		//iTween.ScaleTo (aheBack, iTween.Hash ("x", 1, "y", 1,"time",0.3));
	}
	public void  aheBackBtn2(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		iTween.ScaleTo (aheBack, iTween.Hash ("x", 0, "y", 0,"time",0.3));
		Invoke ("BackFalse", 0.3f);
	}
	public void  Menubar(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		MenuBar.SetActive (true);
		iTween.MoveTo  (MenuBar, iTween.Hash ("x", -250, "time",0.3,"Delay",0.1,"isLocal",true));
	}
	public void  Menubar2(){
		GetComponent<AudioSource>().PlayOneShot(buttonOn);
		iTween.MoveTo (MenuBar, iTween.Hash ("x", -600, "time",0.3,"Delay",0,"isLocal",true));
		Invoke ("BarFalse", 0.3f);
	}
	public void  BackFalse(){
		TitleBack.SetActive (false);
		MenuBack.SetActive (false);
		aheBack.SetActive (false);
	}
	public void  BarFalse(){
		MenuBar.SetActive (false);
	}
}
