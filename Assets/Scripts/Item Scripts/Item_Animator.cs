using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Animator : MonoBehaviour {
		private Animator animator;
		private Item_Master item_master;

		void OnEnable(){
			SetInitialReferences();
			item_master.EventObjectThrow += DisableMyAnimator;
			item_master.EventObjectPickup += EnableMyAnimator;
		}

		void OnDisable(){
			item_master.EventObjectThrow -= DisableMyAnimator;
			item_master.EventObjectPickup -= EnableMyAnimator;
		
		}

		void SetInitialReferences(){
			animator = GetComponent<Animator> ();
			item_master = GetComponent<Item_Master> ();
		}

		void EnableMyAnimator(){
			if (animator != null) {
				animator.enabled = true;
			}
		}
		void DisableMyAnimator(){
			if (animator != null) {
				animator.enabled = false;
			}
		}
	}
}
