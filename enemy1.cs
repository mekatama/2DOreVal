using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour{
	public int enemyHp;				//EnemyのHP
	private bool isDeth;			//死亡flag
	private bool isDamage;			//damage flag
	public SpriteRenderer s;		//
	public GameObject particle_exp;	//爆発Particle

    void Start(){
		isDeth = false;		//初期化
		isDamage = false;	//初期化
		s = gameObject.GetComponent<SpriteRenderer>();
	}

    void Update(){
		//ダメージ点滅処理
		if(isDamage == true){
			float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
			s.color = new Color(1f, 0f, 0f, level);	//赤点滅
		}
	}

	//他のオブジェクトとの当たり判定(trigger)
	void OnTriggerEnter2D( Collider2D other) {
		if(other.tag == "Bullet"){
			//ダメージ処理
			if(enemyHp > 0){
				enemyHp = enemyHp - 1;	//[仮]攻撃力をHPから引く
				if(enemyHp <= 0){
					enemyHp = 0;
				}
				isDamage = true;
				StartCoroutine(onDamage());
			}
			//死亡判定
			if(enemyHp == 0){
				if(isDeth == false){
					Destroy(gameObject);			//このGameObjectを削除
					//爆発effect
					Instantiate (particle_exp, transform.position, transform.rotation);
					isDeth = true;
				}
			}
		}
	}

	//点滅制御用コルーチン
	public IEnumerator onDamage(){
		//指定時間待機
		yield return new WaitForSeconds(0.1f);
		//通常に戻す
		isDamage = false;
		s.color = new Color(1f, 1f, 1f, 1f);	
	}
}
