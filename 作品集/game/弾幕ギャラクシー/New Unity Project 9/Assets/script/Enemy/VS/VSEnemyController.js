//VSモードのPlayer1のボス
#pragma strict
var enemyBulletPrefab : GameObject;
var bulletTime : float = 0.0;
var bulletInterval : float = 1.0;
var explodePrefab : GameObject;
var score : int; 
static var Enemylife : int;

function Start () {
    Enemylife = 100;
}

function Update () {
    if (EnemyMove2.frame >= 500){//500fだけ前進する
        transform.Rotate(0, 700 * Time.deltaTime, 0);
    if (bulletTime > bulletInterval) {
        bulletTime = 0;
        var bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
        var bullet_velocity = bullet.transform.forward * 2000;
        bullet.rigidbody.AddForce(bullet_velocity);
        }
        bulletTime += Time.deltaTime;
    }
    if(VSEnemyController2.Enemylife2 <= 0){//Player2がボスを倒したら
        gameObject.layer = LayerMask.NameToLayer("Enemy");//ボスの攻撃が当たらなくなる
    }
}

function OnTriggerEnter (other : Collider) {
    if (other.gameObject.tag == "Player") { //ボスとPlayer1が接触したら
        other.gameObject.SendMessage("ApplyDamage");//Player1にダメージが入る
    } else if (other.gameObject.tag == "Bullet") {//ボスとPlayer1の弾が接触したら
        GameObject.FindWithTag("GameController").SendMessage("GetScore", score);//Player1にスコアが入る
        Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));//爆発エフェクト
        Enemylife = Enemylife-1;//ボスのHPが-1減る
    if(Enemylife == 0){//ボスのHPが0になると
        Destroy(gameObject);//ボスのオブジェクトを削除
        GameObject.FindWithTag("GameController").SendMessage("EnemyDead1");//Player1のwin文字
        }
    }else{
        Destroy(gameObject);
    }
}