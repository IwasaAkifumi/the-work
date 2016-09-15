#pragma strict
var damp = 6.0;
var bullitPrefab : Transform;//弾のプレファブを設定
var savedTime = 100000;//弾の発射頻度
var score : int;
var explodePrefab : GameObject;
static var player : Transform;
var ItemPrefab : GameObject;

function Start () {

    player = GameObject.FindGameObjectWithTag("Player").transform;
    
}

function Update () {

    if (player == null) return;
    var playerPos : Vector3; 
    playerPos = player.position;
    var direction : Vector3;
    direction = playerPos - transform.position;
    transform.LookAt(playerPos);
    
     var seconds : int = Time.time;
        var oddeven = (seconds % 2);
            if(oddeven){
            Shoot(seconds);
        }
    
}

function Shoot(seconds){
    if(seconds != savedTime){
        var bullit = Instantiate(bullitPrefab, transform.transform.position,
                                Quaternion.identity);
        bullit.rigidbody.AddForce(transform.forward * 1000);
        //savedTime=seconds;
    }
}

function OnTriggerEnter (other : Collider) {
    if (other.gameObject.tag == "Player") {
        other.gameObject.SendMessage("ApplyDamage");
    } else if (other.gameObject.tag == "Bullet") {
        GameObject.FindWithTag("GameController").SendMessage("GetScore", score);
        Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));
        Enemys.enemys++;
        // プレハブからアイテムを生成
        Instantiate (ItemPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
     } else if (other.gameObject.tag == "Bullet2") {
        GameObject.FindWithTag("GameController").SendMessage("GetScore2", score);
        Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));
        Enemys.enemys2++;
        Instantiate (ItemPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    } else {
        Destroy(gameObject);
    }
}