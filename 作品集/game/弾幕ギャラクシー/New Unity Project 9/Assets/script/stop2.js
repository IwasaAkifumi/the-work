//Player2のVSモードのスキル
#pragma strict
var movingSpeed : float = 5.0;
private var controller : CharacterController;
private var velocity2 : Vector3;
static var stop : int;

function Start () {
    controller = GetComponent(CharacterController);
    var y:float = Input.GetAxis("Vertical2") * 0.1;
    stop = 300;
}
function Update () {
    if(stop>=0)
    stop--;
    transform.position.y=0;
    velocity2 = Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2"));
    if(Input.GetKey(KeyCode.Joystick1Button7)){
    velocity2 *= movingSpeed/3;
    }else if(Input.GetKey(KeyCode.Joystick1Button5)){
    velocity2 *= movingSpeed/6;
    }else{
    velocity2 *= movingSpeed;
    } 
    controller.Move(velocity2 * Time.deltaTime);
    if(stop <= 0){
    Destroy(gameObject);
    }
    if(PlayerController2.frame2 / 3 % 2 == 0 && PlayerController2.damageTime>0){
    renderer.enabled = false;
    }else{
    renderer.enabled = true;
    }
    }