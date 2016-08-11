using UnityEngine;
using System.Collections;
namespace Main{
	public class Destructble_LowHealth : MonoBehaviour {
		private Destructble_Master  destructble_master;
		public GameObject[] lowHealthEffectGO;
		void OnEnable(){
			SetInitialReferences();
			destructble_master.EventHealthLow += TurnOnLowHealthEffect;
		}

		void OnDisable(){
			destructble_master.EventHealthLow -= TurnOnLowHealthEffect;
		}

		void SetInitialReferences(){
			destructble_master = GetComponent<Destructble_Master> ();
		}

		void TurnOnLowHealthEffect(){
			if (lowHealthEffectGO.Length > 0) {
				foreach (GameObject item in lowHealthEffectGO) {
					item.SetActive (true);
				}
			}
		}
	}
}
