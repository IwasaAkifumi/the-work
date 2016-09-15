//(http://narudesign.com/devlog/unity-countdown-display/)から引用.
//今村.
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour
{

	[SerializeField]
	private Text _textCountdown;
	static public int x,y;
	[SerializeField]
	private Image _imageMask;
	[SerializeField]
	private Image _1;
	[SerializeField]
	private Image _2;
	[SerializeField]
	private Image _3;
	[SerializeField]
	private Image _Go;
	private GameObject _button;
	void Start()
	{
		x = 0;
		y = 0;
		_textCountdown.text = "";


	}
	
	void Update () {
		y++;
		if(y==10)
		StartCoroutine (CountdownCoroutine ());
	}
	
	IEnumerator CountdownCoroutine()
	{
		_3.gameObject.SetActive(true);
		yield return new WaitForSeconds(1.0f);

		_3.gameObject.SetActive(false);
		_2.gameObject.SetActive(true);
		yield return new WaitForSeconds(1.0f);

		_2.gameObject.SetActive(false);
		_1.gameObject.SetActive(true);
		yield return new WaitForSeconds(1.0f);

		_1.gameObject.SetActive(false);
		_Go.gameObject.SetActive(true);
		_imageMask.gameObject.SetActive(false);
		yield return new WaitForSeconds(1.0f);

		x = 1;
		_Go.gameObject.SetActive(false);

	}
}