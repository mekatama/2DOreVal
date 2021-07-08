using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shot : MonoBehaviour{
	public GameObject bulletObject = null;		//弾のプレハブ
	public GameObject effectObject = null;		//マズルエフェクトのプレハブ
	public Transform bulletStartPosition = null;//弾の発射位置
	private float timeElapsed = 0.0f;			//弾の連射間隔カウント用
	public float timeOut;						//連射間隔の時間
	public bool isShot;							//攻撃flag

	public GameObject objRollPoint;				//player_shot_roll.csをアッタチしているオブジェクト用
	private player_shot_roll scrShotRoll;		//player_shot_roll.csスクリプト入れる用

	void Start(){
		scrShotRoll = objRollPoint.GetComponent<player_shot_roll>();
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
			//弾に	playerの攻撃の向きを伝える
			bullet_move_Player num = shot.GetComponent<bullet_move_Player>();
			num.bulletDirection = scrShotRoll.rollRotation;

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