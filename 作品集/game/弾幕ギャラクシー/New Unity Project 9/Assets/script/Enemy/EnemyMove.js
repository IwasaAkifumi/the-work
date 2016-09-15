#pragma strict
 var StartPos:Vector3;
 var EndPos:Vector3;
 var time:float;
 private var deltaPos:Vector3;
 private var elapsedTime:float;
 private var bStartToEnd:boolean = true;
 function Start () {
 transform.position = StartPos;
 deltaPos = (EndPos - StartPos) / time;
 elapsedTime = 0;
 }

 function Update () {
 transform.position += deltaPos * Time.deltaTime;
 elapsedTime += Time.deltaTime;
 if (elapsedTime > time)
 {
 if (bStartToEnd)
 {
 deltaPos = (StartPos - EndPos) / time;
 transform.position = EndPos;
 }
 else
 {
 deltaPos = (EndPos - StartPos) / time;
 transform.position = StartPos;
 }
 bStartToEnd = !bStartToEnd;
 elapsedTime = 0;
 }
 }
