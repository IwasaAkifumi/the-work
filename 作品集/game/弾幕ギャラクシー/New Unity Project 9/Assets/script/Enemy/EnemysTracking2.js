#pragma strict
public var speed : float = 3;
static var player : Transform;
var score : int;
var explodePrefab : GameObject;
var ItemPrefab : GameObject;


function Start () {

}

function Update () {
player = GameObject.FindGameObjectWithTag("Player2").transform;
    if (player == null) return;
    var playerPos : Vector3; 
    playerPos = player.position;
    var direction : Vector3;
    direction = playerPos - transform.position;
    transform.position = ( transform.position + ( direction.normalized * speed * Time.deltaTime));
    transform.LookAt(playerPos); 
    
}

function OnTriggerEnter (other : Collider) {
    if (other.gameObject.tag == "Player") {
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