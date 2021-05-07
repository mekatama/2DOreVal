using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_destroy : MonoBehaviour{

	void Start(){
		//生成から5秒で削除
		Destroy(gameObject,2.0f);
	}

    void Update(){

	}

	//他のオブジェクトとの当たり判定(trigger)
	void OnTriggerEnter2D( Collider2D other) {
		if(other.tag == "Ground"){
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
		};
		if(other.tag == "Wall"){
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
		}
		if(other.tag == "Enemy"){
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
		}
	}
}
