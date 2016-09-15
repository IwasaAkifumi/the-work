using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	[RPC]
	// Update is called once per frame
	void ToggleColor()
	{
		SpriteRenderer r = GetComponent<SpriteRenderer>();
		r.color = ( r.color == Color.black ) ? Color.white : Color.black;
	}
	
	void Update () 
	{		
		if( GetComponent<NetworkView>().isMine )
		{
			if( Input.GetMouseButtonDown(0) )
			{
				ToggleColor();
			}
		}
	}
}
