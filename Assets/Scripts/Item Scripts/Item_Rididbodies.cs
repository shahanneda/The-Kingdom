using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Rididbodies : MonoBehaviour {
		private Item_Master item_master;
		private Rigidbody[] m_Rigidbodies;
		void OnEnable(){
			SetInitialReferences();
			CheckIfStartsInInventory ();
			item_master.EventObjectThrow += SetIsKinematicToFalse;
			item_master.EventObjectPickup += SetIsKinematicToTrue;
		}

		void OnDisable(){
			item_master.EventObjectThrow -= SetIsKinematicToFalse;
			item_master.EventObjectPickup -= SetIsKinematicToTrue;
		}

		void SetInitialReferences(){
			m_Rigidbodies = GetComponentsInChildren<Rigidbody> ();
			item_master = GetComponent<Item_Master> ();
		}

		void CheckIfStartsInInventory(){
			if (transform.root.CompareTag(GameManager_References.PlayerTag)) {
				SetIsKinematicToTrue ();
			}
		}
		void SetIsKinematicToTrue(){
			if (m_Rigidbodies.Length > 0) {
				foreach (Rigidbody rBody in m_Rigidbodies) {
					rBody.isKinematic = true;
				}
			}
		}
		void SetIsKinematicToFalse(){
			if (m_Rigidbodies.Length > 0) {
				foreach (Rigidbody rBody in m_Rigidbodies) {
					rBody.isKinematic = false;
				}
			}
		}
	}
}
