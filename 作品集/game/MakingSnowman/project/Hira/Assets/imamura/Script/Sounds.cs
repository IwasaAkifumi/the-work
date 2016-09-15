//今村.
using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

	public AudioClip audioClip;
	private AudioSource audioSource;
	public static int x;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		x = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (x == 1) {
			audioSource.clip = audioClip;
			audioSource.Play ();
		}
	}
}
