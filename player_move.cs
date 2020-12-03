using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour{
	public float speed;				//速度
	private Rigidbody2D rb = null;

    void Start(){
		rb = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
	}

	//物理演算用
	void FixedUpdate(){
		float horizontalKey = Input.GetAxis("Horizontal");

		//右入力
		if(horizontalKey > 0){
			rb.velocity = new Vector2(speed, rb.velocity.y);
		}
		//左入力
		else if(horizontalKey < 0){
			rb.velocity = new Vector2(-speed, rb.velocity.y);
		}
		//無入力
		else{
			rb.velocity = Vector2.zero;
		}
	}
}
