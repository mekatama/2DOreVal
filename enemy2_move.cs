using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2_move : MonoBehaviour{
	public float speed;				//移動速度
	private Rigidbody2D rb = null;	//Rigidbody2D入れる用
	private enemy1_direction childScript;	//enemy1_direction.csスクリプト入れる用
	private enemy1 childScript2;			//enemy1.csスクリプト入れる用
	private bool isMove = false;			//移動flag

    void Start(){
		rb = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
		childScript = GetComponentInChildren<enemy1_direction>();
		childScript2 = GetComponentInChildren<enemy1>();
	}

	void Update(){
		if(childScript2.isScreen == true && isMove == false){
			isMove = true;
		}
	}

	//物理演算用
	void FixedUpdate(){
		if(isMove == true){
			//実際に移動
			if(childScript.isForward == 1){
				//前進
				rb.velocity = new Vector2(speed, rb.velocity.y);
			}else{
				//後進
				rb.velocity = new Vector2(speed * -1, rb.velocity.y);
			}
		}
	}


}
