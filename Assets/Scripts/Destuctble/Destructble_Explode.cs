using UnityEngine;
using System.Collections;
namespace Main{
	public class Destructble_Explode : MonoBehaviour {
		private Destructble_Master destructble_master;
		public float force;
		public float range;
		private float distance;
		public int rawDamage;
		private int damageToApply;
		private Collider[] struckColls;
		private Transform myTransfomr;
		private RaycastHit hit;
		void OnEnable(){
			SetInitialReferences();
			destructble_master.EventDestroyMe += ExplosionSphere;
		}

		void OnDisable(){

		}

		void SetInitialReferences(){
			destructble_master = GetComponent<Destructble_Master> ();
			myTransfomr = transform;
		}
		void ExplosionSphere(){
			myTransfomr.parent = null;
			GetComponent<Collider> ().enabled = false;

			struckColls = Physics.OverlapSphere (myTransfomr.position,range);
			foreach (Collider coll in struckColls) {
				distance = Vector3.Distance (myTransfomr.position, coll.transform.position);
				damageToApply = (int)Mathf.Abs ((1 - (distance / range)) * rawDamage);

				if (Physics.Linecast(myTransfomr.position,coll.transform.position,out hit)) {
					if (hit.transform == coll.transform || coll.transform.GetComponent<Enemy_TakeDamage>() != null ||coll.transform.GetComponent<DestructibleTakeDamage>() != null ) {
						coll.SendMessage ("ProcessDamage",damageToApply, SendMessageOptions.DontRequireReceiver);
						if (coll.transform.GetComponent<DestructibleTakeDamage>()) {
							coll.SendMessage ("ProcessDamage",damageToApply * 100, SendMessageOptions.DontRequireReceiver);
						}
						coll.SendMessage ("CallEventPlayerHealthDeduction",damageToApply, SendMessageOptions.DontRequireReceiver);
					}
				}
				if (coll.GetComponent<Rigidbody>() != null) {
					coll.GetComponent<Rigidbody> ().AddExplosionForce (force,myTransfomr.position,range,1,ForceMode.Impulse);
				}
			}
			Destroy (gameObject,0.5f);
		}


	}
}
