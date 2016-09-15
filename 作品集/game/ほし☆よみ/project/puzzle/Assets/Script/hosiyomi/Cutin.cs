using UnityEngine;
using System.Collections;

public class Cutin : MonoBehaviour {

	public ballScript ballScript;
	public ScoreScript ScoreScript;

	public GameObject cutin;
	public GameObject cutin0;
	public GameObject cutin1;
	public GameObject cutin2;


	// Use this for initialization
	void Start () {
		cutin.SetActive (false);
		GameObject GameSystem = GameObject.Find("GameSystem");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void PlayerSkill () {
		RaycastHit2D hitChara = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
		if (hitChara.collider != null) {
			GameObject hitObj = hitChara.collider.gameObject;
			
			/*if (ballScript.skill >= 10) {
				if(hitObj.name == "chara"){
					//Debug.Log ("charaを押した");
					cutin.SetActive(true);
				}*/

				switch (hitObj.name) {
				case "Chara":
					Debug.Log ("charaを押した");
					cutin.SetActive (true);
					ballScript.skill = 0;
					break;
				case "Chara2":
					Debug.Log ("chara2を押した");
					break;
				case "Chara3":
					Debug.Log ("chara3を押した");
					break;

			}
		}
	}
}
