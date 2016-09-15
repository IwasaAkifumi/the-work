using UnityEngine;
using System.Collections;

public class CameraRote : MonoBehaviour {
		private Transform target;
	    int i;
	   // string[] direction = new string[]{"flont","raight","back","left"};
	/*string[] direction;
	direction = new string[10];*/
		private void Start(){
		target = GameObject.Find("flont").transform;
		i = 0;
		}
	
	private void Update(){
		if (Input.GetMouseButtonDown (0)){
			i = (i + 1)%4;
		}

	/*	if(i == 0){
			target = GameObject.Find("flont").transform;
		}
		if(i == 1){
			target = GameObject.Find("raight").transform;
		}
		if(i == 2){
			target = GameObject.Find("back").transform;
		}
		if(i == 3){
			target = GameObject.Find("left").transform;
		}*/
		transform.LookAt(target);
		}
}
