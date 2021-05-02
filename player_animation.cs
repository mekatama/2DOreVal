using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animation : MonoBehaviour{
	private Vector3 velocity;	//判定用のベクトル入れる用
	private Animator animator;	//Animator入れる用
	private player_groundCheck groundCheck;	//player_groundCheckを参照
	private player_move playerMove;			//player_moveを参照

	void Start(){
		animator = GetComponent<Animator>();	//Animator取得
		//子オブジェクトのplayer_groundCheck.cs参照
		groundCheck = GetComponentInChildren<player_groundCheck>();
		//同じオブジェクトのplayer_move.cs参照
		playerMove = GetComponent<player_move>();
	}

	void Update(){
		velocity = new Vector3(0f,0f,Input.GetAxis("Horizontal"));
		//ベクトルが0.1以上の場合判定
		if(velocity.magnitude > 0.1){
			//walk motion
			animator.SetFloat("speed",velocity.magnitude);
			//入力方向を向く
			transform.LookAt(transform.position + velocity);
		}else{
			//idol motion
			animator.SetFloat("speed",0f);
		}

		//jump motion制御
		if(groundCheck.isGround == false){
			//jump motion
			animator.SetBool("jump",true);
		}else{
			//idol motion
			animator.SetBool("jump",false);
		}

		//dash moyion制御
		if(playerMove.isDash == true){
			//dash motion
			animator.SetBool("dash",true);
		}else{
			//idol motion
			animator.SetBool("dash",false);
		}
	}
}
