using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_move : MonoBehaviour{
	public float speed;				//移動速度
	private Rigidbody2D rb = null;	//Rigidbody2D入れる用

    void Start(){
		rb = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
	}

	//物理演算用
	void FixedUpdate(){
		//実際に移動
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}


    void Update(){
	}
}
