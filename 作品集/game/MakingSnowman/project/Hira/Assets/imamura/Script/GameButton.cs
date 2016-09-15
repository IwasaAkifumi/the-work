//今村.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameButton : MonoBehaviour {
	public AudioClip audioClip;
	private AudioSource audioSource;
	static public GameObject myCube,obj1,obj2,obj3,obj4;
	static public int Head1,Body1,Leg1,Arm1;
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		myCube = GameObject.Find("hadaka");
		obj1 = GameObject.Find ("Head 1");
		obj2 = GameObject.Find ("Body 1");
		obj3 = GameObject.Find ("Leg 1");
		obj4 = GameObject.Find ("Arm 1");
		Head1=0;
		Body1=0;
		Leg1=0;
		Arm1=0;
		obj1.SetActive(false);
		obj2.SetActive(false);
		obj3.SetActive(false);
		obj4.SetActive(false);
	
	}

	void Update () {
		if (Head1 == 1) {
			obj1.SetActive (true);
		}else
			obj1.SetActive (false);
		if (Body1 == 1) {
			obj2.SetActive (true);
		}else
			obj2.SetActive(false);
		if (Leg1 == 1) {
			obj3.SetActive (true);
		}else
			obj3.SetActive(false);
		if (Arm1 == 1) {
			obj4.SetActive (true);
		}else
			obj4.SetActive(false);
	}
	public void Head(){
		if (Skill.skill >= 550 && Head1 == 0) {
			Skill.skill -= 550;
			Head1 = 1;
			audioSource.clip = audioClip;
			audioSource.Play ();
			RunScript.x = 1;
			CharaBackHadaka.x = 1;
			RunHair.m_pos.z = 10;
			RunHeadScript.m_pos.z = -4;
			CharaBackHead.m_pos.z = -3.5f;

			}
	}
	public void Body(){
		if (Skill.skill >= 2500 && Body1 == 0){
			Skill.skill -= 2500;
			Body1 = 1;
			audioSource.clip = audioClip;
			audioSource.Play ();
			RunScript.x = 1;
			CharaBackHadaka.x = 1;
			RunBodyScript.m_pos.z = -2;
			RunCami.m_pos.z = 10;
			RunSkirt.m_pos.z = 10;
			RunBlouse.m_pos.z = 10;
			CharaBackBody.m_pos.z = -2;
			CharaBackCami.m_pos.z = 10;
			CharaBackUnder.m_pos.z = 10;
			CharaBackSkirt.m_pos.z = 10;
			CharaBackBlouse.m_pos.z = 10;

		}
	}
	public void Leg(){
		if (Skill.skill >= 1840 && Leg1 == 0){
			Skill.skill -= 1840;
			Leg1 = 1;
			audioSource.clip = audioClip;
			audioSource.Play ();
			RunScript.x = 1;
			CharaBackHadaka.x = 1;
			RunLegScript.m_pos.z = -1;
			CharaBackLeg.m_pos.z = -4.5f;
			RunShoes.m_pos.z = 10;
			CharaBackShoes.m_pos.z = 10;

		}
	}
	public void Arm(){
		if (Skill.skill >= 1180 && Arm1 == 0){
			Skill.skill -= 1180;
			Arm1 = 1;
			audioSource.clip = audioClip;
			audioSource.Play ();
			RunScript.x = 1;
			CharaBackHadaka.x = 1;
			RunRightArmScript.m_pos.z = -5;
			RunLeftArmScript.m_pos.z = 0;
			CharaBackLeftArm.m_pos.z = -4;
			CharaBackRightArm.m_pos.z = -4;
			RunBlouse.m_pos.z = 10;
			CharaBackBlouse.m_pos.z = 10;

		}
	}
}
