using UnityEngine;
using System.Collections;

public class Icon : MonoBehaviour {
	public Player Player;
	public GameObject Small;
	public GameObject Middle;
	public GameObject Big;
	// Use this for initialization
	void Start () {
		Small.SetActive (false);
		Middle.SetActive (false);
		Big.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.player_x_size >= 5)Small.SetActive (true);
		if (Player.player_x_size < 5)Small.SetActive (false);

		if (Player.player_x_size >= 10)Middle.SetActive (true);
		if (Player.player_x_size < 10)Middle.SetActive (false);

		if (Player.player_x_size >= 15)Big.SetActive (true);
		if (Player.player_x_size < 15)Big.SetActive (false);
	
	}
}
