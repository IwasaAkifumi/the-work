﻿//今村.
using UnityEngine;
using System.Collections;

public class Bossblouse : MonoBehaviour {

	static public Vector3 m_pos;
	// Use this for initialization
	void Start () {
		m_pos = transform.localPosition;  // 形状位置を保持
	}
	
	// Update is called once per frame
	void Update () {
		if(RunBlouse.m_pos.z == 10)
		{
			m_pos.z = 10;
		}
		if(RunBlouse.m_pos.z == -2)
		{
			m_pos.z = -1.5f;
		}
		transform.localPosition = m_pos;  // 移動を更新
	}
}
