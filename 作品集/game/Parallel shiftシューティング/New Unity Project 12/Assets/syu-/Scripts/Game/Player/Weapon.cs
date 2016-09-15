using UnityEngine;
using System.Collections;

public class Weapon{
	private int type	= 0;			// 武器タイプ
	private int num		= 2;			// 武器の種類数
	
	// 武器を変更
	public void changeWeapon(){
		type = (type + 1) % num;
		Debug.Log("現在の武器：" + type);
	}
	// 武器タイプを返す
	public int getType(){
		return type;
	}
}