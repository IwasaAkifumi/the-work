#pragma strict
var movingSpeed : float = 5.0;
private var controller : CharacterController;
private var velocity : Vector3;
 
var animationInterval : float = 0.1;
var animationTimer : float = 0.0;
var animationFlag : boolean = true;
 
var bulletPrefab : GameObject;
var bulletInterval : float = 0.2;
var bulletEnable : boolean = true;
var bulletVelocity : float = 100;
var bulletTime : float = 0.0;

var target : GameObject; 
var my_gravity : float;
var g_angle : Vector3;

var moveing_Player = true;
 
var explodePrefab : GameObject;
 
var shotSE : AudioClip;

static var life : int;
static var damageTime : int = 0;
static var frame : int;
 
function Start () {
    controller = GetComponent(CharacterController);
    var y:float = Input.GetAxis("Vertical") * 0.1;
    life = 5;
    damageTime = 0;
    frame = 0;
}
function Update () {

    if(moveing_Player){
	g_angle = target.transform.position - transform.position; 
	rigidbody.AddForce(g_angle.normalized * my_gravity); 
	}
    transform.position.y=0;
    velocity = Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    if(Input.GetKey(KeyCode.Joystick1Button7)){
    velocity *= movingSpeed/3;
    }else if(Input.GetKey(KeyCode.Joystick1Button5)){
    velocity *= movingSpeed/6;
    }else{
    velocity *= movingSpeed;
    }
    controller.Move(velocity * Time.deltaTime);
 
    animationTimer -= Time.deltaTime;
    if (animationTimer < 0.0) {
        animationTimer = animationInterval;
        renderer.material.mainTextureOffset.x = animationFlag ? 0.51 : 0;
        animationFlag = !animationFlag;
        }
    if(GameController.time<=0){
        Destroy(gameObject);
        GameObject.FindWithTag("GameController").SendMessage("TimeOver");
    }
    
 
    if (Input.GetButton("Jump") && bulletEnable) {
        bulletEnable = false;
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var direction : Vector3 = Vector3(0,0,1);
        bullet.rigidbody.AddForce(direction * bulletVelocity, ForceMode.VelocityChange);
          var player : GameObject = GameObject.Find("player");
    	this.transform.LookAt(player.transform.position);
        audio.PlayOneShot(shotSE);
    }
    bulletTime += Time.deltaTime;
    if (bulletTime > bulletInterval) {
        bulletTime = 0.0;
        bulletEnable = true;
    }
    
    if(damageTime!=0)//ダメージを食らったら点滅しながら100ｆダメージを受けない
    damageTime--;
    if(damageTime==0){
    gameObject.layer = LayerMask.NameToLayer("Player");
    }
    frame++;
    if(frame / 3 % 2 == 0 && damageTime>0){
    renderer.enabled = false;
    }else{
    renderer.enabled = true;
    }
    
    if(GameController.state == "game clear"){//ゲームクリアしたら無敵状態
    gameObject.layer = LayerMask.NameToLayer("Damage");
}
}
 
function ApplyDamage() {
    gameObject.layer = LayerMask.NameToLayer("Damage");
    Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));
   
    if(damageTime==0){
    life = life-1;
	 damageTime = 100;}
    if(life == 0){
    Destroy(gameObject);
    Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));
    GameObject.FindWithTag("GameController").SendMessage("PlayerDead");
}
}