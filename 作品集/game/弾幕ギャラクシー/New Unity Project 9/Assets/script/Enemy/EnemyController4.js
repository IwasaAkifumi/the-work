public var speed : float = 3;
public var player : Transform;
var score : int;
var explodePrefab : GameObject;
var enemyBulletPrefab : GameObject;
var bulletTime : float = 0.0;
var bulletInterval : float = 1.0;

static var Enemylife : int;

function Start () {
	player = GameObject.FindGameObjectWithTag("Player").transform;
    Enemylife = 100;
}

function Update () {
    if (player == null) return;
    var playerPos : Vector3; 
    playerPos = player.position;
    var direction : Vector3;
    direction = playerPos - transform.position;
    transform.position = ( transform.position + ( direction.normalized * speed * Time.deltaTime));
    transform.LookAt(playerPos); 
    if (bulletTime > bulletInterval) {
        bulletTime = 0;
        var bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
        var bullet_velocity = bullet.transform.position;
    }
    bulletTime += Time.deltaTime;
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

