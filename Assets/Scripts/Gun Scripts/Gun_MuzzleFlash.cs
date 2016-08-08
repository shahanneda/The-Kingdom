using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_MuzzleFlash : MonoBehaviour {
		public ParticleSystem muzzleFlash;
		private Gun_Master gun_Master;

		void OnEnable(){
			SetInitialReferences();
			gun_Master.EventPlayerInput += MuzzleFlash;
		}

		void OnDisable(){
			gun_Master.EventPlayerInput -= MuzzleFlash;
		}

		void SetInitialReferences(){
			gun_Master = GetComponent<Gun_Master> ();
		}
		void MuzzleFlash(){
			if (muzzleFlash != null) {
				muzzleFlash.Play ();
			}
		}
	}
}
