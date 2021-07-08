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
	public bool isOnce1;					//falseにするのは
	private bool spawn1IsDeth;

    void Start(){
		enemyType = 0;	//初期化
		spawnType = 0;	//初期化
		enemy = null;	//
		scrTorideSpawn1 = objTorideSpawn1.GetComponent<toride_spawn1>();
	}

    void Update(){
		//spawn1からenemy
		if(scrTorideSpawn1.isSpawn == true){
			if(isOnce1 == false){
				timeElapsed += Time.deltaTime;	//カウント
				if(timeElapsed >= timeOut){
					enemySpawn();
					Debug.Log("spawn");
					isOnce1 = true;
					timeElapsed = 0;
				}
			}
		}	
	}
	void enemySpawn(){
		enemyType = 0;	//敵の種類設定、仮で0固定
		spawnType = 0;	//生成位置設定
		//enemyの生成位置を指定
		Vector3 vecSpawnPos = spawnPosition[spawnType].position;
		//enemyを生成
		GameObject enemy = Instantiate(
					enemyObject[enemyType],
					vecSpawnPos,
					transform.rotation
					);
		//生成した敵のenemy1.csを取得
		enemy_toride1 scrEnemyToride1 = enemy.GetComponentInChildren<enemy_toride1>();
		scrEnemyToride1.isGo1 = true;
	}
}
