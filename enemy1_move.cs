using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_move : MonoBehaviour{
	public float speed;				//移動速度
	private Rigidbody2D rb = null;	//Rigidbody2D入れる用

	public GameObject objModel;				//enemy1_direction.csをアッタチしているオブジェクト用
	private enemy1_direction scrDirection;	//enemy1_direction.csスクリプト入れる用
	public GameObject objRader;				//enemy_rader1.csをアッタチしているオブジェクト用
	private enemy_radar1 scrRader1;			//enemy_rader1.csスクリプト入れる用

	//動き種類select
	public enum MoveType{
		stop = 0,
		advance = 1,
		pause = 2
	}
	public MoveType moveType;

    void Start(){
		rb = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
		scrDirection = objModel.GetComponent<enemy1_direction>();
		scrRader1 = objRader.GetComponent<enemy_radar1>();
	}

	//物理演算用
	void FixedUpdate(){
		//前進するだけ
		if((int)moveType == 1){
			//実際に移動
			if(scrDirection.isForward == true){
				//前進
				rb.velocity = new Vector2(speed, rb.velocity.y);
			}else{
				//後進
				rb.velocity = new Vector2(speed * -1, rb.velocity.y);
			}
		}
		//レーダー使用で前進
		if((int)moveType == 2){
			//player発見
			if(scrRader1.isDiscovery == true){
				//停止
				rb.velocity = Vector2.zero;
			}else{
				//実際に移動
				if(scrDirection.isForward == true){
					//前進
					rb.velocity = new Vector2(speed, rb.velocity.y);
				}else{
					//後進
					rb.velocity = new Vector2(speed * -1, rb.velocity.y);
				}
			}
		}
	}
}
