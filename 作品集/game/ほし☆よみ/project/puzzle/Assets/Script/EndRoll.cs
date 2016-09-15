using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndRoll : MonoBehaviour {
	public GameObject endRoll;
	public GameObject endBtn;
	public float time = 35;
	bool One = true;

	// Use this for initialization
	void Start () {

		endBtn.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		endRoll.transform.position += new Vector3 (0, 3, 0);
		if (time <= 0) {
			time = 0;
			EndBtn ();
		}
	}
	public void  EndBtn(){
		endBtn.SetActive (true);
	}
}
