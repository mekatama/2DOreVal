using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour{
	public float speed;						//速度
	private Rigidbody2D rb = null;
	public player_groundCheck groundCheck;	//他のオブジェクトのスクリプト入れる用
	public float gravity;					//重力
	public float jumpSpeed;					//jump力
	private bool isGround = false;			//接地flag移動用
	private bool isJump = false;
	private float jumpPos = 0.0f;			//jump開始時のyを保存
	public float jumpHight;					//jumpする高さ

    void Start(){
		rb = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
	}

	//物理演算用
	void FixedUpdate(){
		//接地判定確認
		isGround = groundCheck.IsGround();	//groundCheckスクリプトにアクセス

		//キー入力
		float horizontalKey = Input.GetAxis("Horizontal");
		float xSpeed = 0.0f;		//初期化
		//重力発生
		float ySpeed = -gravity;	//下方向に力を発生

		//右入力
		if(horizontalKey > 0){
			xSpeed = speed;
		}
		//左入力
		else if(horizontalKey < 0){
			xSpeed = -speed;
		}
		//無入力
		else{
			xSpeed = 0.0f;
		}

		//jump入力
		if(isGround == true){	//接地時
			if(Input.GetKey(KeyCode.Space)){
				ySpeed = jumpSpeed;
				jumpPos = transform.position.y;	//jump開始時のy保存
				isJump = true;					//jump flag on
				Debug.Log(jumpPos);
			}else{
				isJump = false;	//jump flag off
			}
		}
		else if(isJump == true){	//接地してなくてjump中の時
			//キー入力中に、jumpしたい高さより低ければ
			if(Input.GetKey(KeyCode.Space) && (jumpPos + jumpHight > transform.position.y)){
				ySpeed = jumpSpeed;
			}else{
				isJump = false;	//jump flag off
			}
		}

		//実際に移動
		rb.velocity = new Vector2(xSpeed, ySpeed);
	}
}
