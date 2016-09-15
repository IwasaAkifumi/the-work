//今村.
using UnityEngine;
using System.Collections;

public class ChengBack : MonoBehaviour {

	static public Vector3 m_pos;
	// Use this for initialization
	void Start () {
		m_pos = transform.localPosition;  // 形状位置を保持
	}
	
	// Update is called once per frame
	void Update () {
		if (Posison.score >= 380) {
			m_pos.x -= 0.25f;
			if (m_pos.x <= -170) {
				m_pos.x = -170;
				FadeManager.Instance.LoadLevel("Boss",1.0f);
			}
		}
			transform.localPosition = m_pos;  // 移動を更新
		
	}
}
