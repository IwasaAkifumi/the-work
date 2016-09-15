using UnityEngine;
using System.Collections;

public class SlideIN_A : MonoBehaviour {

	Vector3 x1;               //画像のｘ座標
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		x1 = transform.position;
		if (gamesystem2.cutinflag02 == "on") {
			if (x1.x < 0) {
				x1.x = x1.x + 1;
				transform.position = x1;
			} else {
				Destroy (this);
			}
		}
	}
}
