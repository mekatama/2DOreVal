using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animation : MonoBehaviour{
	private Vector3 velocity;	//判定用のベクトル入れる用
	private Animator animator;	//Animator入れる用

	void Start(){
		animator = GetComponent<Animator>();	//Animator取得
	}

	void Update(){
		velocity = new Vector3(0f,0f,Input.GetAxis("Horizontal"));
		//ベクトルが0.1以上の場合判定
		if(velocity.magnitude > 0.1){
			//walk motion
			animator.SetFloat("speed",velocity.magnitude);
			//入力方向を向く
//			transform.LookAt(transform.position + velocity);
		}else{
			//idol motion
			animator.SetFloat("speed",0f);
		}
	}
}
