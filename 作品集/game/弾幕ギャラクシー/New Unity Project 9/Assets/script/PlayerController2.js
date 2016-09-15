#pragma strict
var movingSpeed : float = 5.0;
private var controller : CharacterController;
static var velocity2 : Vector3;
static var stop2 : String;
static var stop2_2 : String;

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
var bulletInterval2 : float = 0.2;
var bulletEnable : boolean = true;
var bulletEnable2 : boolean = true;
var bulletVelocity : float = 100;
var bulletTime : float = 0.0;
var bulletTime2 : float = 0.0;
var explodePrefab : GameObject;
var shotSE : AudioClip;
var skillSE : AudioClip;

static var life : int;
static var p : int;
static var damageTime : int = 0;
static var frame2 : int;
static var Skill2 : int;
static var s2 : int;
 
function Start () {
    controller = GetComponent(CharacterController);
    var y:float = Input.GetAxis("Vertical2") * 0.1;
    life = 100;
    damageTime = 0;
    frame2 = 0;
    Skill2 = 0;
    p = 2;
    Menu.i = 7;
    s2 = 0;
}
function Update () {
    s2--;
    transform.position.y=0;
    velocity2 = Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2"));
    if (Input.GetKey(KeyCode.Joystick2Button7)){
        velocity2 *= movingSpeed/3;
    }else if(Input.GetKey(KeyCode.Joystick1Button5)){
        velocity2 *= movingSpeed/6;
    }else{
        velocity2 *= movingSpeed;
    }
    controller.Move(velocity2 * Time.deltaTime);
 
    animationTimer -= Time.deltaTime;
    if (animationTimer < 0.0) {
        animationTimer = animationInterval;
        renderer.material.mainTextureOffset.x = animationFlag ? 0.51 : 0;
        animationFlag = !animationFlag;
    }
    if (Input.GetKey(KeyCode.Joystick2Button1) && bulletEnable && Skill2 < 10 && p == 2
    && GameController.state != "1p win" && damageTime <= 0 && PlayerController1.stop1 != "stop") {
        bulletEnable = false;
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var direction : Vector3 = Vector3(0,0,1);
        bullet.rigidbody.AddForce(direction * bulletVelocity, ForceMode.VelocityChange);
        var player : GameObject = GameObject.Find("player");
    	this.transform.LookAt(player.transform.position);
        audio.PlayOneShot(shotSE);
    }
    if (Input.GetKey(KeyCode.Joystick2Button1) && bulletEnable && Skill2 >= 10 && p == 2 
    && GameController.state != "1p win" && damageTime <= 0 && PlayerController1.stop1 != "stop") {
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
    if (Skill2 == 10){
        audio.PlayOneShot(skillSE);
        Skill2 += 1;
    }
    if (Input.GetKey(KeyCode.Joystick2Button2) && bulletEnable && Skill2 >= 10 && p == 2
    && GameController.state != "1p win" && damageTime <= 0 && PlayerController1.stop1 != "stop") {
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
        
        
        var player3 : GameObject = GameObject.Find("player2");
    	this.transform.LookAt(player3.transform.position);
        audio.PlayOneShot(shotSE);
    }
    if (Input.GetKey(KeyCode.Joystick2Button2) && bulletEnable && p == 2
    && GameController.state != "1p win" && damageTime <= 0 && PlayerController1.stop1 != "stop") {
        bulletEnable = false;
        var bullet2 = Instantiate(bulletPrefab2, transform.position, transform.rotation);
        var direction2 : Vector3 = Vector3(0,0,0.1);
        bullet2.rigidbody.AddForce(transform.forward * 10000);
        var player2 : GameObject = GameObject.Find("player");
    	this.transform.LookAt(player2.transform.position);
        audio.PlayOneShot(shotSE);
    }
        //★
    if (Input.GetKey(KeyCode.Joystick2Button0) && bulletEnable && Skill2 >= 10 && p == 2
    && GameController.state != "1p win" && damageTime <= 0) {
        bulletEnable = false;
        Skill2 -= 10;
        s2 = 300;
        stop2 = "stop";
        stop2_2 = "it";
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
    if (LookAtTarget){
        var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp);
        var seconds : int = Time.time;
        var oddeven = (seconds % 2); 
    }
    transform.LookAt(LookAtTarget);
    
    if (damageTime!=0)
        damageTime--;
    if (damageTime==0){//ダメージを食らったら点滅しながら100ｆダメージを受けない
        gameObject.layer = LayerMask.NameToLayer("Player");
    }
    frame2++;
    if (frame2 / 3 % 2 == 0 && damageTime>0){
        renderer.enabled = false;
    }else{
        renderer.enabled = true;
    }
    if (GameController.state == "1p win" || GameController.state == "2p win"){//ゲームクリアしたら無敵状態
        gameObject.layer = LayerMask.NameToLayer("Damage");
    }
    if (s2 <= 0){ //300f敵は弾を撃てない
        stop2 = "nostop";
    }
    if (PlayerController1.stop1 == "stop" && PlayerController1.stop1_1 == "it"){
        Instantiate(stopPrefab, transform.position, transform.rotation);
        PlayerController1.stop1_1 = "noit";
    }
}
function ApplyDamage() {
    gameObject.layer = LayerMask.NameToLayer("Damage");
    Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));
    damageTime = 100;
    life = life-1;
    if (life == 0){
        Destroy(gameObject);
        Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));
        GameObject.FindWithTag("GameController").SendMessage("PlayerDead");
    }
}