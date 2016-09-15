//VSモードのPlayer2のボス
#pragma strict
var enemyBulletPrefab : GameObject;
var bulletTime : float = 0.0;
var bulletInterval : float = 1.0;
var explodePrefab : GameObject;
var score : int; 
static var Enemylife2 : int;

function Start () {
    Enemylife2 = 100;
}

function Update () {
    if (EnemyMove2_2.frame2 >= 500){//500fだけ前進する
        transform.Rotate(0, 700 * Time.deltaTime, 0);
    if (bulletTime > bulletInterval) {
        bulletTime = 0;
        var bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
        var bullet_velocity = bullet.transform.forward * 2000;
        bullet.rigidbody.AddForce(bullet_velocity);
        }
        bulletTime += Time.deltaTime;
    }
    if(VSEnemyController.Enemylife <= 0){//Player1がボスを倒したら
        gameObject.layer = LayerMask.NameToLayer("Enemy");//ボスの攻撃が当たらなくなる
    }
}

function OnTriggerEnter (other : Collider) {
    if (other.gameObject.tag == "Player2") {//ボスとPlayer2が接触したら
        other.gameObject.SendMessage("ApplyDamage");//Player2にダメージが入る
    } else if (other.gameObject.tag == "Bullet2") {//ボスとPlayer1の弾が接触したら
        GameObject.FindWithTag("GameController").SendMessage("GetScore2", score);//Player1にスコアが入る
        Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));//爆発エフェクト
        Enemylife2 = Enemylife2-1;//ボスのHPが-1減る
    if(Enemylife2 == 0){//ボスのHPが0になると
        Destroy(gameObject);//ボスのオブジェクトを削除
        GameObject.FindWithTag("GameController").SendMessage("EnemyDead2");//Player2のwin文字
        }
    }else{
        Destroy(gameObject);
    }
}