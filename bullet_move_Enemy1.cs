using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move_Enemy1 : MonoBehaviour{
	private Rigidbody2D rb2D;
	public float power;
	public int bulletDirection;		//弾の移動方向

	void Start(){
Debug.Log("bme1");
		//榴弾挙動
		rb2D = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
		Vector2 force_r = new Vector2(power, power);
		Vector2 force_l = new Vector2(power * -1, power);
		//攻撃方向
		if(bulletDirection == 6){
			rb2D.AddForce(force_r);
		}else{
			rb2D.AddForce(force_l);
		}
	}
}
