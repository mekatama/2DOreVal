using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shot1 : MonoBehaviour{
	public GameObject[] bulletObject = null;	//弾のプレハブ 配列
	public GameObject effectObject = null;		//マズルエフェクトのプレハブ
	public Transform bulletStartPosition = null;//弾の発射位置
	private float timeElapsed = 0.0f;			//弾の連射間隔カウント用
	public float timeOut;						//連射間隔の時間
	public bool isShot;							//攻撃flag
	public int numShot;							//1setの攻撃数
	private int numShotCount;					//1setの攻撃数のカウント用
	public float stopTime;						//一時停止時間

	public GameObject objRollPoint;			//enemy_shot_roll.csをアッタチしているオブジェクト用
	private enemy_shot_roll scrShotRoll;	//enemy_shot_roll.csスクリプト入れる用
	public GameObject objRader;				//enemy_rader1.csをアッタチしているオブジェクト用
	private enemy_radar1 scrRader1;			//enemy_rader1.csスクリプト入れる用
	public GameObject objTop;				//enemy_parameter.csをアッタチしているオブジェクト用
	private enemy_parameter scrParameter;	//enemy_parameter.csスクリプト入れる用

	void Start(){
		scrShotRoll = objRollPoint.GetComponent<enemy_shot_roll>();
		scrRader1 = objRader.GetComponent<enemy_radar1>();
		scrParameter = objTop.GetComponent<enemy_parameter>();
		numShotCount = 0;	//初期化
	}

	void Update(){
		//Debug用flag
		if(isShot == true){
			//player発見したら
			if(scrRader1.isDiscovery == true){
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
			//弾を生成(int)scrParameter.moveStart
			GameObject shot = Instantiate(
						bulletObject[(int)scrParameter.bulletType],
						vecBulletPos,
						transform.rotation
						);
			//弾に向きを伝える
			if((int)scrParameter.bulletType == 0){
				//弾に	enemyの向きを伝える
				bullet_move_Enemy flag = shot.GetComponent<bullet_move_Enemy>();
				flag.bulletDirection = scrShotRoll.rollRotation;
			}else if((int)scrParameter.bulletType == 1){
				//弾に	enemyの向きを伝える
				bullet_move_Enemy1 flag = shot.GetComponent<bullet_move_Enemy1>();
				flag.bulletDirection = scrShotRoll.rollRotation;
			}

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