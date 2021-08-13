using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move_Enemy : MonoBehaviour{
	public float speed = 0.0f;	//弾の移動速度
	private Rigidbody2D rb2D;
	private int shot_x;
	private int shot_y;
	public int bulletDirection;		//弾の移動方向

	void Start(){
Debug.Log("bulletDirection:" + bulletDirection);
		rb2D = GetComponent<Rigidbody2D>();	//Rigidbody2D取得
		//方向を決める
		if(bulletDirection == 8){		//上
			shot_x = 0;
			shot_y = 1;
		}else if(bulletDirection == 2){	//下
			shot_x = 0;
			shot_y = -1;
		}else if(bulletDirection == 6){	//右
			shot_x = 1;
			shot_y = 0;
		}else if(bulletDirection == 4){	//左
			shot_x = -1;
			shot_y = 0;
		}else if(bulletDirection == 9){	//上右
			shot_x = 1;
			shot_y = 1;
		}else if(bulletDirection == 7){	//上左
			shot_x = -1;
			shot_y = 1;
		}else if(bulletDirection == 3){	//下右
			shot_x = 1;
			shot_y = -1;
		}else if(bulletDirection == 1){	//下左
			shot_x = -1;
			shot_y = -1;
		}else{
			//0になる時は左向き扱いにする
			shot_x = -1;
			shot_y = 0;
		}
	}

	//物理演算用
	void FixedUpdate(){
		rb2D.velocity = new Vector2(speed * shot_x, speed * shot_y);
	}
}
