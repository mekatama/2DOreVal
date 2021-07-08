using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shot_roll : MonoBehaviour{
	public int rollRotation;				//弾の移動方向判定用の値
	public GameObject objModel;				//enemy1_direction.csをアッタチしているオブジェクト用
	private enemy1_direction scrDirection;	//enemy1_direction.csスクリプト入れる用

	void Start(){
		scrDirection = objModel.GetComponent<enemy1_direction>();
	}

	void Update(){
		if(scrDirection.isForward == 6){
			//判定エリアを回転
			transform.rotation = Quaternion.Euler(0, 180f, 0); 
			//画面→方向
			rollRotation = 6;	//弾の移動方向判定用の値
		}else{
			//判定エリアを回転
			transform.rotation = Quaternion.Euler(0, 0, 0); 
			//画面←方向
			rollRotation = 4;	//弾の移動方向判定用の値
		}
	}
}
