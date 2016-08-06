using UnityEngine;
using System.Collections;
namespace Main{
	public class EnemyNavPursue : MonoBehaviour {
		private Enemy_Master enemy_master;
		private NavMeshAgent myAgent;
		private float CheckRate;
		private float nextCheck;
		void OnEnable(){
			SetInitialReferences();
			enemy_master.EventEnemyDie += DisableThis;
		}

		void OnDisable(){
			enemy_master.EventEnemyDie -= DisableThis;
		}
		void DisableThis(){
			if (myAgent != null) {
				myAgent.enabled = false;
			}
			this.enabled = false;

		}

		void SetInitialReferences(){
			enemy_master = GetComponent<Enemy_Master> ();
			if (GetComponent<NavMeshAgent>()) {
				myAgent = GetComponent<NavMeshAgent> ();
			}
			CheckRate = Random.Range (0.1f,0.2f);

		}

		void TryToChaseTarget(){
			if (enemy_master.myTarget != null && myAgent != null && !enemy_master.isNavPaused) {
				myAgent.SetDestination (enemy_master.myTarget.position);

				if (myAgent.remainingDistance > myAgent.stoppingDistance) {
					enemy_master.CallEventEnemyWalking ();
					enemy_master.isOnRoute = true;
				}
			}

		}
		
		// Update is called once per frame
		void Update () {
			if (Time.time > nextCheck) {
				nextCheck = Time.time + CheckRate;
				TryToChaseTarget ();
			}
		}
	}
}
