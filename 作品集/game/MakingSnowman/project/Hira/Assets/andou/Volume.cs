//安藤.
using UnityEngine;
using System.Collections;

public class Volume : MonoBehaviour {
	int x;

	// Use this for initialization
	void Start () {
		x = 0;

		AudioListener.volume = 0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		x++;
		if (x >= 15) {

			AudioListener.volume = 1f;
		}
	
	}
}
