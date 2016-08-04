using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Ammo : MonoBehaviour {
		private Item_Master item_master;
		private GameObject playerGO;
		public string ammoName;
		public int quantity;
		public bool isTriggerPickup;
		void OnEnable(){
			SetInitialReferences();
			item_master.EventObjectPickup += TakeAmmo;
		}

		void OnDisable(){

		}

		void SetInitialReferences(){
			item_master = GetComponent<Item_Master> ();
			playerGO = GameManager_References._player;
			if (isTriggerPickup) {
				if (GetComponent<Collider>()) {
					GetComponent<Collider> ().isTrigger = true;
				}
				if (GetComponent<Rigidbody>()) {
					GetComponent<Rigidbody> ().isKinematic = true;
				}
			}

		}
		void OnTriggerEnter(Collider coll){
			if (coll.CompareTag(GameManager_References.PlayerTag) && isTriggerPickup) {
				TakeAmmo ();
			}
		}
		// Use this for initialization
		void Start () {
			SetInitialReferences();
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void TakeAmmo(){
			playerGO.GetComponent<Player_Master> ().CallEventPickedupAmmo (ammoName,quantity);
			Destroy(gameObject);
		}
	}
}
