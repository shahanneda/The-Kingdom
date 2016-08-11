using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_Reset : MonoBehaviour {
		private Gun_Master gun_master;
		private Item_Master item_master;

		void OnEnable(){
			SetInitialReferences();
			if (item_master != null) {
				item_master.EventObjectThrow += resetGun;
			}
		}

		void OnDisable(){
			if (item_master != null) {
				item_master.EventObjectThrow -= resetGun;
			}
		}

		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
			if (GetComponent<Item_Master>() != null) {
				item_master = GetComponent<Item_Master> ();
			}
		}

		void resetGun(){
			gun_master.CallEventRequestGunReset ();
		}
	}
}
