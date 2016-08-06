using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_Master : MonoBehaviour {
		public Transform myTarget;
		public bool isOnRoute;
		public bool isNavPaused;
		public delegate void GeneralEventHandler();
		public event GeneralEventHandler EventEnemyDie;
		public event GeneralEventHandler EventEnemyWalking;
		public event GeneralEventHandler EventEnemyReachedNavTarget;
		public event GeneralEventHandler EventEnemyAtack;
		public event GeneralEventHandler EventEnemyLostTarget;
		public event GeneralEventHandler EnemyHealthLow;
		public event GeneralEventHandler EventEnemyHealthRecovered;

		public delegate void HealthEventHandler(int health);
		public event HealthEventHandler DeductEnemyHealth;
		public event HealthEventHandler EventIncreaseEnemyHealth;

		public delegate void NavTargetEventHandler(Transform targetTransform);
		public event NavTargetEventHandler EnemyEventSetNavTarget;

		public void	CallDeductEnemyHealth(int Health){
			if (DeductEnemyHealth != null) {
				DeductEnemyHealth (Health);
			}

		}
		public void	CallEventIncreaseEnemyHealth(int Health){
			if (EventIncreaseEnemyHealth != null) {
				EventIncreaseEnemyHealth (Health);
			}

		}
		public void	CallEnemyEventSetNavTarget(Transform Target){
			if (EnemyEventSetNavTarget != null) {
				EnemyEventSetNavTarget (Target);
			}
			myTarget = Target;

		}
		public void	CallCallEventEnemyDie(){
			if (EventEnemyDie != null) {
				EventEnemyDie ();
			}
		}
		public void	CallEnemyHealthLow(){
			if (EnemyHealthLow != null) {
				EnemyHealthLow ();
			}
		}
		public void	CallEventEnemyHealthRecovered(){
			if (EventEnemyHealthRecovered != null) {
				EventEnemyHealthRecovered ();
			}
		}
		public void	CallEventEnemyWalking(){
			if (EventEnemyWalking != null) {
				EventEnemyWalking ();
			}
		}
		public void	CallEventEnemyReachedNavTarget(){
			if (EventEnemyReachedNavTarget != null) {
				EventEnemyReachedNavTarget ();
			}
		}
		public void	CallEventEnemyAttack(){
			if (EventEnemyAtack != null) {
				EventEnemyAtack ();
			}
		}
		public void	CallEventEnemyLostTarget(){
			if (EventEnemyLostTarget != null) {
				EventEnemyLostTarget ();
			}
			myTarget = null;
		}

	}
}
