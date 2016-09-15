using UnityEngine;
using System.Collections;

public class Pig : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () 
	{
		Vector3 pos = transform.position;
		if( GetComponent<NetworkView>().isMine )
		{
			if( Input.GetKey("right") )
			{
				pos.x += 10f;
				transform.position = pos;
			}
			else if( Input.GetKey("left") )
			{
				pos.x -= 10f;
				transform.position = pos;			
			}
			else if( Input.GetKey("up") )
			{
				pos.z += 10f;
				transform.position = pos;			
			}
			else if( Input.GetKey("down") )
			{
				pos.z -= 10f;
				transform.position = pos;			
			}
			
		}
	}
}
