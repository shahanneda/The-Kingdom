using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_NavFlee : MonoBehaviour {
		public bool isFleeing;
		private Enemy_Master enemy_master;
		private NavMeshAgent myAgent;
		private NavMeshHit navHit;
		private Transform myTransform;
		public Transform fleeTarget;
		private Vector3 runPosition;
		private Vector3 directionToplayer;
		public float fleeRange = 25;
		private float nextCheck;
		private float checkRate;
		void OnEnable(){
			SetInitialReferences();
			enemy_master.EventEnemyDie += DisableThis;
			enemy_master.EnemyEventSetNavTarget += SetFleeTarget;
			enemy_master.EnemyHealthLow += IShouldFlee;
			enemy_master.EventEnemyHealthRecovered += IShouldStopFleeing;
		}

		void OnDisable(){
			enemy_master.EventEnemyDie -= DisableThis;
			enemy_master.EnemyEventSetNavTarget -= SetFleeTarget;
			enemy_master.EnemyHealthLow -= IShouldFlee;
			enemy_master.EventEnemyHealthRecovered -= IShouldStopFleeing;
		}

		void SetInitialReferences(){
			myTransform = transform;
			enemy_master = GetComponent<Enemy_Master> ();
			if (GetComponent<NavMeshAgent>()) {
				myAgent = GetComponent<NavMeshAgent>();
			}
			checkRate = Random.Range (0.3f,0.4f);
		}
			
		// Update is called once per frame
		void Update () {
			if (Time.time > nextCheck) {
				nextCheck = Time.time + checkRate;
				CheckIfishouldFlee();
			}
		}
		void SetFleeTarget(Transform target){
			fleeTarget = target;
		}
		void IShouldFlee(){
			isFleeing = true;
			if (GetComponent<EnemyNavPursue>() != null) {
				GetComponent<EnemyNavPursue> ().enabled = false;
				
			}
		}
		void IShouldStopFleeing(){
			isFleeing = false;
			if (GetComponent<EnemyNavPursue>() != null) {
				GetComponent<EnemyNavPursue> ().enabled = true;

			}
		}

		bool FleeTarget(out Vector3 result){
			directionToplayer = myTransform.position - fleeTarget.position;
			Vector3 CheckPos = myTransform.position + directionToplayer;
			if (NavMesh.SamplePosition (CheckPos, out navHit, 1.0f, NavMesh.AllAreas)) {
				result = navHit.position;
				return true;
			} else {
				result = myTransform.position;
				return false;
			}
		}
		void CheckIfishouldFlee(){
			if (isFleeing) {
				if (fleeTarget != null && !enemy_master.isOnRoute && !enemy_master.isNavPaused) {
					if (FleeTarget(out runPosition) && Vector3.Distance(myTransform.position,fleeTarget.position) < fleeRange) {
						myAgent.SetDestination (runPosition);
						enemy_master.CallEventEnemyWalking ();
						enemy_master.isOnRoute = true;
					}

				}
			}
		}
		void DisableThis(){
			this.enabled = false;
		}
	}
}
