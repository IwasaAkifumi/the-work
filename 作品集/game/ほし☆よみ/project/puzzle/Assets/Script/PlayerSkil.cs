using UnityEngine;
using System.Collections;

public class PlayerSkil : MonoBehaviour {
	public GameObject playerSkill;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0) {
			iTween.MoveTo (playerSkill, iTween.Hash ("x", 0f, "time", 1.5f, "isLocal", true));
		}
	}
}
