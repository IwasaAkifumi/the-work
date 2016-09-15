//今村.
//(http://naichilab.blogspot.jp/2013/12/unity.html)から引用.
using UnityEngine;
using System.Collections;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;
	public static T Instance {
		get {
			if (instance == null) {
				instance = (T)FindObjectOfType(typeof(T));
				
				if (instance == null) {
					Debug.LogError (typeof(T) + "is nothing");
				}
			}
			
			return instance;
		}
	}
	
}