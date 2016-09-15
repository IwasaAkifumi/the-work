var Time1:int;
function Update () {
Time1++;
if(Time1 == 400 )
Destroy(gameObject);
}

function OnTriggerEnter (other : Collider)  {
    if (other.gameObject.tag == "Player") {
        other.gameObject.SendMessage("ApplyDamage");
        Destroy(gameObject);
    } else {
        Destroy(gameObject);
    }
    
}