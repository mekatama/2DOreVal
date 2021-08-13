using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_radar2 : MonoBehaviour{
	public bool isDiscovery2;	//player発見flag

	//他のオブジェクトとの当たり判定(trigger))
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
//			Debug.Log("!!2");
			isDiscovery2 = true;	//発見!
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
//			Debug.Log("??2");
			isDiscovery2 = false;	//発見!
		}
	}
}
