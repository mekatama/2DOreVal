using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toride_spawn1 : MonoBehaviour{
	public bool isSpawn;		//flag

	//他のオブジェクトとの当たり判定(trigger))
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			isSpawn = true;
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
//			isSpawn = false;
		}
	}

	void Start(){
	}

    void Update(){
	}
}
