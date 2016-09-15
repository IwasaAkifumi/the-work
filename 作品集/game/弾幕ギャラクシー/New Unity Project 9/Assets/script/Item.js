//アイテム処理
#pragma strict 
var score : int;
var itemSE : AudioClip;

function Update () {
transform.Translate(0,0,-0.5);
}
function OnTriggerEnter (other : Collider) {
    if (other.gameObject.tag == "Player") {
    Destroy(gameObject);
        PlayerController.Skill++;
        PlayerController1.Skill1++;
        GameObject.FindWithTag("GameController").SendMessage("GetScore", score);
        
        Destroy(gameObject);
        }
        if(other.gameObject.tag == "Player2"){
        PlayerController2.Skill2++;
        GameObject.FindWithTag("GameController").SendMessage("GetScore2", score);
        Destroy(gameObject);
        }
}