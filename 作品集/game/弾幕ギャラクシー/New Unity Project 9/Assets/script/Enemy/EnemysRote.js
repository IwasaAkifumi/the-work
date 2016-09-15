#pragma strict
var enemyBulletPrefab : GameObject;
var bulletTime : float = 0.0;
var bulletInterval : float = 1.0;
var explodePrefab : GameObject;
var score : int; 

var ItemPrefab : GameObject;

function Start () {

}

function Update(){
 transform.Rotate(0, 500 * Time.deltaTime, 0);
    if (bulletTime > bulletInterval) {
        bulletTime = 0;
        var bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
        var bullet_velocity = bullet.transform.forward * 1000;
        bullet.rigidbody.AddForce(bullet_velocity);
    }
    bulletTime += Time.deltaTime;
}

function OnTriggerEnter (other : Collider) {
    if (other.gameObject.tag == "Player") {
        other.gameObject.SendMessage("ApplyDamage");
    }else if (other.gameObject.tag == "Player2") {
        other.gameObject.SendMessage("ApplyDamage");
    } else if (other.gameObject.tag == "Bullet") {
        GameObject.FindWithTag("GameController").SendMessage("GetScore", score);
        Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));
        Enemys.enemys++;
        // プレハブからインスタンスを生成
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