#pragma strict
var LookAtTarget : Transform;//プレイヤーを設定
var damp = 6.0;
var bullitPrefab : Transform;//弾のプレファブを設定
var savedTime = 10;//弾の発射頻度
var score : int;
static var Enemylife : int;
var explodePrefab : GameObject;

function Start () {

    Enemylife = 100;
}

function Update(){
    if(LookAtTarget){
        var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp);
        
        var seconds : int = Time.time;
        var oddeven = (seconds % 1.1);
        
        if(oddeven){
            Shoot(seconds);
        }
    }
    transform.LookAt(LookAtTarget);
}

function Shoot(seconds){
    if(seconds != savedTime){
        var bullit = Instantiate(bullitPrefab, transform.transform.position,
                                Quaternion.identity);
        bullit.rigidbody.AddForce(transform.forward * 5000);
        savedTime=seconds;
    }
}

function OnTriggerEnter (other : Collider) {
    if (other.gameObject.tag == "Player") {
        other.gameObject.SendMessage("ApplyDamage");
    } else if (other.gameObject.tag == "Bullet") {
        GameObject.FindWithTag("GameController").SendMessage("GetScore", score);
        Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));
        Enemylife = Enemylife-1;
        if(Enemylife == 0){
        Destroy(gameObject);
        GameObject.FindWithTag("GameController").SendMessage("EnemyDead");
        }
    } else {
        Destroy(gameObject);
    }
}