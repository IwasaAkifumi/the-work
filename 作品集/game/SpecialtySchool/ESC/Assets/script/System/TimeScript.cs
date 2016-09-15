//安藤
using UnityEngine;

using UnityEngine.UI;

using System.Collections;



public class TimeScript : MonoBehaviour {
	
	public static float time = 480;
	
	//public ballScript BallScript;
	
	
	
	void Start () {
		
		//初期値60を表示
		
		//float型からint型へCastし、String型に変換して表示
		
		GetComponent<Text>().text = ((int)time).ToString();
		
	}
	
	
	
	void Update (){
		
		//1秒に1ずつ減らしていく
		

		
		//マイナスは表示しない
		
		
		if(time < 0)time=0;
		
		
		
		GetComponent<Text> ().text = ((int)time).ToString ();
		
		
		// シングルトンインスタンスを取得する
		ScreenFadeManager fadeManager = ScreenFadeManager.Instance;
		
		// フェードイン
	

		if(time<=0){
			// フェードイン
			fadeManager.FadeOut(2.0f, Color.black, ()=> {
				// フェードイン後に行う処理
			
			Application.LoadLevel("gameover");
			Destroy(gameObject);
			time=480;
				Debug.Log("フェードイン完了");
			});

		}
		
		
	}
	
	
}


