using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_dash1 : MonoBehaviour{
	public ParticleSystem particle;	//particle入れる用
	private player_move2 playerMove;	//player_move.csを参照
	private bool goParticle;

    void Start(){
		goParticle = false;	//初期化
		//同じオブジェクトのParticleSystemを参照
		particle = this.GetComponent<ParticleSystem>();
		//親オブジェクトのplayer_move.cs参照
		playerMove = GetComponentInParent<player_move2>();
	}

    void Update(){
		//ダッシュ時のみ再生したい
		if(playerMove.isDash == true && goParticle == false){
			particle.Play();
			goParticle = true;
		}
		if(playerMove.isDash == false && goParticle == true){
			particle.Stop();
			goParticle = false;
		}
	}
}
