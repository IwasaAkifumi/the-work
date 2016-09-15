using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class Slide : MonoBehaviour {
	private bool isFlick;
	private bool isClick;
	private Vector3 touchStartPos;
	private Vector3 touchEndPos;
	private int direction;
	public static  int c;
	public GameObject gameobject;
	Hashtable left = new Hashtable();      // ハッシュテーブルを用意
	Hashtable right = new Hashtable();      // ハッシュテーブルを用意
	bool iTweenMoving = false;	// 処理が終わったどうかを示すフラグ

	//public Sprite[] chara = Resources.LoadAll<Sprite>("img/Chara/");

	void Start() {
		c = 0;
		right.Add ("x", 400);            // xを10まで移動
		right.Add ("time", 0.8f);        // トゥイーン時間は3秒
		right.Add ("oncomplete", "CompleteHandler");
		right.Add ("oncompletetarget", gameObject);
		//table.Add("y", 50);         // yを5まで移動
		//table.Add("delay", 1.0f);       // 1秒遅らせてからトゥイーンスタート
		//iTween.MoveTo(gameObject, iTween.Hash("x", 20, "looptype", iTween.LoopType.loop));
		// 4秒かけて、y軸を260度回転
		//iTween.RotateTo(gameObject, iTween.Hash("y", 260, "time", 4.0f));
		// 4秒かけて、y軸を3倍に拡大
		//iTween.ScaleTo(gameObject, iTween.Hash("y", 3, "time", 4.0f));
		left.Add ("x", -400);            // xを10まで移動
		left.Add ("time", 0.8f);        // トゥイーン時間は3秒
		left.Add ("oncomplete", "OnCompleteHandler");
		left.Add ("oncompletetarget", gameObject);
	}

	public void Update () {
	//	Chara_c ();
		if(Input.GetKeyDown (KeyCode.Mouse0))
		{
			isFlick = true;
			touchStartPos = new Vector3(Input.mousePosition.x ,
			                            Input.mousePosition.y ,
			                            Input.mousePosition.z);
			Invoke ("FlickOff" , 0.2f);
		}
		if(Input.GetKey (KeyCode.Mouse0))
		{
			touchEndPos = new Vector3(Input.mousePosition.x ,
			                          Input.mousePosition.y ,
			                          Input.mousePosition.z);
			if(touchStartPos != touchEndPos )
			{
				ClickOff ();
			}
		}
		if(Input.GetKeyUp (KeyCode.Mouse0))
		{
			touchEndPos = new Vector3(Input.mousePosition.x ,
			                          Input.mousePosition.y ,
			                          Input.mousePosition.z);
			//Debug.Log (touchEndPos);
			if(IsFlick ())//Debug.Log ("Flick");
			{
				float directionX = touchEndPos.x - touchStartPos.x;//Debug.Log ("DirectionX : " + directionX);
				float directionY = touchEndPos.y - touchStartPos.y;//Debug.Log ("DirectionY : " + directionY);
				if(Mathf.Abs (directionY) < Mathf.Abs (directionX))
				{
					if(!iTweenMoving){
					if(0 < directionX){//Debug.Log ("Flick : Right");
						
						if(c > 0){
							c = c-1;
							Debug.Log (c);
							iTween.MoveBy(gameObject, right);
								iTweenMoving = true;
								//Invoke ("OnCompleteHandler", 1.0f);
							}
							direction = 6;
					}
					else{//Debug.Log ("Flick : Left");

						if(c <= 1){
							c = c+1;
							Debug.Log (c);
							iTween.MoveBy(gameObject, left);
								iTweenMoving = true;
								//Invoke ("OnCompleteHandler", 1.0f);
						}
						direction = 4;
					}
				}
				}
				else if(Mathf.Abs (directionX) < Mathf.Abs (directionY))
				{
					if(0 < directionY)//Debug.Log ("Flick : Up");
					{
						direction = 8;
					}
					else{//Debug.Log ("Flick : Down");
						/*Vector3 aTapPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					Collider2D aCollider2d = Physics2D.OverlapPoint (aTapPoint);
					if (aCollider2d) {
						GameObject obj = aCollider2d.transform.gameObject;
						Debug.Log (obj.name);
						PlayerPrefs.SetInt ("name",1);
					}
					FadeManager.Instance.LoadLevel("Main1",1.0f);*/
						direction = 2;

					}
				}
				else{//Debug.Log ("Flick : Not, It's Tap");

					FlickOff();
				}
			}
			else{//Debug.Log ("Long Touch");
				direction = 5;
			}
		}
	}
	public void FlickOff()
	{
		direction = 5;
		isFlick = false;
	}
	
	public bool IsFlick()
	{
		return isFlick;
	}
	
	
	public void ClickOn()
	{
		isClick = true;
		Invoke ("ClickOff" , 0.2f);
	}
	
	public bool IsClick()
	{
		return isClick;
	}
	
	public void ClickOff()
	{
		isClick = false;
	}
	// 処理が終わったら呼び出され、フラグをクリアする。
	void OnCompleteHandler(){
		iTweenMoving = false;
	}
	public void  RightButton(){
		if (c > 0) {
			iTweenMoving = true;
			c = Slide.c - 1;
			Debug.Log (c);
			iTween.MoveBy (gameobject, right);
			
		}
	}
	/*public void  Chara_c(){
		switch (c) {
		case 0:
			//Debug.Log ("pikaを押した");
			PlayerPrefs.SetInt ("name", 1);
			break;
		case 1:
			//Debug.Log ("p1を押した");
			PlayerPrefs.SetInt ("name", 2);
			break;
		case 2:
		//	Debug.Log ("numaを押した");
			PlayerPrefs.SetInt ("name", 3);
			break;
		}
	}*/
}