using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hp : MonoBehaviour{
	public int playerHp;	//playerのHP
	private bool isDeth;	//死亡flag
	public GameObject particle_exp;	//爆発Particle
	public bool isMuteki;	//無敵flag

	void Start(){
		isMuteki = false;	//初期化
	}

	//他のオブジェクトとの当たり判定(collision))
	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Enemy"){
			//ダメージ処理
			if(playerHp > 0 && isMuteki == true){
				playerHp = playerHp - 1;	//[仮]攻撃力をHPから引く
				Debug.Log("HP = "+ playerHp);
				if(playerHp <= 0){
					playerHp = 0;
				}
			}
			//死亡判定
			if(playerHp == 0){
				if(isDeth == false){
					Destroy(gameObject);			//このGameObjectを削除
					//爆発effect
					Instantiate (particle_exp, transform.position, transform.rotation);
					isDeth = true;
				}
			}
		}
	}
}
