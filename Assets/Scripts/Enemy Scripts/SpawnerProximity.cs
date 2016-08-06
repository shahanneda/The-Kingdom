using UnityEngine;
using System.Collections;
namespace Main{
	public class SpawnerProximity : MonoBehaviour {
		public GameObject ObjectToSpaw;
		public int numberToSpawn;
		public float proximity;
		private float checkrate;
		private float nextCheck;
		private Transform myTransfom;
		private Vector3 SpawnPosition;
		private Transform playerTransform;

		void CheckDistance(){
			if (Time.time > nextCheck) {
				nextCheck = Time.time + checkrate;
				if (Vector3.Distance(myTransfom.position , playerTransform.position) < proximity ) {
					SpawnObjets ();
					this.enabled = false;

				}
			}
		}
		void SpawnObjets(){
			for (int i = 0; i < numberToSpawn; i++) {
				SpawnPosition = myTransfom.position + Random.insideUnitSphere * 5;
				Instantiate (ObjectToSpaw,SpawnPosition,myTransfom.rotation);
			}
		}
		void SetInitialReferences(){
			myTransfom = transform;
			playerTransform = GameManager_References._player.transform;
			checkrate = Random.Range (0.8f, 1.2f);

		}

		// Use this for initialization
		void Start () {
			SetInitialReferences();
		}
		
		// Update is called once per frame
		void Update () {
			CheckDistance ();
		}
	}
}
