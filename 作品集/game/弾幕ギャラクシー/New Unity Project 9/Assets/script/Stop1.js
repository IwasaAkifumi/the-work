//Player1のVSモードのスキル
#pragma strict
var movingSpeed : float = 5.0;
private var controller : CharacterController;
private var velocity : Vector3;
static var stop : int;

function Start () {
    controller = GetComponent(CharacterController);
    var y:float = Input.GetAxis("Vertical") * 0.1;
    stop = 300;
}
function Update () {
    if(stop>=0)
    stop--;
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
    if(stop <= 0){
    Destroy(gameObject);
    }
    if(PlayerController1.frame1 / 3 % 2 == 0 && PlayerController1.damageTime>0){
    renderer.enabled = false;
    }else{
    renderer.enabled = true;
    }
    }
 