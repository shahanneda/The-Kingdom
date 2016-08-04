using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_UI : MonoBehaviour {
		private Item_Master item_master;
		public GameObject MyUi;
		void OnEnable(){
			SetInitialReferences();
			item_master.EventObjectThrow += DisableMyMyUi;
			item_master.EventObjectPickup += EnableMyMyUi;
		}

		void OnDisable(){
			item_master.EventObjectThrow -= DisableMyMyUi;
			item_master.EventObjectPickup -= EnableMyMyUi;

		}

		void SetInitialReferences(){
			//MyUi = GetComponent<MyUi> ();
			item_master = GetComponent<Item_Master> ();
		}

		void EnableMyMyUi(){
			if (MyUi != null) {
				MyUi.gameObject.SetActive(true) ;
			}
		}
		void DisableMyMyUi(){
			if (MyUi != null) {
				MyUi.gameObject.SetActive(false) ;
			}
		}
	}
}
