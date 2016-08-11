using UnityEngine;
using System.Collections;
namespace Main{
	public class Destructble_CollionDetection : MonoBehaviour {
		private Destructble_Master destructble_master;
		private Collider[] colls;
		bool checkedSpeed;
		private Rigidbody myRb;
		public float threshholdMass;
		public float threshholdSpeed = 6;

		void SetInitialReferences(){
			destructble_master = GetComponent<Destructble_Master> ();
			if (GetComponent<Rigidbody>() != null) {
				myRb = GetComponent<Rigidbody> ();
			}
		}

		// Use this for initialization
		void Start () {
			SetInitialReferences();
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void OnCollisionEnter(Collision coll){
			
			if (coll.contacts.Length > 0) {
				if (coll.contacts [0].otherCollider.GetComponent<Rigidbody> () != null) {
					CollisonCheck (coll.contacts [0].otherCollider.GetComponent<Rigidbody> ());
				} else {
					SelfSpeedCheck ();
				}
			}
		}
		void CollisonCheck(Rigidbody otherRidedbody){
			if (otherRidedbody.mass > threshholdMass &&
				otherRidedbody.velocity.sqrMagnitude > (threshholdSpeed * threshholdSpeed)) {
				int dmg = (int)otherRidedbody.mass;
				destructble_master.CallEventDeductHealth (dmg);
				print (dmg);
			} else {
				SelfSpeedCheck ();
			}

		}
		void SelfSpeedCheck(){
			if (myRb.velocity.sqrMagnitude > (threshholdSpeed * threshholdSpeed)&& !checkedSpeed) {
				checkedSpeed = true; 
				int dmg = (int)myRb.mass;
	
				destructble_master.CallEventDeductHealth (dmg);

			}
		}
	}
}
