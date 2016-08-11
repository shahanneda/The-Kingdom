using UnityEngine;
using System.Collections;
namespace Main{
	public class Melee_HitEfffects : MonoBehaviour {
		private Melee_Master mm;
		public GameObject normalEffect;
		public GameObject EnemyEffect;
		void SpawnHitEffect(Collision coll, Transform hittransform){
			Quaternion quatAngle = Quaternion.LookRotation (coll.contacts [0].normal);
			if (hittransform.GetComponent<Enemy_TakeDamage> () != null) {
				Instantiate (EnemyEffect, coll.contacts [0].point, quatAngle);
			} else {
				Instantiate (normalEffect, coll.contacts [0].point, quatAngle);
			}
		}
		void OnEnable(){
			SetInitialReferences();
			mm.EventHit += SpawnHitEffect;
		}

		void OnDisable(){
			mm.EventHit -= SpawnHitEffect;
		}

		void SetInitialReferences(){
			mm = GetComponent<Melee_Master> ();
		}


	}
}
