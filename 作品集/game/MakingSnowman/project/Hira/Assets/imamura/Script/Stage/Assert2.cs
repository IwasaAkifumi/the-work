
//今村.
using UnityEngine;
using System.Collections;

public class Assert2 : MonoBehaviour {

	static public Vector3 m_pos;
	static public int x=0;
	static public int y;
	// Use this for initialization
	void Start () {
		y = 0;
		m_pos = transform.localPosition;  // 形状位置を保持
	}
	
	// Update is called once per frame
	void Update () {
		if (y == 1) {
			x++;
			if(x>=30){
				m_pos.z = 10;
				y=0;
				x=0;
			}
		}
		transform.localPosition = m_pos;  // 移動を更新

	}
}
