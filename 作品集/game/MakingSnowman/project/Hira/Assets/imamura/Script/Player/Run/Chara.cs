//今村.
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Chara : MonoBehaviour {
	public Player Player;
	public AudioClip audioClip1,audioClip2,audioClip3,audioClip4,audioClip5;
	private AudioSource audioSource;
	private Rigidbody2D rb2D;
	private float jumpForce;
	private float jumpSize;
	static public int c,d,e,f,x;
	public GameObject gameover,dummy;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		jumpForce = 18.0f;
		jumpSize = 18.0f;
		x=0;
		c = 0;
		d = 0;
		e = 0;
		f = 0;
		rb2D = GetComponent<Rigidbody2D>();
		gameover = GameObject.Find ("GameOver");
		//gameover.SetActive (false);
		dummy = GameObject.Find ("Dummy");
		//dummy.SetActive (false);
	}
	
	void Update () {

		jumpSize = 18-(Player.player_x*Player.player_x);

		if(Input.GetMouseButtonDown(0)){
			OnDown();
		}
		if(Input.GetMouseButton(0)){//ボタンを押し続けてる間

		}
		if(d == 1){
			c++;
			if(c>=10){
//				dummy.SetActive(false);
				d = 0;
				c = 0;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Floor")
		{
			// ジャンプ回数をリセットする
			x = 0;
		}
		if (coll.gameObject.tag == "Enemy"){
//			dummy.SetActive(true);
			audioSource.clip = audioClip2;
			audioSource.Play ();
			Damage();

			if(RunCami.m_pos.z == 10 && RunSkirt.m_pos.z == 10 && RunBlouse.m_pos.z == 10 && RunShoes.m_pos.z == 10 &&
			   RunBodyScript.m_pos.z == 10 && RunHeadScript.m_pos.z == 10 && RunLegScript.m_pos.z == 10 && RunRightArmScript.m_pos.z == 10&& RunLeftArmScript.m_pos.z == 10)
			{
				audioSource.clip = audioClip4;
				audioSource.Play ();
				Countdown.x = 0;
				e = 1;
				gameover.SetActive (true);
				Sounds.x=1;
			}
		}
		if (coll.gameObject.tag == "Item")
		{
			audioSource.clip = audioClip1;
			audioSource.Play ();
		}
	}

	public void OnDown(){
		if (x <= 1) {
			Jump ();
			audioSource.clip = audioClip5;
			audioSource.Play ();
			x += 1;
		}
	}
	void Jump(){
		float jumpHeight = 2.0f;
		float gravity = Mathf.Abs(Physics.gravity.y);
		float velocity = Mathf.Sqrt(2 * gravity * jumpHeight);
		this.rb2D.velocity = Vector2.up * jumpSize;
	}
	void Damage(){
		d = 1;
	}

}
