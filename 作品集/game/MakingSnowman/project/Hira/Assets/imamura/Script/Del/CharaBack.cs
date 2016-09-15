//今村.
using UnityEngine;
using System.Collections;

public class CharaBack : MonoBehaviour {
	SpriteRenderer MainSpriteRenderer;
	// publicで宣言し、inspectorで設定可能にする
	public Sprite c01Sprite;
	public Sprite c02Sprite;
	public Sprite c03Sprite;
	public Sprite c04Sprite;
	public Sprite c05Sprite;
	public Sprite c06Sprite;
	public Sprite c07Sprite;
	public Sprite c08Sprite;
	public Sprite c09Sprite;
	public Sprite c10Sprite;
	public Sprite c11Sprite;
	public Sprite c12Sprite;
	public Sprite c13Sprite;
	public Sprite c14Sprite;
	public Sprite c15Sprite;
	public Sprite c16Sprite;
	public Sprite c17Sprite;
	public Sprite c18Sprite;
	public Sprite c19Sprite;
	public Sprite c20Sprite;
	public Sprite c21Sprite;
	public Sprite c22Sprite;
	public Sprite c23Sprite;
	public Sprite c24Sprite;
	public Sprite c25Sprite;
	public Sprite c26Sprite;
	static public int x;
	// Use this for initialization
	void Start () {
		MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();	
		x = 0;
	}
	
	// Update is called once per frame
	void Update () {

		switch (x) {
		case 0:
			MainSpriteRenderer.sprite = c14Sprite;
			break;
		case 1:
			MainSpriteRenderer.sprite = c10Sprite;
			break;
		case 2:
			MainSpriteRenderer.sprite = c15Sprite;
			break;
		case 3:
			MainSpriteRenderer.sprite = c17Sprite;
			break;
		case 4:
			MainSpriteRenderer.sprite = c19Sprite;	
			break;
		case 5:
			MainSpriteRenderer.sprite = c02Sprite;	
			break;
		case 6:
			MainSpriteRenderer.sprite = c01Sprite;
			break;
		case 7:
			MainSpriteRenderer.sprite = c03Sprite;
			break;
		case 8:
			MainSpriteRenderer.sprite = c04Sprite;
			break;
		case 9:
			MainSpriteRenderer.sprite = c05Sprite;
			break;
		case 10:
			MainSpriteRenderer.sprite = c06Sprite;	
			break;
		case 11:
			MainSpriteRenderer.sprite = c07Sprite;	
			break;
		case 12:
			MainSpriteRenderer.sprite = c08Sprite;
			break;
		case 13:
			MainSpriteRenderer.sprite = c09Sprite;
			break;
		case 14:
			MainSpriteRenderer.sprite = c11Sprite;
			break;
		case 15:
			MainSpriteRenderer.sprite = c12Sprite;
			break;
		case 16:
			MainSpriteRenderer.sprite = c13Sprite;	
			break;
		case 17:
			MainSpriteRenderer.sprite = c16Sprite;	
			break;
		case 18:
			MainSpriteRenderer.sprite = c18Sprite;
			break;
		case 19:
			MainSpriteRenderer.sprite = c20Sprite;
			break;
		case 20:
			MainSpriteRenderer.sprite = c21Sprite;
			break;
		case 21:
			MainSpriteRenderer.sprite = c22Sprite;
			break;
		case 22:
			MainSpriteRenderer.sprite = c23Sprite;	
			break;
		case 23:
			MainSpriteRenderer.sprite = c24Sprite;	
			break;
		case 24:
			MainSpriteRenderer.sprite = c25Sprite;
			break;
		case 25:
			MainSpriteRenderer.sprite = c26Sprite;
			break;
		}
	}
}
