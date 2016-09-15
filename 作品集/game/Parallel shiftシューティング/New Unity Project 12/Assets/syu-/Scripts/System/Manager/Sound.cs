using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
	private	AudioSource		audioSource;	// AudioSorceコンポーネント格納用
	public	AudioClip[]		sound;			// 効果音の格納用
	
	void Start () {
		audioSource			= gameObject.AddComponent< AudioSource >();	// AudioSorceコンポーネントを追加し、変数に代入.
		audioSource.loop	= false;		// 音のループなし。
	}
	
	private void soundRings(int value){
		if(value < 0){ return; }				// もし指定された番号が負の値なら、処理を抜ける.
		if(value > sound.Length-1){ return; }	// もし指定された番号が、sound配列に格納されている数-1より大きいなら、処理を抜ける
		if(sound[value] == null){ return; }		// もし中身に何も入っていなければ、処理を抜ける。
		
		audioSource.PlayOneShot(sound[value]);	// 該当の音を一回だけ再生
	}
}