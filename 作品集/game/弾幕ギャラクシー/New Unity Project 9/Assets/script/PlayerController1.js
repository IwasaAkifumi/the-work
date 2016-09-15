//VSモードのPlayer1処理
#pragma strict
var movingSpeed : float = 5.0;
private var controller : CharacterController;
private var velocity : Vector3;
static var stop1 : String;
static var stop1_1 : String;

var LookAtTarget : Transform;//プレイヤーを設定
var damp = 6.0;
var animationInterval : float = 0.1;
var animationTimer : float = 0.0;
var animationFlag : boolean = true;
var bulletPrefab : GameObject;
var bulletPrefab2 : GameObject;
var bulletPrefab3 : GameObject;
var stopPrefab : GameObject;
var bulletInterval : float = 0.2;
var bulletInterval2 : float = 0.02;
var bulletEnable : boolean = true;
var bulletEnable2 : boolean = true;
var bulletVelocity : float = 100;
var bulletTime : float = 0.0;
var bulletTime2 : float = 0.0;
var explodePrefab : GameObject;
var shotSE : AudioClip;
var skillSE : AudioClip;
var itemSE : AudioClip;
var zero : float = 0.0;


static var life : int;
static var p : int;
static var damageTime : int = 0;
static var frame1 : int;
static var Skill1 : int;
static var s1 : int;
static var sk : int;
 
function Start () {
    controller = GetComponent(CharacterController);
    var y:float = Input.GetAxis("Vertical") * 0.1;
    life = 100;
    damageTime = 0;
    frame1 = 0;
    Skill1 = 0;
    p = 1;
    s1 = 0;
    Menu.i = 6;
    sk = 0;
}
function Update () {
    s1--;
    transform.position.y=0;
    velocity = Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    if (Input.GetKey(KeyCode.Joystick1Button7)){
        velocity *= movingSpeed/3;
    }else if (Input.GetKey(KeyCode.Joystick1Button5)){
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
    if (Input.GetKey(KeyCode.Joystick1Button1) && bulletEnable && Skill1 < 10 && p == 1 
    && GameController.state != "2p win" && damageTime <= 0 && PlayerController2.stop2 != "stop") {
        bulletEnable = false;
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var direction : Vector3 = Vector3(0,0,1);
        bullet.rigidbody.AddForce(direction * bulletVelocity, ForceMode.VelocityChange);
        var player : GameObject = GameObject.Find("player");
    	this.transform.LookAt(player.transform.position);
        audio.PlayOneShot(shotSE);
    }
        if (Input.GetKey(KeyCode.Joystick1Button1) && bulletEnable && Skill1 >= 10 && p == 1 
    && GameController.state != "2p win" && damageTime <= 0 && PlayerController2.stop2 != "stop") {
        bulletEnable = false;
        var bullet6 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var bullet7 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var bullet8 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var direction4 : Vector3 = Vector3(0,0,1);
        var direction5 : Vector3 = Vector3(0.1,0,1);
        var direction6 : Vector3 = Vector3(-0.1,0,1);
        bullet6.rigidbody.AddForce(direction4 * bulletVelocity, ForceMode.VelocityChange);
        bullet7.rigidbody.AddForce(direction5 * bulletVelocity, ForceMode.VelocityChange);
        bullet8.rigidbody.AddForce(direction6 * bulletVelocity, ForceMode.VelocityChange);
        audio.PlayOneShot(shotSE);
    }
    if (Input.GetKey(KeyCode.Joystick1Button2) && bulletEnable && Skill1 >= 10 && p == 1
    && GameController.state != "2p win" && damageTime <= 0 && PlayerController2.stop2 != "stop") {
        bulletEnable = false;
        var bullet3 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var direction3 : Vector3 = Vector3(0,0,1);
        var bullet_velocity1 = transform.forward * 10000;
        var bullet_velocity2 = transform.right * 1000;
        bullet3.rigidbody.AddForce(bullet_velocity1);
        
        var bullet4 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet4.rigidbody.AddForce(bullet_velocity1+bullet_velocity2);
        
        var bullet5 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet5.rigidbody.AddForce(bullet_velocity1-bullet_velocity2);
        
        audio.PlayOneShot(shotSE);
    }
    if (Skill1 == 10){
        audio.PlayOneShot(skillSE);
        Skill1 += 1;
    }
    if (sk < Skill1){
        audio.PlayOneShot(itemSE);
        sk = Skill1;
    }
    
    if (Input.GetKey(KeyCode.Joystick1Button2) && bulletEnable && p == 1
    && GameController.state != "2p win" && damageTime <= 0 && PlayerController2.stop2 != "stop") {
        bulletEnable = false;
        var bullet2 = Instantiate(bulletPrefab2, transform.position, transform.rotation);
        var direction2 : Vector3 = Vector3(0,0,0.1);
        bullet2.rigidbody.AddForce(transform.forward * 10000);
        var player2 : GameObject = GameObject.Find("player");
    	this.transform.LookAt(player2.transform.position);
        audio.PlayOneShot(shotSE);
    }
    
    //★
    if (Input.GetKey(KeyCode.Joystick1Button0) && bulletEnable2 && Skill1 >= 10 && p == 1 
    && GameController.state != "2p win" && damageTime <= 0) {
        bulletEnable2 = false;
        Skill1 -= 10;
        s1 = 300;
        stop1 = "stop";
        stop1_1 = "it";
        audio.PlayOneShot(shotSE);
    }
    bulletTime += Time.deltaTime;
    if (bulletTime > bulletInterval) {
        bulletTime = 0.0;
        bulletEnable = true;
    }
        bulletTime2 += Time.deltaTime;
    if (bulletTime2 > bulletInterval2) {
        bulletTime2 = 0.0;
        bulletEnable2 = true;
    }
        if(LookAtTarget){
        var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp);
        
        var seconds : int = Time.time;
        var oddeven = (seconds % 2);
        
        }
        
    
    transform.LookAt(LookAtTarget);



    if (damageTime!=0)
        damageTime--;
    if (damageTime==0)//ダメージを食らったら点滅しながら100ｆダメージを受けない
        gameObject.layer = LayerMask.NameToLayer("Player");
        frame1++;
    if (frame1 / 3 % 2 == 0 && damageTime>0){
        renderer.enabled = false;
    }else{
        renderer.enabled = true;
    }
    if (GameController.state == "2p win" || GameController.state == "1p win")//ゲームクリアしたら無敵状態
        gameObject.layer = LayerMask.NameToLayer("Damage");
    if (s1 <= 0)//300f敵は弾を撃てない
        stop1 = "nostop";
    if (PlayerController2.stop2 == "stop" && PlayerController2.stop2_2 == "it"){
        Instantiate(stopPrefab, transform.position, transform.rotation);
        PlayerController2.stop2_2 = "noit";
    }
    if (GameController.time<=1){
        Destroy(gameObject);
        GameObject.FindWithTag("GameController").SendMessage("TimeOver");
    }
}
 
function ApplyDamage() {
    gameObject.layer = LayerMask.NameToLayer("Damage");
    Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));
    damageTime = 100;
    life = life-1;
    if(life == 0){
    Destroy(gameObject);
    Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));
    GameObject.FindWithTag("GameController").SendMessage("PlayerDead");
}
}
