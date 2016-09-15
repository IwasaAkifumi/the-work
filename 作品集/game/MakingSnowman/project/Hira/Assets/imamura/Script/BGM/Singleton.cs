//(http://marupeke296.com/UNI_SND_No3_SoundPlayer.html)から引用
//今村.
using UnityEngine;
using System.Collections;

public class Singleton<T> where T : class, new() {
	
	static T obj = null;
	
	Singleton() {}
	
	public static T instance {
		get {
			if ( obj == null )
				obj = new T();
			return obj;
		}
	}
}