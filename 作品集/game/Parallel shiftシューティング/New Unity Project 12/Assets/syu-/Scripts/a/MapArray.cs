using UnityEngine;
using System.Collections;

// マップ配列を扱うクラス
public class MapArray{
	protected string			name;				// この配列の名前(オブジェクト名として使用)
	protected GameObject		folder;				// 作成したマップオブジェクトを入れるフォルダー
	protected GameObject[,]		arr;				// マップオブジェクト格納用の配列
	protected MapSize		size;				// マップサイズへの参照用変数
	protected MapAxis		axis;				// マップ座標への参照用変数
	
	protected int				SIGN;				// 符合用。
	
	// コンストラクタ
	public MapArray (string name, MapSize size, MapAxis axis){
		this.name	= name;											// このクラスの名前を設定
		this.folder = new GameObject (this.name + "_Folder");		// フォルダーオブジェクトを作成 (コンストラクタとして、オブジェクト名を渡す)
		this.arr	= new GameObject[size.getX (), size.getZ ()];	// マップサイズ分の配列を宣言
		this.size	= size;											// 引数で受け渡された変数を参照する様に設定。
		this.axis	= axis;											// 引数で受け渡された変数を参照する様に設定。
		
		this.SIGN	= 1;
	}
	
	// 位置座標Xを配列座標に変換して返す
	private int getArrayNum_X (int value){
		int ret = value % size.getX ();
		if (ret < 0) { ret += size.getX();	}
		return ret;
	}
	
	// 位置座標Zを配列座標に変換して返す
	private int getArrayNum_Z (int value){
		int ret = value % size.getZ();
		if (ret < 0) { ret += size.getZ();	}
		return ret;
	}
	
	// 指定された位置座標に指定オブジェクトを作成、配列に格納
	protected void cleateObject(GameObject prefab , MapAxis.Axis_XZ arg){ cleateObject(prefab , arg.x , arg.z); }
	protected void cleateObject(GameObject prefab , int x , int z){
		int arr_x = getArrayNum_X(x);		// 配列座標Xを取得
		int arr_z = getArrayNum_Z(z);		// 配列座標Zを取得
		
		if (arr [arr_x, arr_z] != null) { MonoBehaviour.Destroy (arr[arr_x, arr_z].gameObject); }	// 配列内にオブジェクトが格納されていたら、削除する
		
		Vector3 scale			= prefab.transform.localScale;										// 受け渡されたオブジェクトのサイズを格納 (以下の式を見易くする為)
		Vector3 pos				= new Vector3 (scale.x*x , SIGN*scale.y/2 , scale.z*z);				// 位置の算出
		GameObject obj			= GameObject.Instantiate (prefab, pos, Quaternion.identity) as GameObject;		// プレハブ作成
		obj.name				= name + "[" + arr_x + "," + arr_z + "]";		// 作成したオブジェクトの名前変更
		obj.transform.parent	= folder.transform;						// 作成したオブジェクトの親を、フォルダーにする
		arr[arr_x, arr_z]		= obj;									// 作成したオブジェクトを、配列に格納
	}
}

// マップ配列(床)を扱うクラス
public class MapArrayBlock : MapArray{
	private GameObject[] block;		// 床ブロックの参照用
	
	// コンストラクタ
	public MapArrayBlock (GameObject[] obj , string name , MapSize size , MapAxis axis) : base(name , size , axis){
		this.block = obj;		// 引数で受け渡された変数を参照する様に設定。
		this.SIGN = -1;			// 床側なので、符合をマイナスに。
	}
	
	// 指定座標の、床タイプ番号を返す (座標x+zをプレファブ数で割った余値を返す)
	private int getInt_BlockType(MapAxis.Axis_XZ arg){ return getInt_BlockType(arg.x, arg.z); }
	private int getInt_BlockType(int x, int z){
		if (block.Length != 0) {
			int ret = (x + z)% block.Length ;
			if(ret < 0){ ret += block.Length; }
			return ret;
		} else {
			return 0;		// 配列の中身が無い場合は、０を返す
		}
	}
	
	// スタート時のマップ(床)作成
	public void startMap_Create(){
		if(block.Length != 0){
			int n;	// 床タイプ番号
			for (int z=0 ; z< size.getZ() ; z++) {
				for (int x=0 ; x< size.getX() ; x++) {
					n = getInt_BlockType(x, z);				// 床タイプ番号を取得
					cleateObject(block [n], x, z);			// オブジェクト作成
				}
			}
		}else{
			return;		// 配列の中身が無い場合は、何もせず抜ける
		}
	}
	
	// マップ(床)の更新
	public void renewal(){
		renewal_Z();	// 行方向のマップ(床)更新
	}
	
	// 列方向のマップ(床)更新
	private void renewal_X(){
		if(axis.getDefferenceAxis().x != 0){		// 位置座標の差分Zが０で無いなら
			MapAxis.Axis_XZ posAxis;			// 位置座標の始点
			posAxis.x = (axis.getDefferenceAxis().x > 0) ? axis.getAxis_MapEndX() : axis.getAxis_MapStartX(); // 始点Xはマップ端　（現在位置±半マップサイズ）
			posAxis.z = axis.getAxis_MapStartZ();	// 始点Zはマップ端　（現在位置－半マップサイズ）
			
			if(block.Length != 0){
				int n;	// 床タイプ番号
				for (int z=0 ; z< size.getZ() ; z++) {
					n = getInt_BlockType(posAxis.x , z+posAxis.z);			// 床タイプ番号を取得
					cleateObject(block[n] , posAxis.x , z+posAxis.z);		// オブジェクト作成
				}
			}else{
				return;		// 配列の中身が無い場合は、何もせず抜ける
			}
		}
	}
	
	// 行方向のマップ(床)更新
	private void renewal_Z(){
		if(axis.getDefferenceAxis().z != 0){		// 位置座標の差分Zが０で無いなら
			MapAxis.Axis_XZ posAxis;			// 位置座標の始点
			posAxis.x = axis.getAxis_MapStartX();	// 始点Xはマップ端　（現在位置－半マップサイズ）
			posAxis.z = (axis.getDefferenceAxis().z > 0) ? axis.getAxis_MapEndZ() : axis.getAxis_MapStartZ(); // 始点Zはマップ端　（現在位置±半マップサイズ）
			
			if(block.Length != 0){
				int n;	// 床タイプ番号
				for (int x=0 ; x< size.getX() ; x++) {
					n = getInt_BlockType(x+posAxis.x , posAxis.z);			// 床タイプ番号を取得
					cleateObject(block[n] , x+posAxis.x , posAxis.z);		// オブジェクト作成
				}
			}else{
				return;		// 配列の中身が無い場合は、何もせず抜ける
			}
		}
	}
}

// マップ配列(地上)を扱うクラス
public class MapArrayFloor : MapArray{
	private GameObject[] wall;		// 壁オブジェクトの参照用
	
	// コンストラクタ
	public MapArrayFloor (string name, MapSize size, MapAxis axis) : base(name , size , axis){}
	
	// 壁オブジェクトのセット
	public void setWall(GameObject[] obj){ wall = obj; }
	
	// スタート時のマップ(地上)作成
	public void startMap_Create(){
		for (int z=0 ; z< size.getZ() ; z++) {
			cleateObject(wall[0], axis.getAxis_MapStartX(), z);					// 0列目に壁オブジェクト作成
			cleateObject(wall[0], axis.getAxis_MapEndX(), z);		// (マップサイズ－１)列目に壁オブジェクト作成
		}
	}
	// マップ(地上)の更新
	public void renewal(){
		renewal_wallZ();	// 行方向のマップ(壁)の更新
	}
	
	// 行方向のマップ(壁)更新
	private void renewal_wallZ(){
		if(axis.getDefferenceAxis().z != 0){		// 位置座標の差分Zが０で無いなら
			if(wall.Length != 0){
				int z = (axis.getDefferenceAxis().z > 0) ? axis.getAxis_MapEndZ() : axis.getAxis_MapStartZ(); // Zはマップ端　（現在位置±半マップサイズ）
				cleateObject(wall[0] , axis.getAxis_MapStartX() , z);		// オブジェクト作成
				cleateObject(wall[0] , axis.getAxis_MapEndX() , z);		// オブジェクト作成
			}else{
				return;		// 配列の中身が無い場合は、何もせず抜ける
			}
		}
	}
}
