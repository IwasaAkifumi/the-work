using UnityEngine;
using System.Collections;

public class DropDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Destroy(this.gameObject);
	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.CompareTag("Block")) {
			Destroy(col.gameObject);
		}
		if (col.gameObject.CompareTag("EnemyDrop")) {
			Destroy(col.gameObject);
		}
	}
}
