using UnityEngine;
using System.Collections;

public class NewBehaviourScript1 : MonoBehaviour
{
	private Transform target;
	private Vector3 vec;
	private float speed = 0.07f;
	
	private void Start()
	{
		target = GameObject.Find("Player").transform;
	}
	
	private void Update()
	{
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.07f);
		transform.position += transform.forward * speed;
	}
	
	private void OnGUI()
	{
		GUILayout.BeginArea(new Rect(10, 10, 250, 300));
		GUILayout.BeginHorizontal();
		GUILayout.Label("X ");
		vec.x = GUILayout.HorizontalSlider(vec.x, -10f, 10f, GUILayout.Width(200));
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Y ");
		vec.y = GUILayout.HorizontalSlider(vec.y, -10f, 10f, GUILayout.Width(200));
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Z ");
		vec.z = GUILayout.HorizontalSlider(vec.z, -10f, 10f, GUILayout.Width(200));
		GUILayout.EndHorizontal();
		GUILayout.BeginHorizontal();
		GUILayout.Label("Speed ");
		speed = GUILayout.HorizontalSlider(speed, 0.0f, 0.3f, GUILayout.Width(200));
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		target.transform.position = vec;
	}
}