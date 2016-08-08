using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Name : MonoBehaviour {
		public string ItemName;
		void Start(){
			SetName ();
		}
		void SetName(){
			transform.name = ItemName;
		}

	}
}
