using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_CollisionField : MonoBehaviour {
		private Enemy_Master enemy_master;
		private Rigidbody rbStrikingME;
		private int damageToApply;
		public float massRequirment = 50;
		public float SpeedRequtiment  = 05;
		public float damamgeFActor  = 0.1f;
		void OnEnable(){
			SetInitialReferences ();

			enemy_master = transform.root.GetComponent<Enemy_Master> ();
			enemy_master.EventEnemyDie += DisableThis;

		}
		void OnDisable(){
			enemy_master.EventEnemyDie -= DisableThis;

		}

		void SetInitialReferences(){

		}

		void OnTriggerEnter(Collider coll){
			if (coll.GetComponent<Rigidbody>() != null) {
				rbStrikingME = coll.GetComponent<Rigidbody> ();
				if (rbStrikingME.mass >= massRequirment &&
					rbStrikingME.velocity.sqrMagnitude > SpeedRequtiment * SpeedRequtiment) {
					damageToApply = (int)(damamgeFActor * rbStrikingME.mass * rbStrikingME.velocity.magnitude);
					enemy_master.CallDeductEnemyHealth (damageToApply);
				}
			}
		}
		void DisableThis(){
			gameObject.SetActive (false);
		}
	}
}
