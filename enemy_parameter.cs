using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_parameter : MonoBehaviour{
	public int enemyHp;			//enemy HP
	public int enemySpeed;		//enemy speed
	public float timeOut;		//連射間隔の時間
	public int numShot;			//1setの攻撃数
	public float stopTime;		//一時停止時間

	//初期移動方向select
	public enum MoveStart{
		left = 0,
		right = 1
		}
	public MoveStart moveStart;

	//動き種類select
	public enum MoveType{
		stop = 0,		//動かない
		advance = 1,	//前進のみ
		pause = 2,		//player発見で停止
		round_trip = 3,	//往復移動
		pause_tride = 4	//砦 一定時間前進→停止
		}
	public MoveType moveType;

	//弾の種類select
	public enum BulletType1{
		none = 0,
		straight = 1,
		howitzer = 2
//		straight = 0,
//		howitzer = 1
	}
	public BulletType1 bulletType1;

	//弾の種類select2
	public enum BulletType2{
		none = 0,
		straight = 1,
		howitzer = 2
	}
	public BulletType2 bulletType2;

	//レーダー使用設定
	public bool isRaderUse;

	public GameObject objModel;	//enemy1.csをアッタチしているオブジェクト用
	private enemy1 scrEnemy1;	//enemy1.csスクリプト入れる用
	public GameObject objEnemy;	//enemy1_move.csをアッタチしているオブジェクト用
	private enemy1_move scrEnemy1Move;//enemy1_move.csスクリプト入れる用
	public GameObject objShotPoint;	//enemy_shot1.csをアッタチしているオブジェクト用
	private enemy_shot1 scrEnemyShot1;//enemy_shot1.csスクリプト入れる用

	void Start(){
		scrEnemy1 = objModel.GetComponent<enemy1>();
		scrEnemy1.enemyHp = enemyHp;		//enemy1.csに代入
		scrEnemy1Move = objEnemy.GetComponent<enemy1_move>();
		scrEnemy1Move.speed = enemySpeed;	//enemy1_move.csに代入
		scrEnemyShot1 = objShotPoint.GetComponent<enemy_shot1>();
		scrEnemyShot1.timeOut = timeOut;	//enemy_shot1.csに代入
		scrEnemyShot1.numShot = numShot;	//enemy_shot1.csに代入
		scrEnemyShot1.stopTime = stopTime;	//enemy_shot1.csに代入
		scrEnemyShot1.isRadar = isRaderUse;	//enemy_shot1.csに代入
	}

	void Update(){
	}
}
