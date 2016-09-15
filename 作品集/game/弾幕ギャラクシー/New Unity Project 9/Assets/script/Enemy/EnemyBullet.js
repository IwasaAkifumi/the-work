function OnTriggerEnter (other : Collider)  {
    if (other.gameObject.tag == "Player") {
        other.gameObject.SendMessage("ApplyDamage");
        Destroy(gameObject);
    }
    if (other.gameObject.tag == "Player2") {
        other.gameObject.SendMessage("ApplyDamage");
        Destroy(gameObject);
    } else {
        Destroy(gameObject);
    }
}