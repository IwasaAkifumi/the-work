using UnityEngine;
using System.Collections;

public class MapCreate : MonoBehaviour {
	public	GameObject[]	prefab_BL;		// 床ブロック格納用のプレファブ配列
	private	GameObject[,]	map_BL;			// マップに配置したブロックの格納用
	private int				MAP_SIZE_X	= 50;	// マップ横幅のブロック数
	private int				MAP_SIZE_Z	= 50;	// マップ奥幅のブロック数
	private	Vector3			BL_SIZE		= new Vector3(40,4,40);		// ブロックのサイズ
	
	// ■■■■■■
	void Start () {
		beginning_BL_Arrangement();		// 初期ブロック配置
	}
	
	// ■■■初期ブロック配置■■■
	private void beginning_BL_Arrangement(){
		map_BL = new GameObject[MAP_SIZE_X , MAP_SIZE_Z];	// MAP_SIZE分の配列を作成.
		
		int n = 0;		// X列のブロックを順の配置するための変数
		int m = 0;		// Z列のブロックを順の配置するための変数
		
		for(int z=0 ; z< MAP_SIZE_Z ; z++){
			for(int x=0 ; x< MAP_SIZE_X ; x++){
				Vector3 block_pos = new Vector3( BL_SIZE.x * x , -BL_SIZE.y / 2 , BL_SIZE.z * z);	// ブロック位置の算出
				GameObject block = Instantiate(prefab_BL[n] , block_pos , Quaternion.identity) as GameObject;		// プレハブ作成
				
				map_BL[x,z] = block;						// 作成したブロックを、マップ配列に格納
				
				n = (n+1) % prefab_BL.Length;				// 次に作るブロックの番号
			}
			m = (m+1) % prefab_BL.Length;					// Z列の最初に来るブロックの番号
			n = m;
		}
	}
}