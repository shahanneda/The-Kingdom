using UnityEngine;
using System.Collections;
namespace Main{
		public class Enemy_Health : MonoBehaviour {
		private Enemy_NavPause nav_pause;
			private Enemy_Master enemy_master;
			public int Health = 100;
			public float enemyHealthLow;

			void OnEnable(){
				SetInitialReferences ();


			enemy_master.DeductEnemyHealth += DeductHealth;
			enemy_master.EventIncreaseEnemyHealth += IncreaseHealth;
			}

			
			void SetInitialReferences(){
				
			enemy_master = GetComponent<Enemy_Master> ();
			}
			void OnDisable(){
				enemy_master.DeductEnemyHealth -= DeductHealth;
				enemy_master.EventIncreaseEnemyHealth -= IncreaseHealth;
			}
			// Use this for initialization
			

			// Update is called once per frame
		void Update(){
			if (Input.GetKeyUp(KeyCode.Period)) {
				
				enemy_master.CallEventIncreaseEnemyHealth (20);
			}
		}
			void DeductHealth(int healthChange){
				

				Health -= healthChange;

				if (Health <= 0) {
					Health = 0;

				enemy_master.CallCallEventEnemyDie ();


				}
				CheckHealthFraction ();
			}

			void IncreaseHealth(int healthChange){
				Health += healthChange;
				if(Health >= 100){
					Health = 100;
				}
				CheckHealthFraction ();
			}
		void CheckHealthFraction(){

			if (Health <= enemyHealthLow && Health > 0) {
				enemy_master.CallEnemyHealthLow ();
			}
			else if(Health > enemyHealthLow){
				enemy_master.CallEventEnemyHealthRecovered();
			}
		}
			 

		
	
	}

}