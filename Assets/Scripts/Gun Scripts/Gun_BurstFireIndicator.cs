using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_BurstFireIndicator : MonoBehaviour {
		private Gun_Master gun_master;
		public GameObject indicator;
	
		void OnEnable(){
			SetInitialReferences();
			gun_master.EventToggleBurstFire += toggleBurstFire;
		}

		void OnDisable(){
			gun_master.EventToggleBurstFire -= toggleBurstFire;
		}

		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
		}
		void toggleBurstFire(){
			
			if (indicator != null) {
				
				indicator.SetActive (!indicator.activeSelf);
			}
		}
			
	}
}
