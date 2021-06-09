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
	public int numShot;							//1setの攻撃数
	private int numShotCount;					//1setの攻撃数のカウント用
	public float stopTime;						//一時停止時間

	public GameObject parent;				//enemy1_direction.csをアッタチしているオブジェクト用
	private enemy1_direction childScript;	//enemy1_direction.csスクリプト入れる用
	public GameObject parent2;				//enemy_rader1.csをアッタチしているオブジェクト用
	private enemy_radar1 childScript2;		//enemy_rader1.csスクリプト入れる用

	void Start(){
		childScript = parent.GetComponent<enemy1_direction>();
		childScript2 = parent2.GetComponent<enemy_radar1>();
		numShotCount = 0;	//初期化
	}

	void Update(){
		//Debug用flag
		if(isShot == true){
			//player発見したら
			if(childScript2.isDiscovery == true){
				//1set攻撃回数判定
				if(numShotCount < numShot){
					Shot();
				}else{
					Stop();
				}
			}
		}
	}

	void Stop(){
		timeElapsed += Time.deltaTime;	//カウント
		if(timeElapsed > stopTime){
			numShotCount = 0;
			timeElapsed = 0.0f;			//初期化
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
			//攻撃回数判定処理
			numShotCount += 1;
			timeElapsed = 0.0f;			//初期化
		}
	}
}