using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shot1 : MonoBehaviour{
	[System.NonSerialized]
	public float timeOut;						//連射間隔の時間
	[System.NonSerialized]
	public int numShot;							//1setの攻撃数
	[System.NonSerialized]
	public float stopTime;						//一時停止時間
	[System.NonSerialized]
	public bool isRadar;						//レーダー使用flag

	public GameObject[] bulletObject = null;	//弾のプレハブ 配列
	public GameObject effectObject = null;		//マズルエフェクトのプレハブ
	public Transform bulletStartPosition = null;//弾の発射位置
	private float timeElapsed = 0.0f;			//弾の連射間隔カウント用
	public bool isShot;							//攻撃flag
	private int numShotCount;					//1setの攻撃数のカウント用
	private int tempBulletType;					//攻撃方法代入用

	public GameObject objRollPoint;			//enemy_shot_roll.csをアッタチしているオブジェクト用
	private enemy_shot_roll scrShotRoll;	//enemy_shot_roll.csスクリプト入れる用
	public GameObject objRader;				//enemy_rader1.csをアッタチしているオブジェクト用
	private enemy_radar1 scrRader1;			//enemy_rader1.csスクリプト入れる用
	public GameObject objRader2;			//enemy_rader2.csをアッタチしているオブジェクト用
	private enemy_radar2 scrRader2;			//enemy_rader2.csスクリプト入れる用
	public GameObject objTop;				//enemy_parameter.csをアッタチしているオブジェクト用
	private enemy_parameter scrParameter;	//enemy_parameter.csスクリプト入れる用

	void Start(){
		scrShotRoll = objRollPoint.GetComponent<enemy_shot_roll>();
		scrRader1 = objRader.GetComponent<enemy_radar1>();
		scrRader2 = objRader2.GetComponent<enemy_radar2>();
		scrParameter = objTop.GetComponent<enemy_parameter>();
		numShotCount = 0;	//初期化
	}

	void Update(){
		//Debug用flag
		if(isShot == true){
//			Debug.Log("numShotCount:" + numShotCount);
			//player発見したら
//			if(scrRader1.isDiscovery == true || isRadar == false){
			if(scrRader1.isDiscovery == true || scrRader2.isDiscovery2 == true || isRadar == false){
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
		//攻撃方法none時は、攻撃しない
		if((int)scrParameter.bulletType1 > 0){	
			timeElapsed += Time.deltaTime;	//カウント
			if(timeElapsed >= timeOut){
				//弾の生成位置を指定
				Vector3 vecBulletPos = bulletStartPosition.position;
				//攻撃方法を指定
				if(scrRader1.isDiscovery == true){
					tempBulletType = (int)scrParameter.bulletType1 - 1;
				}else if(scrRader2.isDiscovery2 == true){
					tempBulletType = (int)scrParameter.bulletType2 - 1;
				}else{
					tempBulletType = (int)scrParameter.bulletType1 - 1;
				}

				//弾を生成(int)scrParameter.moveStart
				GameObject shot = Instantiate(
							bulletObject[tempBulletType],
//							bulletObject[(int)scrParameter.bulletType1 - 1],	//攻撃方法none追加のため-1
							vecBulletPos,
							transform.rotation
							);
				//弾に向きを伝える
				if((int)scrParameter.bulletType1 == 1){
					Debug.Log("kteru0?");
					//攻撃時のみ判定
					if(scrRader1.isDiscovery == true){
						//弾に	enemyの向きを伝える
						bullet_move_Enemy flag = shot.GetComponent<bullet_move_Enemy>();
						flag.bulletDirection = scrShotRoll.rollRotation;
					}
				}else if((int)scrParameter.bulletType1 == 2){
					Debug.Log("kteru1?");
					//攻撃時のみ判定
					if(scrRader2.isDiscovery2 == true){
						//弾に	enemyの向きを伝える
						bullet_move_Enemy1 flag = shot.GetComponent<bullet_move_Enemy1>();
						flag.bulletDirection = scrShotRoll.rollRotation;
					}
				}else{
					Debug.Log("kteru2?");
					//弾に	enemyの向きを伝える
					bullet_move_Enemy flag = shot.GetComponent<bullet_move_Enemy>();
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
}