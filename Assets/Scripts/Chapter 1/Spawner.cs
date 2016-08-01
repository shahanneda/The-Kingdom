
using UnityEngine;
using System.Collections;
namespace shahan{
	public class Spawner : MonoBehaviour {
		public int numberOfEnemys = 5;
		private float SpawnRadius = 20;
		public GameObject enemy;
		private Vector3 spawnPos;
		private GameManager_EventMaster eventMaster;
		// Use this for initialization
		void OnEnable(){
			SetReferences ();
			eventMaster.myGeneralEvent += Spawn;
		}
		void OnDisable(){
			eventMaster.myGeneralEvent -= Spawn;
		}
		void SetReferences(){
			eventMaster = GameObject.Find ("GameManager").GetComponent<GameManager_EventMaster> ();
		}
		void Start () {
			
			//Spawn ();

		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void Spawn(){
			for (int i = 0; i < numberOfEnemys; i++) {
				spawnPos = transform.position + Random.insideUnitSphere * SpawnRadius;
				Vector3 offsetSpawnPos = new Vector3 (spawnPos.x, 1 , spawnPos.z);
				Instantiate (enemy,offsetSpawnPos,Quaternion.identity);
			}
		}
	}
}