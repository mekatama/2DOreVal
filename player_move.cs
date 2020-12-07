using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour{
	public float speed;					//速度
	private Rigidbody2D rb = null;
	private bool isGround = false;		//接地flag移動用
	private bool isGroundEnter = false;	//接地時
	private bool isGroundStay = false;	//接地中
	private bool isGroundExit = false;	//接地終了時

    void Start(){
		rb = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
	}

	//物理演算用
	void FixedUpdate(){
		//接地判定確認
		isGround = IsGround();

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

	//接地判定
	private bool IsGround(){
		if(isGroundEnter = true || isGroundStay == true){
			isGround = true;
		}else if(isGroundExit == true){
			isGround = false;
		}
		//初期化
		isGroundEnter = false;
		isGroundStay = false;
		isGroundExit = false;
		//返り値設定
		return isGround;
	}
	
	//接地時
	private void OnTriggerEnter2D( Collider2D other) {
		if(other.tag == "Ground"){
			isGroundEnter = true;
		}
	}
	//接地中
	private void OnTriggerStay2D( Collider2D other) {
		if(other.tag == "Ground"){
			isGroundStay = true;
		}
	}
	//接地終了時
	private void OnTriggerExit2D( Collider2D other) {
		if(other.tag == "Ground"){
			isGroundExit = true;
		}
	}
}
