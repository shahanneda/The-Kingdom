using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_Detection : MonoBehaviour {

		private Enemy_Master enemy_master;
		private Transform  myTransform;
		public Transform head;
		public LayerMask playerLayer;
		public LayerMask sightLayer;
		private float checkRate;
		private float nextCheck;
		private float DetectRadius = 80;
		private RaycastHit hit;
		void OnEnable(){
			SetInitialReferences();
			enemy_master.EventEnemyDie += DisableThis;
		}

		void OnDisable(){
			enemy_master.EventEnemyDie -= DisableThis;
		}

		void SetInitialReferences(){
			enemy_master = GetComponent<Enemy_Master> ();
			myTransform = transform;
			if (head == null) {
				head = myTransform;
			}
			checkRate = Random.Range (0.8f,1.2f);

		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			CarryOutDetection ();
		}
		void DisableThis(){
			this.enabled = false;
		}
		bool CanPotentialTargetBeSeen(Transform target){
			if (Physics.Linecast (head.position, target.position, out hit, sightLayer)) {
				if (hit.transform == target) {
					enemy_master.CallEnemyEventSetNavTarget (target);
					return true;

				}else {
					enemy_master.CallEventEnemyLostTarget ();
					return false;
				}

			} else {
				enemy_master.CallEventEnemyLostTarget ();
				return false;
			}
		}
		void CarryOutDetection(){
			if (Time.time > nextCheck) {
				nextCheck = Time.time + checkRate;

				Collider[] colliders = Physics.OverlapSphere (myTransform.position,DetectRadius,playerLayer);

				if (colliders.Length > 0) {
					foreach (Collider coll in colliders) {
						if (coll.CompareTag(GameManager_References.PlayerTag)) {
							if (CanPotentialTargetBeSeen(coll.transform)) {
								break;
							}	
						}
					}
				} else {
					enemy_master.CallEventEnemyLostTarget ();
				}

			}
		}
	}
}
