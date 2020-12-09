using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_groundCheck : MonoBehaviour{
	private bool isGround = false;		//接地flag移動用
	private bool isGroundEnter;	//接地時
	private bool isGroundStay;	//接地中
	private bool isGroundExit;	//接地終了時

	//接地判定(ここが呼ばれた時に判定する)
	public bool IsGround(){
		if(isGroundEnter == true || isGroundStay == true){
			isGround = true;
		}
		if(isGroundExit == true){
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
