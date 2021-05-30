using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_scroll : MonoBehaviour{
	private GameObject player;
	private Vector3 startPlayerOffset;
	private Vector3 startCameraPos;
	private static readonly float RATE = 0.3f;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		startPlayerOffset = player.transform.position;
		startCameraPos = this.transform.position;
	}

	void Update() {
		Vector3 v = (player.transform.position - startPlayerOffset) * RATE;
		this.transform.position = new Vector3 (startCameraPos.x + v.x, transform.position.y, transform.position.z);
	}
}
