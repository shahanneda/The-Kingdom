using UnityEngine;
using System.Collections;
namespace Main{
	public class DestructibleTakeDamage : MonoBehaviour {
		private Destructble_Master destructble_master;
		void SetInitialReferences(){
			destructble_master = GetComponent<Destructble_Master> ();
		}

		// Use this for initialization
		void Start () {
			SetInitialReferences();
		}
		

		public void ProcessDamage(int damage){
			destructble_master.CallEventDeductHealth (damage);

		}
	}
}
