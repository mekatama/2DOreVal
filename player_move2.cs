using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move2 : MonoBehaviour{
	private Rigidbody2D rb2D;
	private float x_val;
	private float speed;
	public float inputSpeed;			//速度
	public float jumpPower;				//jump力
	public LayerMask CollisionLayer;	//レイヤー
	private bool isJump = false;		//jump flag

    void Start(){
		rb2D = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
	}

	//通常用
	void Update(){
		//左右キー入力
		x_val = Input.GetAxis("Horizontal");
		//接地状態確認
		isJump = IsCollision();
		//jumpキー入力(space)
		if(Input.GetKeyDown(KeyCode.Space) && isJump == true){
			jump();
		}
	}

	//物理演算用
	void FixedUpdate(){
		//無入力
		if(x_val == 0){
			speed = 0;
		}
		//右入力
		else if(x_val > 0){
			speed = inputSpeed;								//右速度
			transform.localScale = new Vector3(1, 1, 1);	//右向き
		}
		//左入力
		else{
			speed = inputSpeed * -1;						//左速度
			transform.localScale = new Vector3(-1, 1, 1);	//左向き
		}
		//実際に移動
		rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
	}

	//jump処理
	void jump(){
		rb2D.AddForce(Vector2.up * jumpPower);
		isJump = false;
	}

	//接地判定
	bool IsCollision(){
		//接地判定用ライン
		Vector3 left_SP = transform.position - Vector3.right * 0.3f;
		Vector3 right_SP = transform.position + Vector3.right * 0.3f;
		Vector3 EP = transform.position - Vector3.up * 0.1f;
		Debug.DrawLine(left_SP, EP, Color.red);
		Debug.DrawLine(right_SP, EP, Color.red);
		return Physics2D.Linecast(left_SP, EP, CollisionLayer) || Physics2D.Linecast(right_SP, EP, CollisionLayer);
	}
}
