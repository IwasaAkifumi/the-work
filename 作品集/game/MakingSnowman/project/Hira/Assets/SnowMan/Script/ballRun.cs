using UnityEngine;
using System.Collections;
 
public class ballRun : MonoBehaviour {
	private bool PRE = false;
	private bool PC = false;
	private bool NEW = true;
 
	private bool startFlag = false;
 
	// Label
	private GUIStyle labelStyle;
 
	public float xac = 0.0f;
	private float yac = 0.0f;
	private float zac = 0.0f;

	public float x_position = 0.0f;
 
	// initial
	void Awake(){
		// frame rate
		Application.targetFrameRate = 30;
	}
 
	// Use this for initialization
	void Start () {
		this.labelStyle = new GUIStyle();
		this.labelStyle.fontSize = Screen.height/30;
		this.labelStyle.normal.textColor = Color.white;
	}
 
	// Update is called once per frame
	void Update () {

			xac = 0.3f * xac + 0.3f * Input.acceleration.x;
			//yac = 0.1f * yac + 0.1f * Input.acceleration.y;
			//zac = 0.1f * zac + 0.1f * Input.acceleration.z;
			transform.position += new Vector3 (xac, zac, yac);

			x_position = x_position + xac;
		if (x_position < -4) {
			x_position = -4;
		}
		if (x_position >14) {
			x_position = 14;
		}
	}
 
	/*void OnGUI(){
		float x = Screen.width / 10;
		float y = 0;
		float w = Screen.width * 8 / 10;
		float h = Screen.height / 20;
 
		float xaccel = 0;
		float yaccel = 0;
		float zaccel = 0;
 
		for (int i = 0; i < 4; i++){
			y = Screen.height / 10 + h * i;
			string text = string.Empty;
			switch (i){
			case 0://X
				xaccel = 0.9f * xaccel + 0.1f * Input.acceleration.x;
				text = string.Format("X:{0}", System.Math.Round(xaccel, 2));
				break;
				case 1://Y
				yaccel = 0.9f * yaccel + 0.1f * Input.acceleration.y;
				text = string.Format("Y:{0}", System.Math.Round(yaccel, 2));
				break;
				case 2://Z
				zaccel = 0.9f * zaccel + 0.1f * Input.acceleration.z;
				text = string.Format("Z:{0}", System.Math.Round(zaccel, 2));
				break;
			case 3://Z
				zaccel = 0.9f * zaccel + 0.1f * Input.acceleration.z;
				text = string.Format("P:{0}", System.Math.Round(x_position, 2));
				break;
			default:
					throw new System.InvalidOperationException();
			}
			GUI.Label(new Rect(x, y, w, h), text, this.labelStyle);
		}
	}*/
}