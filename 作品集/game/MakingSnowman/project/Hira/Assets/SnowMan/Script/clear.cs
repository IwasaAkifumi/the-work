using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class clear : MonoBehaviour {
	public Player Player;

	public GameObject fice;
	public GameObject botan;
	public GameObject mahu;
	public GameObject kao;
	public GameObject baketu;
	public GameObject right;
	public GameObject left;

	public bool Botan = false;
	public bool Mahu = false;
	public bool Kao = false;
	public bool Baketu = false;
	public bool Right = false;
	public bool Left = false;

	private RectTransform hoge;
	public float x,y;
	// Use this for initialization
	void Start () {

		botan.SetActive (false);
		mahu.SetActive (false);
		kao.SetActive (false);
		baketu.SetActive (false);
		right.SetActive (false);
		left.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		Clear_pat ();
	}
	public void  Clear_pat(){
		fice.transform.localScale = new Vector3 (Player.player_x, Player.player_y, Player.player_z);
		if (Botan) {
			botan.SetActive (true);
		}
		if (Mahu) {
			mahu.SetActive (true);
		}
		if (Kao) {
			kao.SetActive (true);
		}
		if (Baketu) {
			baketu.SetActive (true);
		}
		if (Right) {
			right.SetActive (true);
		}
		if (Left) {
			left.SetActive (true);
		}
	}
}
