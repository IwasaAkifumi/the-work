//ゲームの基盤
#pragma strict
static var state : String;
private var score : int;
private var score2 : int;
static var time : float;
var labelStyle : GUIStyle;//スコアの文字スタイル
var labelStyleGameOver : GUIStyle;//ゲームオーバー文字のスタイル
var labelStyleGameClear : GUIStyle;//ゲームクリアの文字スタイル
var labelStyle1pwin : GUIStyle;//Player1 winの文字スタイル
var labelStyle2pwin : GUIStyle;//Player2 winの文字スタイル
var labelStyleScore : GUIStyle;//ステージモードのスコアの文字スタイル
var labelStyleScore1 : GUIStyle;//Player1のスコアの文字スタイル
var labelStyleScore2 : GUIStyle;//Player2のスコアの文字スタイル
var labelStyleTime : GUIStyle;//ステージモードのタイムの文字スタイル
var labelStylehighScore : GUIStyle;//ステージモードのハイスコアの文字スタイル
var labelStycounter : GUIStyle;//ステージモードとPlayer1のREADYSTATEの文字スタイル
var labelStycounter2 : GUIStyle;//Player2のREADYSTATEの文字スタイル
var labelStyleSkill : GUIStyle;//ステージモードのスキルの文字スタイル
var labelStyleSkill1 : GUIStyle;//player1のスキルの文字スタイル
var labelStyleSkill2 : GUIStyle;//player2のスキルの文字スタイル
var labelStyleTime2 : GUIStyle;//VSモードのタイムの文字スタイル
var counter : float = 0.0;
var counter2 : float = 0.0;
static var initial : float = 0.0;
static var high_Score: float[] = [ 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,0.0 ];
static var HighScore: String[] = [ "HighScore","HighScore2","HighScore3","HighScore4","HighScore5","HighScore6","HighScore7" ];

function Start () {
    Time.timeScale = 0;//初期はストップ状態
    state = "game state";
    if (Menu.i <= 5){//ステージモードの場合
        time = 60.0;
    }else {//VSモードの場合
        time = 300.0;
    }
    var i : int = 0;
    for(i = 0; i < 6; i++)
    if (PlayerPrefs.HasKey(HighScore[i])){//ハイスコアの初期設定
        high_Score[i] = PlayerPrefs.GetInt(HighScore[i]);
    }else {
        high_Score[i] = initial;
    }
 
}
function Update () {
    if (counter <=150)
        counter++;
    if (counter <=200)
        counter2++;
    if (counter >= 150)
        Time.timeScale = 1;//150fでスタート
    if (time > 0 && state != "game clear" && state != "game over" &&state != "1p win" && state != "2p win")
        time -= Time.deltaTime;//タイマーが減る
}
function TimeOver (){//タイムオーバー処理
    state = "game over";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("menu");
}

function GetScore (_score : int) {//スコア加算処理
    if (state != "game over") {
        score += _score;
    }
}
function GetScore2 (_score2 : int) {//Player2のスコア加算処理
    if (state != "game over") {
        score2 += _score2;
    }
}

function PlayerDead () {//ステージモードのゲームオーバー処理
    state = "game over";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("menu");
}
function EnemyDead () {//ステージモードのゲームクリア処理
    state = "game clear";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("menu");
}
function EnemyDead1 () {//Player1のボスを倒すと
    state = "1p win";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("title");
}
function EnemyDead2 () {//Player2のボスを倒すと
    state = "2p win";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("title");
}

 
function OnGUI() {
    var now : int = time;
    var rect_info : Rect = Rect(0, 0, Screen.width, Screen.height);//文字のデフォルト位置
    var rect_score2 : Rect = Rect(0, -50, Screen.width, Screen.height);//スコア文字のデフォルト位置
    var rect_highScore : Rect = Rect(0, 55, Screen.width, Screen.height);//ハイスコア文字のデフォルト位置
    var rect_score : Rect = Rect(0, 110, Screen.width, Screen.height);//スコア文字のデフォルト位置
    var rect_skill : Rect = Rect(0, 165, Screen.width, Screen.height);//スキル文字のデフォルト位置
    var rect_vs : Rect = Rect(0, 80, Screen.width, Screen.height);//VSモードのデフォルト位置
    
    if(Menu.i <= 5){
    if(high_Score[Menu.i] < score ){
    PlayerPrefs.SetInt(HighScore[Menu.i],score);
    high_Score[Menu.i] = score;//スコアを上書き
    }
    }
    if (Menu.i  <=5){ //ステージモードで表示される
        GUI.Label(rect_score, "SCORE:" + score.ToString(), labelStyle);
        GUI.Label(rect_info, "TIME:" + now.ToString(), labelStyleTime);
        GUI.Label(rect_highScore, "HIGHSCORE:" + high_Score[Menu.i], labelStylehighScore);
        GUI.Label(rect_skill, "SKILL:" + PlayerController.Skill, labelStyleSkill);
    }else{//VSモード画面に表示
        GUI.Label(rect_vs, "SKILL1P:" + PlayerController1.Skill1, labelStyleSkill1);
        GUI.Label(rect_vs, "SKILL2P:" + PlayerController2.Skill2, labelStyleSkill2);
        GUI.Label(rect_vs, "SCORE1P:" + score.ToString(), labelStyleScore1);
        GUI.Label(rect_vs, "SCORE2P:" + score2.ToString(), labelStyleScore2);
        GUI.Label(rect_info,now.ToString(), labelStyleTime2);
    }
    if(counter <= 100){//カウンターが100以下の間
        if (Menu.i <= 5){
            GUI.Label(rect_info, "READY", labelStycounter);
        }else{//VSモードの場合
            GUI.Label(rect_info, "READY", labelStycounter);//Player1の場所
            GUI.Label(rect_info, "READY", labelStycounter2);//Player2の場所
        }   
    }
    if(counter > 150 && counter2 <=200){//カウンターが150未満で200以下の場合
        if (Menu.i <= 5){
            GUI.Label(rect_info, "START", labelStycounter);
        }else{//VSモードの場合
            GUI.Label(rect_info, "START", labelStycounter);
            GUI.Label(rect_info, "START", labelStycounter2);
        }
    }
    if (state == "game over") //ステージモードでPlayerのHPが0になった場合
        GUI.Label(rect_info, "GAME OVER", labelStyleGameOver);
    if (state == "game clear")//ステージモードでボスを倒した場合
        GUI.Label(rect_info, "GAME CLEAR", labelStyleGameClear);//"GAME CLEAR"を表示
    if (state == "1p win")//Player1がボスを倒したら
        GUI.Label(rect_score2, "1P WIN", labelStyle1pwin);//"1P WIN"を表示
    if (state == "2p win")//Player2がボスを倒したら
        GUI.Label(rect_score2, "2P WIN", labelStyle2pwin);//"2P WIN"を表示
   
}


