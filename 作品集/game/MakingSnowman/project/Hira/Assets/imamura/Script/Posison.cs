//今村.
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class Posison : MonoBehaviour {
	Slider slider;
	static public Transform objA,objB;
	static public int score;
	static public float dis=0;
	// Use this for initialization
	void Start () {
		slider = GameObject.Find("Pos").GetComponent<Slider>();
		objA = GameObject.Find("Player").transform;
		objB = GameObject.Find("Origin").transform;
		score = 0;
	}
	void Update(){
		dis = Vector3.Distance(objA.transform.position, objB.transform.position);
		score = Mathf.RoundToInt(dis);
		if (score >= 380)
			score = 380;
		slider.value = score;
		if (score < 0)
			score = 0;
	}
}
