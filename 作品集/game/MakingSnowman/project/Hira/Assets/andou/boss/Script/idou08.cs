//安藤.
using UnityEngine;
using System.Collections;

public class idou08 : MonoBehaviour {

	Vector2 x1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 x1 = GetComponent<RectTransform> ().anchoredPosition;
		if (gamesystem2.cutinflag02 == "on") {
			if (x1.x < 0) {
				x1.x = x1.x + 128;
				GetComponent<RectTransform> ().anchoredPosition = x1;
			} else {
				Destroy (this);
			}
		}
	}
}
