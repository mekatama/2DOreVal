using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move2 : MonoBehaviour{
	private Rigidbody2D rb2D;
	private float x_val;
	private float speed;
	public float inputSpeed;				//速度
	public float jumpPower;					//jump力
	public LayerMask CollisionLayer;		//レイヤー
	public bool isGround = false;			//ground flag
	public float dashSpeed;					//dash速度
	public bool isDash;						//Dash時flag
	public AnimationCurve dashMoveCurve;	//dash中の左右移動用
	private float dashTimeElapsed = 0.0f;	//dash時間カウント用
	public float timeDash;					//dash時間
	private float dashTime;					//dashMoveCurve制御用

    void Start(){
		rb2D = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
	}

	//通常用
	void Update(){
		//左右キー入力
		x_val = Input.GetAxis("Horizontal");
		//接地状態確認
		isGround = IsCollision();
		//jumpキー入力(space)
		if(Input.GetKeyDown(KeyCode.Space) && isGround == true){
			jump();
		}
		//dash入力(左shift key)
		if(Input.GetKey(KeyCode.LeftShift) && isDash == false){
			if(isGround == true){
				isDash = true;
			}
		}
		//dash制限時間カウント
		if(isDash == true){
			dashTimeElapsed += Time.deltaTime;	//カウント
			if(dashTimeElapsed >= timeDash){
				dashTimeElapsed = 0.0f;		//初期化
				isDash = false;				//dashflag off	
			}
			//dash中にjumpしたら
			if(isGround == false){
				isDash = false;	//dash終了
			}
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
			if(isDash == true){
				dashTime += Time.deltaTime;		//dash時間のカウント
				speed = dashSpeed;				//右速度
			}else{
//				walkTime += Time.deltaTime;		//walk時間のカウント
				speed = inputSpeed;
			}
		}
		//左入力
		else{
			if(isDash == true){
				dashTime += Time.deltaTime;		//dash時間のカウント
				speed = dashSpeed * -1;			//左速度
			}else{
//				walkTime += Time.deltaTime;		//walk時間のカウント
				speed = inputSpeed * -1;
			}
		}
		//AnimationCurveを速度に反映
		if(isDash == true){
			//dash時
			speed *= dashMoveCurve.Evaluate(dashTime);
		}
		//実際に移動
		rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
	}

	//jump処理
	void jump(){
		rb2D.AddForce(Vector2.up * jumpPower);
		isGround = false;
	}

	//接地判定
	bool IsCollision(){
		//接地判定用ライン
		Vector3 left_SP = transform.position - Vector3.right * 0.2f;
		Vector3 right_SP = transform.position + Vector3.right * 0.2f;
		Vector3 EP = transform.position - Vector3.up * 0.1f;
		Debug.DrawLine(left_SP, EP, Color.red);
		Debug.DrawLine(right_SP, EP, Color.red);
		return Physics2D.Linecast(left_SP, EP, CollisionLayer) || Physics2D.Linecast(right_SP, EP, CollisionLayer);
	}
}