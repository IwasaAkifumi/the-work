//VSモードの敵の移動処理
#pragma strict
var interval : float = 1; // 敵の発生周期
var interval_add : float = 0.1; // 敵の発生周期をどのくらい狭めるか
var interval_addtime : float = 10.0; // 敵の発生周期を狭める時間
var enemyPrefab : GameObject;
var enemyPrefab2 : GameObject;
var enemyPrefab3 : GameObject;
var enemyPrefab4 : GameObject;
var enemyPrefab5 : GameObject;
var enemyPrefab6 : GameObject;
var enemyPrefab7 : GameObject;
private var timer : float;
private var i : float;
private var intervalTimer : float;
static var enemys : int;
static var enemys2 : int;


function Start () {

    timer = 0.0;
    intervalTimer = 0.0;
    enemys = 0;
    enemys2 = 0;
    i = 0;
    
}
function Update () {
    timer -= Time.deltaTime;
    if (timer < 0.0 && i<=5) {
        var position : Vector3 = this.transform.position;
        i++;
        timer = interval;
    }
    //横から敵が出現
    if (timer < 0.0 && i>=5 && i<=15) {
        // 敵を発生させる。
        Instantiate(enemyPrefab, position, transform.rotation);
        i++;
        timer = interval;
    }
        
    if (timer < 0.0 && i>=15 && i<=20) {
        i++;
        timer = interval;
    }
    
        timer -= Time.deltaTime;
    if (timer < 0.0 && i>=20 && i<=30) {
        // 敵を発生させる。
        Instantiate(enemyPrefab2, position, transform.rotation);
        i++;
        timer = interval;
    }
    if (timer < 0.0 && i>=30 && i<=35) {
        i++;
        timer = interval;
    }
        
    if (timer < 0.0 && i>=35 && i<=45) {
        // 敵を発生させる。
        Instantiate(enemyPrefab3, position, transform.rotation);
        i++;
        timer = interval;
    }
     if (timer < 0.0 && i>=45 && i<=50) {
        i++;
        timer = interval;
    }
        
     if (timer < 0.0 && i>=50 && i<=60) {
        // 敵を発生させる。
        Instantiate(enemyPrefab4, position, transform.rotation);
        i++;
        timer = interval;
    }
     if (timer < 0.0 && i>=60 && i<=65) {
        i++;
        timer = interval;
    }
        
     if (timer < 0.0 && i>=65 && i<=75) {
        // 敵を発生させる。
        Instantiate(enemyPrefab5, position, transform.rotation);
        i++;
        timer = interval;
    }
      if (timer < 0.0 && i>=75 && i<=80) {
        i++;
        timer = interval;
    }
        
      if (timer < 0.0 && i>=80 && i<=90) {
        // 敵を発生させる。
        Instantiate(enemyPrefab6, position, transform.rotation);
        i++;
        timer = interval;
    }
      if (timer < 0.0 && i>=90 && i<=95) {
        i++;
        timer = interval;
    }
        
      if (timer < 0.0 && i>=95 && i<=105) {
        // 敵を発生させる。
        Instantiate(enemyPrefab7, position, transform.rotation);
        i++;
        timer = interval;
    }
    
    
    
    
    
       if (timer < 0.0 && i>=105 && i<=110) {
        i++;
        timer = interval;
    }
       if (timer < 0.0 && i>=110 && i<=120) {
        // 敵を発生させる。
        Instantiate(enemyPrefab, position, transform.rotation);
        Instantiate(enemyPrefab4, position, transform.rotation);
        i++;
        timer = interval;
    }
          if (timer < 0.0 && i>=120 && i<=125) {
        i++;
        timer = interval;
    }
          if (timer < 0.0 && i>=125 && i<=135) {
        // 敵を発生させる。
        Instantiate(enemyPrefab2, position, transform.rotation);
        Instantiate(enemyPrefab5, position, transform.rotation);
        i++;
        timer = interval;
    }
          if (timer < 0.0 && i>=135 && i<=140) {
        i++;
        timer = interval;
    }
           if (timer < 0.0 && i>=140 && i<=150) {
        // 敵を発生させる。
        Instantiate(enemyPrefab3, position, transform.rotation);
        Instantiate(enemyPrefab6, position, transform.rotation);
        i++;
        timer = interval;
    }
              if (timer < 0.0 && i>=150 && i<=155) {
        i++;
        timer = interval;
    }
          if (timer < 0.0 && i>=155 && i<=165) {
        // 敵を発生させる。
        Instantiate(enemyPrefab4, position, transform.rotation);
        Instantiate(enemyPrefab5, position, transform.rotation);
        i++;
        timer = interval;
    }

    
    
    
      if (i==165) {
        i = 0;
        timer = interval;
    }
    
    
    
    // 時間が経つにつれ敵の出現間隔を狭めていく。
    intervalTimer += Time.deltaTime;
    if (intervalTimer > interval_addtime && interval > 0.1) {
        intervalTimer = 0.0;
        interval -= interval_add;
    }
}
