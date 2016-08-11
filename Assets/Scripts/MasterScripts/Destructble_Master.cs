using UnityEngine;
using System.Collections;
namespace Main{
	public class Destructble_Master : MonoBehaviour {

		public delegate void HealthEventHandler(int health); 
		public event HealthEventHandler EventDeductHealth;

		public delegate void GeneralEventHandler();
		public event GeneralEventHandler EventDestroyMe;
		public event GeneralEventHandler EventHealthLow;

		public void CallEventDeductHealth(int _health){
			if (EventDeductHealth != null) {
				EventDeductHealth (_health);
			}
		}
		public void CallEventDestroyMe(){
			if (EventDestroyMe != null) {
				EventDestroyMe ();
			}
		}
		public void CallEventHealthLow(){
			if (EventHealthLow != null) {
				EventHealthLow ();
			}
		}
	}
}
