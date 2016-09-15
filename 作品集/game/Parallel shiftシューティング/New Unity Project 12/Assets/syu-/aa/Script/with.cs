using UnityEngine;
using System.Collections;

public class with : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	[RPC]
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
				GetComponent<NetworkView>().RPC("ToggleColor", RPCMode.All);
			}
		}
}
}
