//安藤.
using UnityEngine;
using System.Collections;

public class idou02 : MonoBehaviour {
	Vector2 x1;  
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gamesystem2.falseflag == "on") {
			Vector2 x1 = GetComponent<RectTransform> ().anchoredPosition;
			if (x1.y > 0) {
				x1.y = x1.y - 72;
				GetComponent<RectTransform> ().anchoredPosition = x1;
			} else {
				Destroy (this);
			}
		}
	}
}
