//安藤.
using UnityEngine;
using System.Collections;

public class player02 : MonoBehaviour {


	Vector3 x1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		x1 = transform.position;
		if (gamesystem2.idouflag == "on") {

			if (x1.x < -4.6) {
				//rb2D.AddForce (new Vector2 (+30.0f, 0.0f));
				x1.x = x1.x + 0.5f;
				transform.position = x1;
			} else {
				Destroy (this);
			}
		}
	}
}
