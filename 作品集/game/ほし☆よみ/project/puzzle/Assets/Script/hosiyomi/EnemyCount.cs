using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCount : MonoBehaviour {
	public GameSystem GameSystem;
	[SerializeField]
	public int score = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text = "あと" + score;
	}
}
