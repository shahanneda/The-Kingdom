using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_NavWander : MonoBehaviour {
		private Enemy_Master enemy_master;
		private Transform  myTransform;


		private NavMeshAgent myAgent;
		private float checkRate;
		private float nextCheck;
		private float WanderRange = 40;
		private NavMeshHit navHit;
		private Vector3 WanderTarget;
		void OnEnable(){
			SetInitialReferences();
			enemy_master.EventEnemyDie += DisableThis;
		}

		void OnDisable(){
			enemy_master.EventEnemyDie -= DisableThis;
		}

		void SetInitialReferences(){
			enemy_master = GetComponent<Enemy_Master> ();
			if (GetComponent<NavMeshAgent>()) {
				myAgent = GetComponent<NavMeshAgent> ();
			}
			checkRate = Random.Range (0.3f, 0.4f);
			myTransform = transform;

		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			if (Time.time > nextCheck) {
				nextCheck = Time.time + checkRate;
				CheckIfIShouldWander ();
			}
		}
		void CheckIfIShouldWander(){
			if (enemy_master.myTarget == null && !enemy_master.isOnRoute && !enemy_master.isNavPaused) {
				if(RandomWanderTarget(myTransform.position,WanderRange,out WanderTarget)){
					myAgent.SetDestination (WanderTarget);
					enemy_master.isOnRoute = true;
					enemy_master.CallEventEnemyWalking();
				}
			}
		}
		bool RandomWanderTarget(Vector3 centre,float range,out Vector3 result){
			Vector3 randomPoint = centre + Random.insideUnitSphere * WanderRange;
			print (NavMesh.SamplePosition(randomPoint,out navHit,10f,NavMesh.AllAreas));
			if (NavMesh.SamplePosition(randomPoint,out navHit,3.0f,NavMesh.AllAreas)) {
				
				result = navHit.position;

				return true;

			} else {
				result = centre;
				return false;
			}
		}
		void DisableThis(){
			this.enabled = false;
		}
	}
}
