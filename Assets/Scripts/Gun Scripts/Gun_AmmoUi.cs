using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Main{
	public class Gun_AmmoUi : MonoBehaviour {
		public InputField CurrentAmmoF;
		public InputField CarriedAmmoF;
		private Gun_Master gun_master;
		void OnEnable(){
			SetInitialReferences();
			gun_master.EventAmmoChanged += UpdateAmmoUi;
		}

		void OnDisable(){
			gun_master.EventAmmoChanged -= UpdateAmmoUi;
		}

		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
		}
		void UpdateAmmoUi(int CurrentAmmo,int CarriedAmmo){
			if (CurrentAmmoF != null) {
				CurrentAmmoF.text = CurrentAmmo.ToString ();
			}
			if (CarriedAmmoF != null) {
				CarriedAmmoF.text = CarriedAmmo.ToString ();
			}
		}

	}
}
