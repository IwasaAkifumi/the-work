//安藤.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class ScaleChange : MonoBehaviour {

	public PingPongMove _pingPong;
	public TextMesh _resultText;
	 Vector3 defaultScale;

	public static bool isTapped = false;
	public  static float resultValue;
	
	public bool CHANGE_X = false;
	public bool CHANGE_Y = false;
	public bool CHANGE_Z = false;
	
	// Use this for initialization
	void Start () {


		_pingPong = this.gameObject.GetComponent<PingPongMove>();
		defaultScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		


		if (!isTapped) {
			this.changeSize();
		}




	}
	
      public void Attack(){
		resultValue = _pingPong.value;
		
		isTapped = true;
	if (resultValue <= 1.999999999999999999f) {
		BossHP.skill=5;
		
	}
	isTapped = true;
	if (resultValue == 2.0f) {
		BossHP.skill=0;
		
	}

}
     

	public void changeSize() {
		Vector3 newSize = transform.localScale;
		
		if (CHANGE_X) {
			newSize.x = defaultScale.x * _pingPong.value / _pingPong.maxValue;
		}
		if (CHANGE_Y) {
			newSize.y = defaultScale.y * _pingPong.value / _pingPong.maxValue;
		}
		
		if (CHANGE_Z) {
			newSize.z = defaultScale.z * _pingPong.value / _pingPong.maxValue;
		}
		transform.localScale = newSize;
	}

}
