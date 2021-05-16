using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_destroy : MonoBehaviour{
	public GameObject hitEffect;	//HitEffectアニメのプレハブを入れる用

	void Start(){
		//生成から5秒で削除
		Destroy(gameObject,2.0f);
	}

	//他のオブジェクトとの当たり判定(collision))
	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Ground"){
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
			Instantiate (hitEffect, transform.position, transform.rotation);
		};
		if(other.gameObject.tag == "Wall"){
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
			Instantiate (hitEffect, transform.position, transform.rotation);
		}
		if(other.gameObject.tag == "Enemy"){
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
			Instantiate (hitEffect, transform.position, transform.rotation);
		}
	}
}
