using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Main{
	public class Player_AmmoBox : MonoBehaviour {
		private Player_Master player_master;
		[System.Serializable]
		public class AmmoTypes{
			public string AmmoName;
			public int AmmoCurrentCarried;
			public int AmmoMaxQuantity;
			public AmmoTypes(string aName, int aMaxQuantity, int ACurrentAmount){
				AmmoName = aName;
				AmmoCurrentCarried = ACurrentAmount;
				AmmoMaxQuantity = aMaxQuantity;
			}
		}
		public List<AmmoTypes> typesOfAmmo = new List<AmmoTypes>();
		// Use this for initialization

		void OnEnable(){
			player_master = GetComponent<Player_Master> ();
			player_master.EventPickedupAmmo += PickedUpAmmo;
		}
		void OnDisable(){
			player_master.EventPickedupAmmo -= PickedUpAmmo;
		}
		
		void PickedUpAmmo(string ammoName, int Quanity){
			
			for (int i = 0; i < typesOfAmmo.Count; i++) {
				if (typesOfAmmo[i].AmmoName == ammoName && typesOfAmmo[i].AmmoCurrentCarried + Quanity <= typesOfAmmo[i].AmmoMaxQuantity) {
					typesOfAmmo[i].AmmoCurrentCarried += Quanity;
					player_master.CallEventAmmoChanged ();
				}
			}
		}

	}
}
