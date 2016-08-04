using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Colliders : MonoBehaviour {
		private Item_Master item_master;
		public PhysicMaterial my_mat;
		private Collider[] colliders;
		void OnEnable(){
			SetInitialReferences();
			CheckIfStartsInInventory ();
			item_master.EventObjectThrow += SetColliderActive;
			item_master.EventObjectPickup -= SetColliderFalse;
		}

		void OnDisable(){
			item_master.EventObjectThrow -= SetColliderActive;
			item_master.EventObjectPickup -= SetColliderFalse;
		}

		void SetInitialReferences(){
			colliders = GetComponentsInChildren<Collider> ();
			item_master = GetComponent<Item_Master> ();
		}


		void CheckIfStartsInInventory(){
			if (transform.root.CompareTag(GameManager_References.PlayerTag)) {
				SetColliderFalse ();
			}
		}
		void SetColliderActive(){
			if (colliders.Length > 0) {
				foreach (Collider collider in colliders) {
					collider.enabled = true;
					if (my_mat != null) {
						collider.material = my_mat;
					}
				}
			}
		}
		void SetColliderFalse(){
			if (colliders.Length > 0) {
				foreach (Collider collider in colliders) {
					collider.enabled = false;
				}
			}
	}
}
}
