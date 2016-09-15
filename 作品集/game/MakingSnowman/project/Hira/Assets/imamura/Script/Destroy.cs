//今村.
using UnityEngine;
using System.Collections;


public class Destroy : MonoBehaviour
{
	void OnAnimationFinish ()
	{
		Destroy (gameObject);
	}
}