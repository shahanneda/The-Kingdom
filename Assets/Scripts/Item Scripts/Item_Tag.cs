using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Tag : MonoBehaviour {
		public string ItemTag;
		void OnEnable(){
			
			SetTag ();
		}
		void SetTag(){
			if (ItemTag == "") {
				ItemTag = "Untagged";

			}
			transform.tag = ItemTag;
		}


	}
}
