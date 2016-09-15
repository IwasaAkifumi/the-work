//メニュー画面	
#pragma strict
var state : boolean = true;
var state_i : boolean = false;
var labelStyleStage1 : GUIStyle;
var SE : AudioClip;
var SE2 : AudioClip;

static var i : int;//ステージ選択に使う変数
var playerIcon: int[] = [ 110, 60, 10, -40, -90, -140 ];//自機アイコンのz座標を入れる配列
var select: String[] = [ "Stage1", "Stage2", "Stage3", "Stage4", "Stage5", "Stage6" ];//各ステージが入る配列

function Start () {
    i = 0;
    var i : int = 0;
    for(i = 0; i < 6; i++)
    if (PlayerPrefs.HasKey(GameController.HighScore[i])){//ハイスコアの初期設定
        GameController.high_Score[i] = PlayerPrefs.GetInt(GameController.HighScore[i]);
    }else {
        GameController.high_Score[i] = GameController.initial;
    } 
}

function Update () {
    if (Input.GetAxis("axis3") == 1 && state == true && state_i != true) { // 下ボタンが押された(押され続けは検知されない)
        i = (i + 1)%6;
        audio.PlayOneShot(SE);
        state = false;
        Invoke( "Hoge", 0.2 );
        this.transform.position.z = playerIcon[i];//自機アイコンの座標位置
    }
    if (Input.GetAxis("axis3") == -1 && state == true && state_i != true) { // 上ボタンが押された(押され続けは検知されない) 
        i = (i + 5)%6;
        audio.PlayOneShot(SE);
        state = false;
        Invoke( "Hoge", 0.2 );
        this.transform.position.z = playerIcon[i];//自機アイコンの座標位置
    }
    if (Input.GetButtonDown("Jump")){//2ボタンを押すと
        state_i = true;//上下に自機アイコンが動かなくなる
        audio.PlayOneShot(SE2);//選択音がなる
      	Camera.main.SendMessage("fadeOut");//フェードアウトしながら
      	Invoke( "StageSelect", 2 );//選択したステージへ進む
    }
  	if (Input.GetKey(KeyCode.Joystick1Button2)) //3ボタンを押したらタイトルに戻る
  	     Application.LoadLevel("title");
}
function StageSelect() {
Application.LoadLevel(select[i]);
}
function Hoge() {//スムーズに上下選択できるように
state = true;
}

function OnGUI() {
    var rect_Stage : Rect = Rect(0, 0, Screen.width, Screen.height);
    GUI.Label(rect_Stage, "HIGH SCORE:" + GameController.high_Score[i], labelStyleStage1);
}






