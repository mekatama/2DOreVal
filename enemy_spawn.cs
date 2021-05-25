using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour{
	public GameObject[] enemyObject;	//enemyのプレハブを配列で管理
	public Transform[] spawnPosition;	//enemyの生成位置を配列で管理
	public GameObject enemy;			//実際に生成されるenemy
	private int enemyType;				//enemyの種類
	private int spawnType;				//spawnの場所
	private float timeElapsed = 0.0f;	//生成間隔カウント用
	public float timeOut;				//生成間隔の時間
	public bool isSpawn;				//enemy生成flag

    void Start(){
		enemyType = 0;	//初期化
		spawnType = 0;	//初期化
		enemy = null;	//
		isSpawn = false;	//初期化
	}

    void Update(){
		if(isSpawn == true){
			enemySpawn();
		}
	}

	void enemySpawn(){
		enemyType = 0;					//敵の種類設定、仮で0固定
		spawnType = Random.Range(0,5);	//生成位置設定
		timeElapsed += Time.deltaTime;	//カウント
		if(timeElapsed >= timeOut){
			//enemyの生成位置を指定
			Vector3 vecSpawnPos = spawnPosition[spawnType].position;
			//enemyを生成
			GameObject enemy = Instantiate(
						enemyObject[enemyType],
						vecSpawnPos,
						transform.rotation
						);
			//生成した敵のenemy1_direction.csを取得
			enemy1_direction s = enemy.GetComponentInChildren<enemy1_direction>();
			//生成時の移動方向を指定
			switch(spawnType){
				case 0:
					int temp = Random.Range(0,2);
					if(temp == 0){
						s.isForward = false;	//左に移動
					}else{
						s.isForward = true;		//右に移動
					}
					break;
				case 1:
					s.isForward = false;	//左に移動
					break;
				case 2:
					s.isForward = true;		//右に移動
					break;
				case 3:
					s.isForward = false;	//左に移動
					break;
				case 4:
					s.isForward = true;		//右に移動
					break;
			}

			timeElapsed = 0.0f;			//初期化
		}
	}
}
