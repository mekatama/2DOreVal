using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item1 : MonoBehaviour{

	//他のオブジェクトとの当たり判定(trigger))
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			Destroy(gameObject);	//このGameObjectを［Hierrchy］ビューから削除する
		}
	}
}
