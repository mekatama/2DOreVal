using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_direction : MonoBehaviour{
	public int isForward;	//向きflag(int)
	public bool isStop;		//砦用
	public GameObject objTop;				//enemy_parameter.csをアッタチしているオブジェクト用
	private enemy_parameter scrParameter;	//enemy_parameter.csスクリプト入れる用

	void Start(){
//		isForward = 4;		//初期化(左向き)
		scrParameter = objTop.GetComponent<enemy_parameter>();
	}

	//他のオブジェクトとの当たり判定(trigger))
	void OnTriggerExit2D(Collider2D other) {
		//round_trip専用
		if((int)scrParameter.moveType == 3){
			//往復移動
			if(other.gameObject.tag == "MoveArea"){
				if(isForward == 6){
					isForward = 4;
				}else{
					isForward = 6;
				}
			}
		}
		//pause_tride専用
		if((int)scrParameter.moveType == 4){
			//砦用の停止flag
			isStop = true;
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
	//enemy破壊時
 	void OnDestroy(){
		//flagリセット
		if(isStop == true){
			isStop = false;
		}
	}
}
