using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_toride2 : MonoBehaviour{
	public bool isGo2;		//toride側でtrueにする
	private GameObject objTorideController;	//toride_controller.csをアッタチしているオブジェクト用
	private toride_controller scrTorideCon;	//toride_controller.csスクリプト入れる用

    void Start(){
		objTorideController = GameObject.Find("TorideController");
		scrTorideCon = objTorideController.GetComponent<toride_controller>();
	}

	//enemy破壊時
 	void OnDestroy(){
		//spawn2からspawnしたenemyに対して判定
		if(isGo2 == true){
			scrTorideCon.isOnce2 = false;
			isGo2 = false;
		}
	}
}
