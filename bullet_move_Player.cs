using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move_Player : MonoBehaviour{
	public float speed = 0.0f;	//弾の移動速度
	void Start(){
	}

	void Update(){
		//移動
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}
}
