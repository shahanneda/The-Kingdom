using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_ApplyForce : MonoBehaviour {
		private Gun_Master gun_master;
		private Transform mytransform;
		public float ForcetoApply;
		void OnEnable(){
			SetInitialReferences();
			gun_master.EventShotDefualt += applyForce;
		}

		void OnDisable(){
			gun_master.EventShotDefualt -= applyForce;
		}

		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
			mytransform = transform;
		}

		void applyForce(Vector3 position,Transform hitTransfom){
			if (hitTransfom.GetComponent<Rigidbody>() != null) {
				hitTransfom.GetComponent<Rigidbody> ().AddForce (mytransform.forward * ForcetoApply,ForceMode.Impulse);
			}
		}
	}
}
