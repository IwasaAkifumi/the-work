//今村.
using UnityEngine;
using System.Collections;

public class CharaBackHadaka : MonoBehaviour {

	public GameObject explosion;
	
	public static int x;
	
	// Use this for initialization
	void Start () {
		x = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (x == 1) {
			Explosion ();
			x = 0;
		}
		
		
	}
	public void Explosion ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}
}
