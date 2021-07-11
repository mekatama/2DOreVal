using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_move : MonoBehaviour{
	[System.NonSerialized]
	public float speed;						//移動速度

	private Rigidbody2D rb = null;			//Rigidbody2D入れる用
	public GameObject objModel;				//enemy1_direction.csをアッタチしているオブジェクト用
	private enemy1_direction scrDirection;	//enemy1_direction.csスクリプト入れる用
	public GameObject objRader;				//enemy_rader1.csをアッタチしているオブジェクト用
	private enemy_radar1 scrRader1;			//enemy_rader1.csスクリプト入れる用
	public GameObject objTop;				//enemy_parameter.csをアッタチしているオブジェクト用
	private enemy_parameter scrParameter;	//enemy_parameter.csスクリプト入れる用

    void Start(){
		rb = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
		scrDirection = objModel.GetComponent<enemy1_direction>();
		scrRader1 = objRader.GetComponent<enemy_radar1>();
		scrParameter = objTop.GetComponent<enemy_parameter>();

		//初期移動方向判定
		if((int)scrParameter.moveStart == 0){	//left
			scrDirection.isForward = 4;
		}
		if((int)scrParameter.moveStart == 1){	//right
			scrDirection.isForward = 6;
		}
	}

	//物理演算用
	void FixedUpdate(){
		//前進するだけ
		if((int)scrParameter.moveType == 1){
			//実際に移動
			if(scrDirection.isForward == 4){
				//←移動
				rb.velocity = new Vector2(speed * -1, rb.velocity.y);
				//移動方向をenemy1_directionに渡す
				scrDirection.isForward = 4;
			}else{
				//→移動
				rb.velocity = new Vector2(speed, rb.velocity.y);
				//移動方向をenemy1_directionに渡す
				scrDirection.isForward = 6;
			}
		}
		//レーダー使用で前進
		if((int)scrParameter.moveType == 2){
			//player発見
			if(scrRader1.isDiscovery == true){
				//停止
				rb.velocity = Vector2.zero;
			}else{
				//実際に移動
				if(scrDirection.isForward == 4){
					//←移動
					rb.velocity = new Vector2(speed * -1, rb.velocity.y);
					//移動方向をenemy1_directionに渡す
					scrDirection.isForward = 4;
				}else{
					//→移動
					rb.velocity = new Vector2(speed, rb.velocity.y);
					//移動方向をenemy1_directionに渡す
					scrDirection.isForward = 6;
				}
			}
		}
		//エリア内を往復移動
		if((int)scrParameter.moveType == 3){
			if(scrDirection.isForward == 4){
				//←移動
				rb.velocity = new Vector2(speed * -1, rb.velocity.y);
				//移動方向をenemy1_directionに渡す
				scrDirection.isForward = 4;
			}else{
				//→移動
				rb.velocity = new Vector2(speed, rb.velocity.y);
				//移動方向をenemy1_directionに渡す
				scrDirection.isForward = 6;
			}
		}
	}
}
