using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_NavTargetReached : MonoBehaviour {
		private Enemy_Master enemy_master;
		private NavMeshAgent myAgent;
		private float CheckRate;
		private float nextCheck;
		void OnEnable(){
			SetInitialReferences();
			enemy_master.EventEnemyDie += DisableThis;
		}

		void OnDisable(){
			enemy_master.EventEnemyDie -= DisableThis ;
		}

		void SetInitialReferences(){
			enemy_master = GetComponent<Enemy_Master> ();
			if (GetComponent<NavMeshAgent>()) {
				myAgent = GetComponent<NavMeshAgent> ();
			}
			CheckRate = Random.Range (0.3f,0.4f);

		}
		void CheckIfDestinationReached(){
			if (enemy_master.isOnRoute) {
				if (myAgent.remainingDistance < myAgent.stoppingDistance) {
					enemy_master.isOnRoute = false;
					enemy_master.CallEventEnemyReachedNavTarget();
				}
			}
		}
		void DisableThis(){
			this.enabled = false;
		}
		
		// Update is called once per frame
		void Update () {
			if (Time.time > nextCheck) {
				nextCheck = Time.time + CheckRate;
				CheckIfDestinationReached ();
			}
		}
	}
}
