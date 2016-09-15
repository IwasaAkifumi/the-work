// アニメーションで使う変数たち
var animationInterval : float = 0.1; // 画像を切替えるタイミング
var animationTimer : float = 0.0; // 時間計測用
var animationFlag : boolean = true; // どっちの画像を表示するかのフラグ
function Start () {

}
function Update () {
    animationTimer -= Time.deltaTime;
    if (animationTimer < 0.0) {
        animationTimer = animationInterval;
        renderer.material.mainTextureOffset.x = animationFlag ? 0.5 : 0;
        animationFlag = !animationFlag;
    }
}