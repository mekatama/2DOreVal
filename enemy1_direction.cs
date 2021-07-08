using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_direction : MonoBehaviour{
	public int isForward;	//向きflag(int)

	void Start(){
//		isForward = 4;		//初期化(左向き)
	}

	//他のオブジェクトとの当たり判定(trigger))
	void OnTriggerExit2D(Collider2D other) {
		//往復移動
		if(other.gameObject.tag == "MoveArea"){
			if(isForward == 6){
				isForward = 4;
			}else{
				isForward = 6;
			}
		}
	}
	//他のオブジェクトとの当たり判定(trigger))
	void OnTriggerEnter2D(Collider2D other) {
		//壁で反転
		if(other.gameObject.tag == "Wall"){
			if(isForward == 6){
				isForward = 4;
			}else{
				isForward = 6;
			}
		}
	}
}
