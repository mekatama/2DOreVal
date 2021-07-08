using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shot_roll : MonoBehaviour{
	public int rollRotation;	//弾の移動方向判定用の値

	void Start(){
		rollRotation = 6;	//初期化
	}

	void Update(){
		//キー入力判定
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 90f);
			rollRotation = 8; 
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, -90f); 
			rollRotation = 2; 
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 0); 
			rollRotation = 6; 
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 180f); 
			rollRotation = 4; 
		}
		if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 45f); 
			rollRotation = 9; 
		}
		if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 135f); 
			rollRotation = 7; 
		}
		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, -45f); 
			rollRotation = 3; 
		}
		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, -135f); 
			rollRotation = 1; 
		}
	}
}
