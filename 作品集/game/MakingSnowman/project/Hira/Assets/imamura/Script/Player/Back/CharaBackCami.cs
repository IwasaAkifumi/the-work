//今村.
using UnityEngine;
using System.Collections;

public class CharaBackCami : MonoBehaviour {

	static public Vector3 m_pos;
	// Use this for initialization
	void Start () {
		m_pos = transform.localPosition;  // 形状位置を保持
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = m_pos;  // 移動を更新
	}
}
