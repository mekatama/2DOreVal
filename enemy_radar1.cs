using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_radar1 : MonoBehaviour{
	public bool isDiscovery;	//player発見flag

	//他のオブジェクトとの当たり判定(trigger))
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			Debug.Log("!!");
			isDiscovery = true;	//発見!
		}
	}
}
