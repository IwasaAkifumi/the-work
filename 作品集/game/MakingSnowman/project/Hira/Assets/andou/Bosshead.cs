﻿//今村.
using UnityEngine;
using System.Collections;

public class Bosshead : MonoBehaviour {

	static public Vector3 m_pos;
	// Use this for initialization
	void Start () {
		m_pos = transform.localPosition;  // 形状位置を保持
	}
	
	// Update is called once per frame
	void Update () {
		/*if(RunHeadScript.m_pos.z == 10)
		{
			m_pos.z = 10;
		}
		if(RunHeadScript.m_pos.z == -4)
		{
			m_pos.z = -2;
		}*/
		m_pos.z = -2;
		transform.localPosition = m_pos;  // 移動を更新
	}
}
