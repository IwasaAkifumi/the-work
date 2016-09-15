using UnityEngine;
using System.Collections;

public class Image : MonoBehaviour {
	private Image Menu;

	// Use this for initialization
	void Start () {
		Menu = GameObject.Find ("Menu").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
