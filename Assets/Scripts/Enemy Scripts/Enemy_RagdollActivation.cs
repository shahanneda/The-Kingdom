using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_RagdollActivation : MonoBehaviour {
		private Enemy_Master enemy_master;
		private Rigidbody myRigidbody;
		public Collider myCollider;
		void OnEnable(){
			SetInitialReferences();
			enemy_master.EventEnemyDie += ActivateRagdoll;
		}

		void OnDisable(){

		}

		void SetInitialReferences(){
			enemy_master = transform.root.GetComponent<Enemy_Master> ();
			if (GetComponent<Collider>() != null) {
				myCollider = GetComponent<Collider> ();
			}
			if (GetComponent<Rigidbody>() != null) {
				myRigidbody = GetComponent<Rigidbody> ();
			}
		}
		void ActivateRagdoll(){
			if (myRigidbody != null) {
				myRigidbody.isKinematic = false;
				myRigidbody.useGravity = true;
			}
			if (myCollider != null) {
				myCollider.isTrigger = false;
				myCollider.enabled = true;
			}
		}


	}
}
