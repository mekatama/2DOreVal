using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shot_roll : MonoBehaviour{

	void Start(){
	}

	void Update(){
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
	}
}
