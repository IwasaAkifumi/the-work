//新規
var enemyBulletPrefab : GameObject;
var bulletTime : float = 0.0;
var bulletInterval : float = 1.0;
var explodePrefab : GameObject;
var Time1:int;
var score : int; 
static var Enemylife : int;

function Start () {

    Enemylife = 1;
}

function Update () {
transform.Rotate(0, 1000 * Time.deltaTime, 0);
    if (bulletTime > bulletInterval) {
        bulletTime = 0;
        var bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
        var bullet_velocity = bullet.transform.forward * 1000;
        bullet.rigidbody.AddForce(bullet_velocity);
    }
    bulletTime += Time.deltaTime;
    Time1++;
	if(Time1 == 300 ) //300で6体目まで出現可能
	Destroy(gameObject);
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
        }
    } else {
        Destroy(gameObject);
    }
}