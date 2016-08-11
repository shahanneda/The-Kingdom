using UnityEngine;
using System.Collections;
namespace Main{
	public class Destructble_Degrente : MonoBehaviour {
		private Destructble_Master destructble_master;
		private bool isHelahtLow;
		public float DegenRAte;
		private float NextRegen;
		public int healthLoss;
		void OnEnable(){
			SetInitialReferences();
			destructble_master.EventHealthLow += healthLow;
		}

		void OnDisable(){
			destructble_master.EventHealthLow -= healthLow;
		}

		void SetInitialReferences(){
			destructble_master = GetComponent<Destructble_Master> ();
		}

		void healthLow(){
			isHelahtLow = true;
		}
		void CheckIFHealthShouldDegen(){
			if (isHelahtLow) {
				if (Time.time > NextRegen) {
					NextRegen = Time.time + DegenRAte;
					destructble_master.CallEventDeductHealth (healthLoss);
				}
			}
		}
		void Update(){
			CheckIFHealthShouldDegen ();
		}
	}
}
