using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Drop : MonoBehaviour {
		private Item_Master itemmaster;
		public string DropButtonName = "Drop" ;
		void OnEnable(){
			SetInitialReferences();
		}

		void OnDisable(){

		}

		void SetInitialReferences(){
			itemmaster = GetComponent<Item_Master> ();
		}

		void CheckForDropInput(){
			if (Input.GetButton(DropButtonName)) {
				if (Time.timeScale > 0 && transform.root.CompareTag(GameManager_References.PlayerTag)) {
					transform.SetParent (null);
					itemmaster.CallEventObjectThrow ();
				}
			}
		}
		void Update(){
			CheckForDropInput ();
		}
	}
}
