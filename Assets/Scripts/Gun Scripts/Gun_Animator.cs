using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_Animator : MonoBehaviour {
		private Animator animator;
		private Gun_Master gun_master;
		void OnEnable(){
			SetInitialReferences();
			gun_master.EventPlayerInput += PlayShootAnimation;
		}

		void OnDisable(){
			gun_master.EventPlayerInput -= PlayShootAnimation;
		}

		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
			if (GetComponent<Animator>() != null) {
				animator = GetComponent<Animator> ();
			}
		}
		void PlayShootAnimation(){
			if (animator != null) {
				animator.SetTrigger ("Shoot");
			}
		}


	}
}
