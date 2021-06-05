using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shot_roll : MonoBehaviour{
	private enemy1_direction childScript;	//enemy1_direction.csスクリプト入れる用
	public GameObject parent;				//enemy1_direction.csをアッタチしているオブジェクト用

	void Start(){
		childScript = parent.GetComponent<enemy1_direction>();
	}

	void Update(){
		if(childScript.isForward == true){
			//画面→方向
			transform.rotation = Quaternion.Euler(0, 0, 0); 
		}else{
			//画面←方向
			transform.rotation = Quaternion.Euler(0, 0, 180f); 
		}
/*
		//キー入力判定
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 90f); 
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, -90f); 
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 0); 
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 180f); 
		}
		if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 45f); 
		}
		if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, 135f); 
		}
		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, -45f); 
		}
		if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) {
			transform.rotation = Quaternion.Euler(0, 0, -135f); 
		}
*/
	}
}
