//ステージモードのPlayer処理
#pragma strict
var movingSpeed : float = 5.0;
private var controller : CharacterController;
private var velocity : Vector3;
 
var LookAtTarget : Transform;//プレイヤーを設定
var damp = 6.0;
var animationInterval : float = 0.1;
var animationTimer : float = 0.0;
var animationFlag : boolean = true;
var bulletPrefab : GameObject;
var bulletInterval : float = 0.2;//弾を撃つ間隔
var bulletEnable : boolean = true;
var bulletVelocity : float = 100;
var bulletTime : float = 0.0;
var explodePrefab : GameObject;
var shotSE : AudioClip;

static var life : int;//PlayerのHP設定;
static var p : int = 1;
static var damageTime : int;
static var frame : int;
static var Skill : int;
 
function Start () {
    controller = GetComponent(CharacterController);
    var y:float = Input.GetAxis("Vertical") * 0.1;
    life = 5;
    damageTime = 0;
    frame = 0;
    Skill = 0;
}
function Update () {
    transform.position.y=0;
    velocity = Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    if (Input.GetKey(KeyCode.Joystick1Button7)){//低速移動処理
        velocity *= movingSpeed/3;//今の移動速度を/3
    }else if(Input.GetKey(KeyCode.Joystick1Button5)){//超低速移動処理
        velocity *= movingSpeed/6;//今の移動速度を/6
    }else{
        velocity *= movingSpeed;//今の移動速度
    }
    controller.Move(velocity * Time.deltaTime);
 
    animationTimer -= Time.deltaTime;
    if (animationTimer < 0.0) {
        animationTimer = animationInterval;
        renderer.material.mainTextureOffset.x = animationFlag ? 0.5 : 0;
        animationFlag = !animationFlag;
        }
    if (GameController.time<=1){//タイムオーバー条件
        Destroy(gameObject);
        GameObject.FindWithTag("GameController").SendMessage("TimeOver");//タイムオーバー処理へ
    }
    if (Input.GetKey(KeyCode.Joystick1Button1) && bulletEnable && Skill < 10 && 
    p == 1 && GameController.state != "game clear" && damageTime <= 0) {//前方へ通常弾
        bulletEnable = false;
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var direction : Vector3 = Vector3(0,0,1);
        bullet.rigidbody.AddForce(direction * bulletVelocity, ForceMode.VelocityChange);
        var player : GameObject = GameObject.Find("player");
    	this.transform.LookAt(player.transform.position);
        audio.PlayOneShot(shotSE);
    }
    if (Input.GetKey(KeyCode.Joystick1Button1) && bulletEnable && Skill >= 10 && 
    p == 1 && GameController.state != "game clear" && damageTime <= 0) {//前方へ3way弾
        bulletEnable = false;
        var bullet6 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var bullet7 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var bullet8 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var direction5 : Vector3 = Vector3(0.1,0,1);
        var direction6 : Vector3 = Vector3(-0.1,0,1);
        bullet6.rigidbody.AddForce(direction * bulletVelocity, ForceMode.VelocityChange);
        bullet7.rigidbody.AddForce(direction5 * bulletVelocity, ForceMode.VelocityChange);
        bullet8.rigidbody.AddForce(direction6 * bulletVelocity, ForceMode.VelocityChange);
        audio.PlayOneShot(shotSE);
    }
    if (Input.GetKey(KeyCode.Joystick1Button2) && bulletEnable && 
    p == 1 && GameController.state != "game clear" && damageTime <= 0) {//ボス方向に弾
        bulletEnable = false;
        var bullet2 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var direction2 : Vector3 = Vector3(0,0,0.1);
        bullet2.rigidbody.AddForce(transform.forward * 10000);
        var player2 : GameObject = GameObject.Find("player");
    	this.transform.LookAt(player2.transform.position);
        audio.PlayOneShot(shotSE);
    } 
    if (Input.GetKey(KeyCode.Joystick1Button2) && bulletEnable && Skill >= 10 && 
    p == 1 && GameController.state != "game clear" && damageTime <= 0) {//ボス方向へ3way弾
        bulletEnable = false;
        var bullet3 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var bullet4 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var bullet5 = Instantiate(bulletPrefab, transform.position, transform.rotation);
        var direction3 : Vector3 = Vector3(0,0,1);
        var bullet_velocity1 = transform.forward * 10000;
        var bullet_velocity2 = transform.right * 1000;
        bullet3.rigidbody.AddForce(bullet_velocity1);
        bullet4.rigidbody.AddForce(bullet_velocity1+bullet_velocity2);
        bullet5.rigidbody.AddForce(bullet_velocity1-bullet_velocity2);
        var player3 : GameObject = GameObject.Find("player");
    	this.transform.LookAt(player3.transform.position);
        audio.PlayOneShot(shotSE);
    }
    bulletTime += Time.deltaTime;
    if (bulletTime > bulletInterval) {
        bulletTime = 0.0;
        bulletEnable = true;
    }
    if (LookAtTarget){//Playerがボスの方向へ向く処理
        var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp);
        var seconds : int = Time.time;
        var oddeven = (seconds % 2);
    }
    transform.LookAt(LookAtTarget);
    if (damageTime!=0)//ダメージを食らったら点滅しながら100ｆダメージを受けない
        damageTime--;
    if (damageTime==0)//100f後に当たり判定をもとに戻す
        gameObject.layer = LayerMask.NameToLayer("Player");
    frame++;
    if (frame / 3 % 2 == 0 && damageTime>0){//ダメージを受けた後点滅する
        renderer.enabled = false;
    }else{
        renderer.enabled = true;
    }
    if (GameController.state == "game clear"){//ゲームクリアしたら無敵状態
    gameObject.layer = LayerMask.NameToLayer("Damage");
    }
}
 
function ApplyDamage() {//Playerダメージ処理
    gameObject.layer = LayerMask.NameToLayer("Damage");//当たり判定をなくす
    Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));//爆破エフェクト
    if (damageTime==0){
        life = life-1;
	    damageTime = 100;
	}
    if (life == 0){//PlayerのHPが0になったら
        Destroy(gameObject);//オブジェクトを削除
        Instantiate(explodePrefab, transform.position, Quaternion.AngleAxis(90,Vector3.right));//爆破エフェクト
        GameObject.FindWithTag("GameController").SendMessage("PlayerDead");//ゲームオーバー処理へ
    }
}

