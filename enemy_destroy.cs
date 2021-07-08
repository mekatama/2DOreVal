using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour{
	public bool isDestroy;	//消去flag

    void Update(){
		if(isDestroy == true){
			//子オブジェクトをを一つずつ取得
			foreach (Transform child in gameObject.transform){
				//削除する
				Destroy(child.gameObject);
			}
			//最後に親オブジェクトを削除する
			Destroy(gameObject);
		}
	}
}
