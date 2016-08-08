﻿using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_ApplyDamage : MonoBehaviour {
		private Gun_Master gun_master;
		public int damage = 10;

		void OnEnable(){
			SetInitialReferences();
		}

		void OnDisable(){

		}

		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
			gun_master.EventShotEnemy += ApplyDamage;
		}

		void ApplyDamage(Vector3 hitPosition,Transform hitTransform){
			if (hitTransform.GetComponent<Enemy_TakeDamage>()) {
				hitTransform.GetComponent<Enemy_TakeDamage> ().ProcessDamage (damage);
			}
		}
	}
}
