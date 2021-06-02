using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2_direction : MonoBehaviour{
	public bool isForward;	//前移動flag

	void Start(){
//		isForward = true;	//初期化
	}

	//他のオブジェクトとの当たり判定(trigger))
	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "MoveArea"){
			if(isForward == true){
				isForward = false;
			}else{
				isForward = true;
			}
		}
	}
/*
	//他のオブジェクトとの当たり判定(collision))
	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Wall"){
			if(isForward == true){
				isForward = false;
			}else{
				isForward = true;
			}
		}
	}
*/
}
