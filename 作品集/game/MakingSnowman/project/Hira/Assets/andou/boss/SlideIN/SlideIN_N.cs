using UnityEngine;
using System.Collections;

public class SlideIN_N : MonoBehaviour {
	
	//Rigidbody2D rb2D;
	Vector3 x1;               //画像のｘ座標
	
	// Use this for initialization
	void Start () {
		//rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		x1 = transform.position;
		if (gamesystem2.cutinflag03 == "on") {
			if (x1.x < 0) {
				//rb2D.AddForce (new Vector2 (+30.0f, 0.0f));
				x1.x = x1.x + 1;
				transform.position = x1;
			} else {
				Destroy (this);
			}
		}
	}
}
