using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public GameObject objectPrefab;
	public GameObject lightPrefab;
	public GameObject cubePrefab;
	public GameObject enemyPrefab;
	public GameObject bomPrefab;
	public GameObject object2Prefab;

	string ip      = "10.130.141.14";
	string port    = "8080";
	bool connected = false;
	
	private void CreatePlayer() {
		/*connected = true;
		Network.Instantiate (objectPrefab, objectPrefab.transform.position, objectPrefab.transform.rotation, 1);
		Network.Instantiate (lightPrefab, lightPrefab.transform.position, lightPrefab.transform.rotation, 1);
		Network.Instantiate (cubePrefab, cubePrefab.transform.position, cubePrefab.transform.rotation, 1);
		Network.Instantiate (enemyPrefab, enemyPrefab.transform.position, enemyPrefab.transform.rotation, 1);
		Network.Instantiate (bomPrefab, bomPrefab.transform.position, bomPrefab.transform.rotation, 1);*/
		connected = true;
		int positionNo = Random.Range(0, transform.childCount);
		Transform childTransform = transform.GetChild(positionNo).transform;
		Network.Instantiate(lightPrefab, childTransform.position, childTransform.rotation, 1);

	}
	private void CreatePlayer2() {
		connected = true;
		Network.Instantiate (object2Prefab, object2Prefab.transform.position, object2Prefab.transform.rotation, 1);

		
	}
	
	public void OnConnectedToServer() {
		CreatePlayer2();
	}
	
	public void OnServerInitialized() {
		CreatePlayer();
	}
	
	public void OnGUI() {
		if (!connected) {
			if (GUI.Button(new Rect(10, 10, 200, 200), "Client")) {
				Network.Connect(ip, int.Parse(port));
			}
			if (GUI.Button(new Rect(10, 210, 200, 200), "Master")) {
				Network.InitializeServer(10, int.Parse(port), false);
			}
		}
	}
}