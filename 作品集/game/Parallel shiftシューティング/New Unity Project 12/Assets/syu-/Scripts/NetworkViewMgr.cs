using UnityEngine;
using System.Collections;

public class NetworkViewMgr : MonoBehaviour {
	public          string  connectionIP    = "10.130.141.14";
	public          int     portNumber      = 8080;
	public static   bool    Connected       { get{ return connected; } }

	//public GameObject objectPrefab;
	public GameObject lightPrefab;
	//public GameObject cubePrefab;
	//public GameObject enemyPrefab;
	//public GameObject bomPrefab;
	public GameObject object2Prefab;
	
	private static  bool    connected       = false;

	void Start () {
	}

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
	
	/*public void OnConnectedToServer() {
		CreatePlayer2();
	}
	
	public void OnServerInitialized() {
		CreatePlayer();
	}*/
	
	private void OnGUI()
	{
		// 接続済み
		if ( connected )
		{
			GUILayout.Label("Connections: " + Network.connections.Length.ToString());
			// 接続を切断する場合
			if ( GUILayout.Button("Disconnect") ) 
			{
				Network.Disconnect();
			}
		}
		else
		{
			// 画面の入力情報を取得する。
			connectionIP = GUILayout.TextField(connectionIP);
			int.TryParse(GUILayout.TextField(portNumber.ToString()), out portNumber);
			
			// Clientになる場合
			if ( GUILayout.Button("Connect") ) 
			{
				Network.Connect(connectionIP, portNumber);
			}
			
			// Serverになる場合
			if ( GUILayout.Button("Server") )
			{
				Network.InitializeServer(4, portNumber);
			}
		}
	}

	//サーバーが初期化されたとき、サーバー側で呼び出されます。
	void OnServerInitialized()
	{

		CreatePlayer();

		Debug.Log("Server initialized and ready");
		connected = true;
	}
	
	//サーバーに接続したとき、クライアント側で呼び出されます。
	void OnConnectedToServer()
	{
		CreatePlayer2();
		Debug.Log("Connected to server");
		connected = true;
	}
	
	// プレイヤーが接続されたとき、サーバー側で呼び出されます。
	void OnPlayerConnected(NetworkPlayer player) 
	{
		Debug.Log("Connected from " + player.ipAddress + ":" + player.port);
		connected = true;
	}
	
	//プレイヤーが切断されたとき、サーバー側で呼び出されます。
	void OnPlayerDisconnected(NetworkPlayer player) 
	{
		Debug.Log("Clean up after player " + player);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}
	
	//サーバーから切断したとき、クライアント側で呼び出されます。
	void OnDisconnectedFromServer(NetworkDisconnection info) {
		connected = false;
		if (Network.isServer)
		{   
			Debug.Log("Local server connection disconnected");
		}
		else if (info == NetworkDisconnection.LostConnection)
		{
			Debug.Log("Lost connection to the server");
		}
		else
		{
			Debug.Log("Successfully diconnected from the server");
		}
	}
	
	//サーバーの接続に失敗したとき、クライアント側で呼び出されます。
	void OnFailedToConnect(NetworkConnectionError error) 
	{
		Debug.Log("Could not connect to server: " + error);
	}
}