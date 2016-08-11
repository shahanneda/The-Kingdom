using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_NavPause : MonoBehaviour {
		private NavMeshAgent myAgent;
		private Enemy_Master enemy_master;
		private float pauseTime = 1 ;
		void OnEnable(){
			SetInitialReferences();
			enemy_master.EventEnemyDie += DisableThis;
			enemy_master.DeductEnemyHealth += PauseNavMeshAgent;;
		}

		void OnDisable(){
			enemy_master.EventEnemyDie -= DisableThis;
			enemy_master.DeductEnemyHealth -= PauseNavMeshAgent;;
		}

		void SetInitialReferences(){
			enemy_master = GetComponent<Enemy_Master> ();
			if (GetComponent<NavMeshAgent>()) {
				myAgent = GetComponent<NavMeshAgent> ();
			}
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void PauseNavMeshAgent(int dummy){
			if (myAgent != null && myAgent.enabled) {
				myAgent.ResetPath ();
				enemy_master.isNavPaused = true ;
			
				StartCoroutine ("RestartNavMeshAgent");


			}
		}
		IEnumerator RestartNavMeshAgent(){
			yield return new WaitForSeconds (pauseTime);
			enemy_master.isNavPaused = false;
		}
		void DisableThis(){
			StopAllCoroutines ();
		}
	}
}
