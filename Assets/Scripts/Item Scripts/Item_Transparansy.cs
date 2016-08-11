using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Transparansy : MonoBehaviour {
		private Item_Master item_master;
		public Material tansparent;
		public Material normal;

		void OnEnable(){
			SetInitialReferences();
			item_master.EventObjectPickup += SetToTransparent;
			item_master.EventObjectThrow += SetToPrimary;
		}

		void OnDisable(){
			item_master.EventObjectPickup -= SetToTransparent;
			item_master.EventObjectThrow -= SetToPrimary;
		}

		void SetInitialReferences(){
			item_master = GetComponent<Item_Master> ();
		}

		// Use this for initialization
		void Start () {
			CaptureStaringMat ();
			if (transform.root.CompareTag(GameManager_References.PlayerTag)) {
				SetToTransparent ();
			}
		}
		void CaptureStaringMat(){
			normal = GetComponent<Renderer> ().material;
		}
		void SetToPrimary(){
			GetComponent<Renderer> ().material = normal;
		}
		void SetToTransparent(){
			GetComponent<Renderer> ().material = tansparent;
		}
	}
}
