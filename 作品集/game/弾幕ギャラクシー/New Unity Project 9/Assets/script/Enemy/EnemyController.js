var enemyBulletPrefab : GameObject;
var bulletTime : float = 0.0;
var bulletInterval : float = 1.0;
var explodePrefab : GameObject;
var score : int; 
var LookAtTarget : Transform;//プレイヤーを設定
var damp = 6.0;
var savedTime : int = 0;//弾の発射頻度
static var Enemylife : int;
var shoot: int[] = [ 0, 1000, 5000, -40, -90, -140 ];
 

function Start () {

    Enemylife = 100;
}

function Update () {
if(Menu.i == 0){
transform.Rotate(0, 1000 * Time.deltaTime, 0);
    if (bulletTime > bulletInterval) {
        bulletTime = 0;
        var bullet = Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
        var bullet_velocity = bullet.transform.forward * 3000;
        bullet.rigidbody.AddForce(bullet_velocity);
    }
    }
if(Menu.i == 1 || Menu.i == 2 ){
        if(LookAtTarget){
        var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp);
        
        var seconds : int = Time.time;
        var oddeven = (seconds % 2);
        
        if(oddeven){
            Shoot(seconds);
        }
    }
    transform.LookAt(LookAtTarget);
}


    
   
    bulletTime += Time.deltaTime;
}


function Shoot(seconds){
    if(seconds != savedTime){
        var bullit = Instantiate(enemyBulletPrefab, transform.transform.position,
                                Quaternion.identity);
        bullit.rigidbody.AddForce(transform.forward * shoot[Menu.i]);
        if(Menu.i == 1)
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