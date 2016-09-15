﻿using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		 if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.position += this.transform.right* 0.25f;
		}
		else if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.position += this.transform.right * -0.25f;
		}
	}
}
