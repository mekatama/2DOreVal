using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shot1 : MonoBehaviour{
	public GameObject bulletObject = null;		//弾のプレハブ
	public GameObject effectObject = null;		//マズルエフェクトのプレハブ
	public Transform bulletStartPosition = null;//弾の発射位置
	private float timeElapsed = 0.0f;			//弾の連射間隔カウント用
	public float timeOut;						//連射間隔の時間
	public bool isShot;							//攻撃flag

	public GameObject parent;				//enemy1_direction.csをアッタチしているオブジェクト用
	private enemy1_direction childScript;	//enemy1_direction.csスクリプト入れる用

	void Start(){
		childScript = parent.GetComponent<enemy1_direction>();
	}

	void Update(){
		if(isShot == true){
			Shot();
		}
	}

	void Shot(){
		timeOut = 0.4f;					//連射間隔設定
		timeElapsed += Time.deltaTime;	//カウント
		if(timeElapsed >= timeOut){
			//弾の生成位置を指定
			Vector3 vecBulletPos = bulletStartPosition.position;
			//弾を生成
			GameObject shot = Instantiate(
						bulletObject,
						vecBulletPos,
						transform.rotation
						);
			//弾に	enemyの向きを伝える
			bullet_move_Enemy1 flag = shot.GetComponent<bullet_move_Enemy1>();
			flag.isRight = childScript.isForward;

			//マズルエフェクトを生成
			Instantiate(
						effectObject,
						vecBulletPos,
						transform.rotation
						);
			timeElapsed = 0.0f;			//初期化
		}
	}
}