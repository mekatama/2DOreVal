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
	public AnimationCurve walkCurve;		//walk用
	public AnimationCurve jumpCurve;		//jump用
	private float walkTime;					//walkグラフ制御用
	private float beforeKey;				//入力方向save用

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
			walkTime += Time.deltaTime;	//walk時間のカウント
			xSpeed = speed;
		}
		//左入力
		else if(horizontalKey < 0){
			walkTime += Time.deltaTime;	//walk時間のカウント
			xSpeed = -speed;
		}
		//無入力
		else{
			walkTime = 0.0f;			//walk時間のリセット
			xSpeed = 0.0f;
		}

		//左右移動反転時のwalkTimeの処理
		//左入力から右入力に反転時
		if(horizontalKey > 0 && beforeKey < 0){
			walkTime = 0.0f;			//walk時間のリセット
		}
		//右入力から左入力に反転時
		else if(horizontalKey < 0 && beforeKey > 0){
			walkTime = 0.0f;			//walk時間のリセット
		}
		beforeKey = horizontalKey;	//入力方向save


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

		//AnimationCurveを速度に反映
		//walk時
		xSpeed *= walkCurve.Evaluate(walkTime);

		//実際に移動
		rb.velocity = new Vector2(xSpeed, ySpeed);
	}
}
