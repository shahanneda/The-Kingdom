using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_SetPosition : MonoBehaviour {
		private Item_Master item_master;
		public Vector3 item_Local_Position;

		void OnEnable(){
			SetInitialReferences();
			SetPositionOnPlayer ();
			item_master.EventObjectPickup += SetPositionOnPlayer;
		}

		void OnDisable(){
			item_master.EventObjectPickup -= SetPositionOnPlayer;
		}

		void SetInitialReferences(){
			item_master = GetComponent<Item_Master> ();
		}

		void SetPositionOnPlayer(){
			if (transform.root.CompareTag (GameManager_References.PlayerTag)) {
				transform.localPosition = item_Local_Position;
			}
		}
	}
}
