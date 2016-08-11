using UnityEngine;
using System.Collections;
namespace Main{
	public class Destrutble_Health : MonoBehaviour {
		private Destructble_Master destructble_master;
		public int healht;
		private int startingHealth;
		private bool isExploding = false;
		void OnEnable(){
			SetInitialReferences();
			destructble_master.EventDeductHealth += DeductHealt;
		}

		void OnDisable(){
			destructble_master.EventDeductHealth -= DeductHealt;
		}

		void SetInitialReferences(){
			startingHealth = healht;
			destructble_master = GetComponent<Destructble_Master> ();
		}
		void DeductHealt(int amount){
			healht -= amount;
			CheckIfHealthLow();
			//print ("Current " + healht + " Amoutn " + amount + "Starting " + startingHealth );
			if (healht <=0 && !isExploding) {
				print ("Turning on i sexploding");
				isExploding = true;


				destructble_master.CallEventDestroyMe();
			}
		}
		void CheckIfHealthLow(){
			if (healht<= startingHealth /2) {
				destructble_master.CallEventHealthLow ();
			}
		}
	}
}
