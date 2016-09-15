//安藤.
using UnityEngine;
using System.Collections;


public class PingPongMove : MonoBehaviour {
    

	public float maxValue = 1f;
	public float changeSpeed = 1.0f;
	public  float  stop=0.0f;
	bool up = true;
	public  float value;

	void Start () {

		value = 0.0f;
	}

	
	void Update() {

		if (up) {
			value += Time.deltaTime * changeSpeed;


			if (value >= 100.0f ) {


				value = 100.0f;
				if(gamesystem2.hikariflag=="off"){
				stop+=Time.deltaTime;
				}
			}
			if (stop >= 0.4f) {
				value=0.0f;
				stop=0.0f;

			}

		
		}
	}




}
