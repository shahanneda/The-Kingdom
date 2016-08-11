using UnityEngine;
using System.Collections;
namespace Main{
	public class Melee_Swing : MonoBehaviour {
		private Melee_Master melee_master;
		private Collider mycoll;
		public  Rigidbody Rb;
		public Animator anmi;

		void OnEnable(){
			SetInitialReferences();
			melee_master.EventMeleePlayerInput += AtackAction;
		}

		void OnDisable(){
			melee_master.EventMeleePlayerInput -= AtackAction;
		}

		void SetInitialReferences(){
			mycoll = GetComponent<Collider> ();
			melee_master = GetComponent<Melee_Master> ();

		}

		void AtackAction(){
			mycoll.enabled = true;
			Rb.isKinematic = false;
			anmi.SetTrigger ("Attack");
			print ("Atacking");
		
		}
		public void AtackComplete(){
			mycoll.enabled = false;
			Rb.isKinematic = true;
			melee_master.isInUse = false;
		}
	}
}
