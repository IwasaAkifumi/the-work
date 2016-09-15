#pragma strict
static var state : String;
private var score : int;
private var score2 : int;
static var time : float;
static var time2 : float;
var labelStyle : GUIStyle;
var labelStyleGameOver : GUIStyle;
var labelStyleGameClear : GUIStyle;
var labelStyle1pwin : GUIStyle;
var labelStyle2pwin : GUIStyle;
var labelStyleScore : GUIStyle;
var labelStyleScore1 : GUIStyle;
var labelStyleScore2 : GUIStyle;
var labelStyleTime : GUIStyle;
var labelStylehighScore : GUIStyle;
var labelStycounter : GUIStyle;
var labelStycounter2 : GUIStyle;
var labelStyleSkill : GUIStyle;
var labelStyleSkill1 : GUIStyle;
var labelStyleSkill2 : GUIStyle;
var labelStyleTime2 : GUIStyle;
var counter : float = 0.0;
var counter2 : float = 0.0;
static var highScore : int;
static var highScore2 : int;
static var highScore3 : int;
static var highScore4 : int;
static var highScore5 : int;
static var highScore6 : int;

function Start () {
Time.timeScale = 0;
state = "game state";
if(Menu.i <= 5){
time = 60.0;
}else {
time = 300.0;
}


if(PlayerPrefs.HasKey("HighScore")){
highScore = PlayerPrefs.GetInt("HighScore");
}else {
highScore = 0;
}

if(PlayerPrefs.HasKey("HighScore2")){
highScore2 = PlayerPrefs.GetInt("HighScore2");
}else {
highScore2 = 0;
}

if(PlayerPrefs.HasKey("HighScore3")){
highScore3 = PlayerPrefs.GetInt("HighScore3");
}else {
highScore3 = 0;
}

if(PlayerPrefs.HasKey("HighScore4")){
highScore4 = PlayerPrefs.GetInt("HighScore4");
}else {
highScore4 = 0;
}

if(PlayerPrefs.HasKey("HighScore5")){
highScore5 = PlayerPrefs.GetInt("HighScore5");
}else {
highScore5 = 0;
}

if(PlayerPrefs.HasKey("HighScore6")){
highScore6 = PlayerPrefs.GetInt("HighScore6");
}else{
highScore6 = 0;

}


}


function Update () {
if(counter <=150){
counter++;
}
if(counter <=200){
counter2++;
}
if(counter >= 150){
 Time.timeScale = 1;
 }

if(time > 0 && state != "game clear" && state != "game over" &&state != "1p win" && state != "2p win"){
time -= Time.deltaTime;
}
}


function TimeOver (){
    state = "game over";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("menu");
}

function GetScore (_score : int) {
    if (state != "game over") {
        score += _score;
    }
}
 function GetScore2 (_score2 : int) {
    if (state != "game over") {
        score2 += _score2;
    }
}

function PlayerDead () {
    state = "game over";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("menu");
}
function EnemyDead () {
    state = "game clear";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("menu");
}
//ＶＳクリア時
function EnemyDead1 () {
    state = "1p win";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("title");
}
function EnemyDead2 () {
    state = "2p win";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("title");
}
function EnemyEDead () {
    state = "game clear";
    yield WaitForSeconds(1.0);
    while (!Input.GetButtonDown("Jump")) yield;
    Application.LoadLevel("title");
}
 
function OnGUI() {
    var now : int = time;
    var rect_gameover : Rect = Rect(0, 0, Screen.width, Screen.height);
    var rect_gameclear : Rect = Rect(0, 0, Screen.width, Screen.height);
    var rect_score : Rect = Rect(0, -50, Screen.width, Screen.height);
    var rect_highScore : Rect = Rect(0, 55, Screen.width, Screen.height);
    var rect_info : Rect = Rect(0, 110, Screen.width, Screen.height);
    var rect_time : Rect = Rect(0, 0, Screen.width, Screen.height);
    var rect_counter : Rect = Rect(0, 0, Screen.width, Screen.height);
    var rect_counter2 : Rect = Rect(0, 0, Screen.width, Screen.height);
    var rect_skill : Rect = Rect(0, 165, Screen.width, Screen.height);
    var rect_vs : Rect = Rect(0, 80, Screen.width, Screen.height);
    
    if (state == "game over") {
        GUI.Label(rect_gameover, "GAME OVER", labelStyleGameOver);
          if(Menu.i == 0){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore, labelStylehighScore);
          }else if(Menu.i == 1){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore2, labelStylehighScore);
          }else if(Menu.i == 2){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore3, labelStylehighScore);
          }else if(Menu.i == 3){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore4, labelStylehighScore);
          }else if(Menu.i == 4){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore5, labelStylehighScore);
          }else if(Menu.i == 5){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore6, labelStylehighScore);
          }
          GUI.Label(rect_info, "SCORE:" + score.ToString(), labelStyle);
          GUI.Label(rect_time, "TIME:" + now.ToString(), labelStyleTime);
          GUI.Label(rect_skill, "SKILL:" + PlayerController.Skill, labelStyleSkill);
        
        } else if(state == "game clear"){
         GUI.Label(rect_gameclear, "GAME CLEAR", labelStyleGameClear);
          if(Menu.i == 0){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore, labelStylehighScore);
          }else if(Menu.i == 1){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore2, labelStylehighScore);
          }else if(Menu.i == 2){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore3, labelStylehighScore);
          }else if(Menu.i == 3){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore4, labelStylehighScore);
          }else if(Menu.i == 4){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore5, labelStylehighScore);
          }else if(Menu.i == 5){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore6, labelStylehighScore);
          }
          GUI.Label(rect_info, "SCORE:" + score.ToString(), labelStyle);
          GUI.Label(rect_time, "TIME:" + now.ToString(), labelStyleTime);
          GUI.Label(rect_skill, "SKILL:" + PlayerController.Skill, labelStyleSkill);
         
         } else if(state == "1p win"){
         GUI.Label(rect_info, "1P WIN", labelStyle1pwin);
         
         } else if(state == "2p win"){
         GUI.Label(rect_info, "2P WIN", labelStyle2pwin);
         
          } else if(Menu.i  <=5){
         
          GUI.Label(rect_info, "SCORE:" + score.ToString(), labelStyle);
          GUI.Label(rect_time, "TIME:" + now.ToString(), labelStyleTime);
          if(Menu.i == 0){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore, labelStylehighScore);
          }else if(Menu.i == 1){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore2, labelStylehighScore);
          }else if(Menu.i == 2){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore3, labelStylehighScore);
          }else if(Menu.i == 3){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore4, labelStylehighScore);
          }else if(Menu.i == 4){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore5, labelStylehighScore);
          }else if(Menu.i == 5){
          GUI.Label(rect_highScore, "HIGHSCORE:" + highScore6, labelStylehighScore);
          }
          
          if(Menu.i == 0 && highScore < score){
          PlayerPrefs.SetInt("HighScore",score);
          highScore = score;
          }
          if(Menu.i == 1 && highScore2 < score){
          PlayerPrefs.SetInt("HighScore2",score);
          highScore2 = score;
          }
          if(Menu.i == 2 && highScore3 < score){
          PlayerPrefs.SetInt("HighScore3",score);
          highScore3 = score;
          }
          if(Menu.i == 3 && highScore4 < score){
          PlayerPrefs.SetInt("HighScore4",score);
          highScore4 = score;
          }
          if(Menu.i == 4 && highScore5 < score){
          PlayerPrefs.SetInt("HighScore5",score);
          highScore5 = score;
          }
          if(Menu.i == 5 && highScore6 < score){
          PlayerPrefs.SetInt("HighScore6",score);
          highScore6 = score;
          }
           
            GUI.Label(rect_skill, "SKILL:" + PlayerController.Skill, labelStyleSkill);
          }else{
            GUI.Label(rect_vs, "SKILL1P:" + PlayerController1.Skill1, labelStyleSkill1);
            GUI.Label(rect_vs, "SKILL2P:" + PlayerController2.Skill2, labelStyleSkill2);
            GUI.Label(rect_vs, "SCORE1P:" + score.ToString(), labelStyleScore1);
            GUI.Label(rect_vs, "SCORE2P:" + score2.ToString(), labelStyleScore2);
            GUI.Label(rect_time,now.ToString(), labelStyleTime2);
          }
          if(counter <= 100){
          if(Menu.i <= 5){
          GUI.Label(rect_counter, "READY", labelStycounter);
          }else{
          GUI.Label(rect_counter, "READY", labelStycounter);
          GUI.Label(rect_counter, "READY", labelStycounter2);
          }
          
          }
          
          if(counter > 150 && counter2 <=200){
          if(Menu.i <= 5){
          GUI.Label(rect_counter, "START", labelStycounter);
          }else{
          GUI.Label(rect_counter, "START", labelStycounter);
          GUI.Label(rect_counter, "START", labelStycounter2);
          }
          
}
}


