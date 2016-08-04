using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_SetLayer : MonoBehaviour {
		private Item_Master item_master;
		public string itemThrowLayer;
		public string itemPickupLayer;
		void OnEnable(){
			SetInitialReferences();
			SetLayerOnEnable ();
			item_master.EventObjectPickup += SetItemToPickupLayer;
			item_master.EventObjectThrow += SetItemToThrowLayer;
		}

		void OnDisable(){
			item_master.EventObjectPickup -= SetItemToPickupLayer;
			item_master.EventObjectThrow -= SetItemToThrowLayer;
		}

		void SetInitialReferences(){
			item_master = GetComponent<Item_Master> ();
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void SetItemToThrowLayer(){
			SetLayer (transform,itemThrowLayer);
			print ("SetItemToThrowLayer");
		}
		void SetItemToPickupLayer(){
			SetLayer (transform,itemPickupLayer);
			print ("SetItemToPickupLayer");
		}
		void SetLayerOnEnable(){
			if(itemPickupLayer == ""){
				itemPickupLayer = "Item";
			}
			if(itemThrowLayer == ""){
				itemThrowLayer = "Item";
			}
			if (transform.root.CompareTag (GameManager_References.PlayerTag)) {
				SetItemToPickupLayer ();
			} else {
				SetItemToThrowLayer ();
			}
		}
		void SetLayer(Transform tForm, string name){
			tForm.gameObject.layer = LayerMask.NameToLayer (name);
			foreach (Transform child in tForm) {
				SetLayer (child,name);
			}
		}


	}
}
