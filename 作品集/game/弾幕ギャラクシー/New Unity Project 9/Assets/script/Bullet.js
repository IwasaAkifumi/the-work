//弾処理
function OnTriggerEnter (collisionInfo : Collider) {
    if (collisionInfo.gameObject.tag == "Player") {
        // プレイヤーにダメージを与える
        collisionInfo.gameObject.SendMessage("ApplyDamage");
    } else if (collisionInfo.gameObject.tag == "Bullet") {
        Destroy(gameObject);
    } else {
        Destroy(gameObject);
    }
}