using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_HitEffect : MonoBehaviour {
		private Gun_Master gun_master;
		public GameObject DefaultHitEffect;
		public GameObject EnemyHitEffect;

		void OnEnable(){
			SetInitialReferences();
			gun_master.EventShotDefualt += SpawnDefaultEffect;
			gun_master.EventShotEnemy += SpawnEnemyEffect;
		}

		void OnDisable(){
			gun_master.EventShotDefualt -= SpawnDefaultEffect;
			gun_master.EventShotEnemy -= SpawnEnemyEffect;
		}

		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
		}

		void SpawnDefaultEffect(Vector3 position, Transform transform){
			Quaternion quatAngle = Quaternion.LookRotation (position);
			Instantiate (DefaultHitEffect, position, quatAngle);
			//Instantiate (DefaultHitEffect, position, Quaternion.identity);
		}
		void SpawnEnemyEffect(Vector3 position, Transform transform){
			if (EnemyHitEffect != null) {
				Quaternion quatAngle = Quaternion.LookRotation (position);


			
				Instantiate (EnemyHitEffect, position, quatAngle);

				//Instantiate (EnemyHitEffect, position, Quaternion.identity);
			}
		}
	}
}
