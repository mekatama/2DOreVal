using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_move : MonoBehaviour{
	public float speed;				//移動速度
	private Rigidbody2D rb = null;	//Rigidbody2D入れる用
	private enemy1_direction childScript;	//enemy1_direction.csスクリプト入れる用
	private enemy_radar1 childScript2;		//enemy_rader1.csスクリプト入れる用
	public GameObject child;				//enemy_rader1.csをアッタチしているオブジェクト用

    void Start(){
		rb = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
		childScript = GetComponentInChildren<enemy1_direction>();
		childScript2 = child.GetComponent<enemy_radar1>();
	}

	//物理演算用
	void FixedUpdate(){
		//player発見
		if(childScript2.isDiscovery == true){
			//停止
			rb.velocity = Vector2.zero;

		}else{
			//実際に移動
			if(childScript.isForward == true){
				//前進
				rb.velocity = new Vector2(speed, rb.velocity.y);
			}else{
				//後進
				rb.velocity = new Vector2(speed * -1, rb.velocity.y);
			}
		}
	}


    void Update(){
	}
}
