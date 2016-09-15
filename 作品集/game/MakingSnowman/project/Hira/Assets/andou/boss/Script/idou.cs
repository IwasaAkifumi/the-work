//安藤.
using UnityEngine;
using System.Collections;

public class idou : MonoBehaviour {

	public float time01=0;
	public float time02=0;
	public string flag;
	public GameObject run;
	public GameObject Player1;
 	// Use this for initialization
	void Start () {
		flag="off";
		run = GameObject.Find ("run");
		Player1 = GameObject.Find ("Player1");
		Player1.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (gamesystem2.flag01 == "on") {
			time01 += Time.deltaTime;
			if (flag == "off" && time01 >= 0.75f) {


				transform.position += new Vector3 (0.5f, 0.0f, 0.0f);

					if (flag == "off" && time01 >= 1.05f) {
						
						flag = "on";
						time01 = 0.0f;
						Player1.SetActive (true);
						run.SetActive (false);
					}
				}
			}

	}
	}

