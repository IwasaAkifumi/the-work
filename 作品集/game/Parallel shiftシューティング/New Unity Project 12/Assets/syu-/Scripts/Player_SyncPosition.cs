using UnityEngine;
using UnityEngine.Networking;

public class Player_SyncPosition : NetworkBehaviour
{
	// SyncVar Attribute をつけたプロパティはネットワーク越しで共有される
	[SyncVar]
	private Vector3 syncPos;
	
	public float easing = 0.25f;
	
	// Unity Engine から呼ばれる関数（e.g. Start / OnCollisionEnter) に
	// ClientCallback Attribute をつけるとクライアント側だけで実行される（サーバ側は空実装）
	// 同様に ServerCallback Attribute もある
	[ClientCallback]
	void Update()
	{
		// サーバ側に現在位置を送信
		if (isLocalPlayer) {
			TransmitPosition();
		} else {
			LerpPosition();
		}
	}
	
	// Client Attribute をつけると Client のみ実行される（サーバでは空実装になる）
	// 同様に Server Attribute もある
	[Client]
	void TransmitPosition()
	{
		CmdProvidePositionToServer(transform.position);
	}
	
	// サーバ側で実行されるコマンド
	// クライアント側からサーバ側へコマンドを送る時はこれが必要
	// Command Attribute と Cmd-prefix な関数をセットで定義
	[Command]
	void CmdProvidePositionToServer(Vector3 pos)
	{
		syncPos = pos;
	}
	
	void LerpPosition()
	{
		transform.position = Vector3.Lerp(transform.position, syncPos, easing);
	}
}