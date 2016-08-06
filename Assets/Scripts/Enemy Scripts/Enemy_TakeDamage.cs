using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_TakeDamage : MonoBehaviour {
		private Enemy_Master enemy_master;
		public int damageMultipier;
		public bool ShouldRemoveCollider;
		void OnEnable(){
			SetInitialReferences();
			enemy_master.EventEnemyDie += RemoveThis;
		}

		void OnDisable(){

		}

		void SetInitialReferences(){
			enemy_master = transform.root.GetComponent<Enemy_Master> ();
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		public void ProcessDamage(int Damage){
			int DamageToApply = Damage * damageMultipier;
			enemy_master.CallDeductEnemyHealth (DamageToApply);
		}
		void RemoveThis(){
			if (ShouldRemoveCollider) {
				if (GetComponent<Collider>() != null) {
					Destroy (GetComponent<Collider>());
				}                                                   
				if (GetComponent<Rigidbody>() != null) {
					Destroy (GetComponent<Rigidbody>());
				}
			}
			Destroy (this);
		}
	}
}
