//今村.
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class Run : MonoBehaviour {
	public Player Player;
	public  float speed = 1;
	private  float offset;

	void Update () {
		offset += Time.deltaTime * speed ;
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}