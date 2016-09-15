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


transform.Rotate(0, 25, 0);

    if (bulletTime > bulletInterval) {
    if(Enemylife != 0){
        bulletTime = 0;
        var bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
        var bullet_velocity = bullet.transform.forward * 1500;
        bullet.rigidbody.AddForce(bullet_velocity);
    }
    }
    bulletTime += Time.deltaTime;
    if(PlayerControllerSt6.life == 0){
    gameObject.layer = LayerMask.NameToLayer("Enemy");
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

