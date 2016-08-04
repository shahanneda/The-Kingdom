using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Pickup : MonoBehaviour {
		private Item_Master item_master;

		void OnEnable(){
			SetInitialReferences();
			item_master.EventPickupAction += CarryOutPickupAction;
		}

		void OnDisable(){
			item_master.EventPickupAction -= CarryOutPickupAction;
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
		void CarryOutPickupAction(Transform tParent){
			transform.SetParent (tParent);
			item_master.CallEventObjectPickup ();
			transform.gameObject.SetActive(false);

		}
	}
}
