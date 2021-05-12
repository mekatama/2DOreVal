using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour{
	public GameObject[] enemyObject;		//enemyのプレハブを配列で管理
	public Transform[] spawnPosition;		//enemyの生成位置を配列で管理
//	public Transform spawnPosition1 = null;	//enemyの生成位置1
	public GameObject enemy = null;			//実際に生成されるenemy
	private int enemyType;					//enemyの種類
	private int spawnType;					//spawnの場所
	private float timeElapsed = 0.0f;		//生成間隔カウント用
	public float timeOut;					//生成間隔の時間

    void Start(){
		enemyType = 0;	//初期化
		spawnType = 0;	//初期化
	}

    void Update(){
		enemySpawn();
	}
	void enemySpawn(){
		enemyType = 0;					//敵の種類設定、仮で0固定
		spawnType = 0;					//生成位置設定、仮で0固定
//		timeOut = 0.4f;					//連射間隔設定
		timeElapsed += Time.deltaTime;	//カウント
		if(timeElapsed >= timeOut){
			//enemyの生成位置を指定
			Vector3 vecSpawnPos = spawnPosition[spawnType].position;
			//enemyを生成
			Instantiate(
						enemyObject[enemyType],
						vecSpawnPos,
						transform.rotation
						);
			timeElapsed = 0.0f;			//初期化
		}
	}
}
