using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toride_controller : MonoBehaviour{
	public GameObject[] enemyObject;	//enemyのプレハブを配列で管理
	public Transform[] spawnPosition;	//enemyの生成位置を配列で管理
	public GameObject enemy;			//実際に生成されるenemy
	private int enemyType;				//enemyの種類
	private int spawnType;				//spawnの場所
	private float timeElapsed = 0.0f;	//生成間隔カウント用
	public float timeOut;				//生成間隔の時間

	public GameObject objTorideSpawn1;		//toride_spawn1.csをアッタチしているオブジェクト用
	private toride_spawn1 scrTorideSpawn1;	//toride_spawn1.csスクリプト入れる用
	public GameObject objTorideSpawn2;		//toride_spawn1.csをアッタチしているオブジェクト用
	private toride_spawn2 scrTorideSpawn2;	//toride_spawn1.csスクリプト入れる用
	public bool isOnce1;					//
	public bool isOnce2;					//
	private bool spawn1IsDeth;

    void Start(){
		enemyType = 0;	//初期化
		spawnType = 0;	//初期化
		enemy = null;	//
		scrTorideSpawn1 = objTorideSpawn1.GetComponent<toride_spawn1>();
		scrTorideSpawn2 = objTorideSpawn2.GetComponent<toride_spawn2>();
	}

    void Update(){
		//spawn1からenemy
		if(scrTorideSpawn1.isSpawn == true){
			if(isOnce1 == false){
				timeElapsed += Time.deltaTime;	//カウント
				if(timeElapsed >= timeOut){
					enemySpawn(1);
					isOnce1 = true;
					timeElapsed = 0;
				}
			}
		}	
		//spawn2からenemy
		if(scrTorideSpawn2.isSpawn == true){
			if(isOnce2 == false){
				timeElapsed += Time.deltaTime;	//カウント
				if(timeElapsed >= timeOut){
//					enemySpawn(2);
					isOnce2 = true;
					timeElapsed = 0;
				}
			}
		}	
	}
	void enemySpawn(int a){
		switch(a){
			case 1:
				spawnType = 0;	//生成位置設定
				enemyType = 0;	//敵の種類設定
				break;
			case 2:
				spawnType = 1;	//生成位置設定
				enemyType = 1;	//敵の種類設定
				break;
		}
		//enemyの生成位置を指定
		Vector3 vecSpawnPos = spawnPosition[spawnType].position;
		//enemyを生成
		GameObject enemy = Instantiate(
					enemyObject[enemyType],
					vecSpawnPos,
					transform.rotation
					);
		switch(a){
			case 1:
				//生成した敵のenemy_toride1.csを取得
				enemy_toride1 scrEnemyToride1 = enemy.GetComponentInChildren<enemy_toride1>();
				scrEnemyToride1.isGo1 = true;
				break;
			case 2:
				//生成した敵のenemy_toride2.csを取得
				enemy_toride2 scrEnemyToride2 = enemy.GetComponentInChildren<enemy_toride2>();
				scrEnemyToride2.isGo2 = true;
				break;
		}
	}
}
