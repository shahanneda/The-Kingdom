using UnityEngine;
using System.Collections;
namespace Main{
	public class Destructble_ParticleSpawn : MonoBehaviour {
		private Destructble_Master destructble_master;
		public GameObject partciles;
		void OnEnable(){
			SetInitialReferences();
			destructble_master.EventDestroyMe += Spawn;
		}

		void OnDisable(){
			destructble_master.EventDestroyMe -= Spawn;
		}

		void SetInitialReferences(){
			destructble_master = GetComponent<Destructble_Master> ();
		}
		void Spawn(){
			if (partciles != null) {
				Instantiate (partciles,transform.position,Quaternion.identity);
			}
		}


	}
}
