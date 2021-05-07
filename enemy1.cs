using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour{
	public int enemyHp;		//EnemyのHP
	private bool isDeth;	//死亡flag

    void Start(){
		isDeth = false;		//初期化
	}

	//他のオブジェクトとの当たり判定(trigger)
	void OnTriggerEnter2D( Collider2D other) {
		if(other.tag == "Bullet"){
			//ダメージ処理
			if(enemyHp > 0){
				enemyHp = enemyHp - 1;	//[仮]攻撃力をHPから引く
				if(enemyHp <= 0){
					enemyHp = 0;
				}
			}
			//死亡判定
			if(enemyHp == 0){
				if(isDeth == false){
					Destroy(gameObject);			//このGameObjectを削除
					isDeth = true;
				}
			}
		}
	}

}
