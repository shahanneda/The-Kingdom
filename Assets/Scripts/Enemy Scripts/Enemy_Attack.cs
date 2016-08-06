using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_Attack : MonoBehaviour {
		private Enemy_Master enemy_master;
		private Transform atackTarget;
		private Transform myTransform;
		public float atackRate = 3;
		private float nextAtack;
		private float atackRange = 3.1f;
		private int atackDammage = 20;
		void OnEnable(){
			SetInitialReferences();
			enemy_master.EventEnemyDie += DisableThis;
			enemy_master.EnemyEventSetNavTarget += SetAttackTarget;
		}

		void OnDisable(){
			enemy_master.EventEnemyDie -= DisableThis;
			enemy_master.EnemyEventSetNavTarget -= SetAttackTarget;
		}

		void SetInitialReferences(){
			enemy_master = GetComponent<Enemy_Master> ();
			myTransform = transform;
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			TryToAtack ();
		}
		void SetAttackTarget(Transform target){
			atackTarget = target;
		}
		void TryToAtack(){
			if (atackTarget != null) {
				if (Time.time > nextAtack) {
					nextAtack = Time.time + atackRate;
					if (Vector3.Distance(myTransform.position,atackTarget.position) <= atackRange) {
						Vector3 lookAtTarget = new Vector3 (atackTarget.position.x, myTransform.position.y,atackTarget.position.z);
						myTransform.LookAt (lookAtTarget);
						enemy_master.CallEventEnemyAttack();
						enemy_master.isOnRoute = false;
					}
				}
			}
		}
		public void OnEnemyAttack(){
			if (atackTarget != null) {
				if (Vector3.Distance(myTransform.position,atackTarget.position) <= atackRange && 
					atackTarget.GetComponent<Player_Master>()) {
					Vector3 toOther = atackTarget.position - myTransform.position;
					if (Vector3.Dot(toOther, myTransform.forward)> 0.5f) {
						atackTarget.GetComponent<Player_Master> ().CallEventPlayerHealthDeduction (atackDammage);
					}
				}
			}
		}
		void DisableThis(){
			this.enabled = false;
		}
	}
}
