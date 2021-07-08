using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_door1 : MonoBehaviour{
	private Animator animator;	//Animator入れる用
	private bool isOpen;		//flag
	public BoxCollider2D col2D;//BoxCollider2D入れる用

	void Start(){
		animator = GetComponent<Animator>();	//Animator取得
	}

	//他のオブジェクトとの当たり判定(trigger))
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			Debug.Log("open");
			//door制御
			if(isOpen == false){
				//open motion
				animator.SetBool("isOpen",true);
				//collider off
				col2D.enabled = false;
				isOpen = true;
			}
		}
	}
	//他のオブジェクトとの当たり判定(trigger))
	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			Debug.Log("close");
			//door制御
			if(isOpen == true){
				//close motion
				animator.SetBool("isOpen",false);
				//collider on
				col2D.enabled = true;
				isOpen = false;
			}
		}
	}
}
