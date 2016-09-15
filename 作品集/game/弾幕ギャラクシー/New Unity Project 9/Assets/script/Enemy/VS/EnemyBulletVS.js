//VSのボスの弾
function OnTriggerEnter (other : Collider)  {
    if (other.gameObject.tag == "Player") {
        other.gameObject.SendMessage("ApplyDamage1");
        Destroy(gameObject);
    }
    if (other.gameObject.tag == "Player2") {
        other.gameObject.SendMessage("ApplyDamage2");
        Destroy(gameObject);
    } else {
        Destroy(gameObject);
    }
}