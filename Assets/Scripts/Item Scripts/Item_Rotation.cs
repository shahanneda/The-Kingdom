using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Rotation : MonoBehaviour {
		private Item_Master item_master;
		public Vector3 item_Local_rotation;

		void OnEnable(){
			SetInitialReferences();
			SetRotationOnPlayer ();
			item_master.EventObjectPickup += SetRotationOnPlayer;
		}

		void OnDisable(){
			item_master.EventObjectPickup -= SetRotationOnPlayer;
		}

		void SetInitialReferences(){
			item_master = GetComponent<Item_Master> ();
		}

		void SetRotationOnPlayer(){
			if (transform.root.CompareTag (GameManager_References.PlayerTag)) {
				transform.localEulerAngles = item_Local_rotation;

			}
		}
	}
}
