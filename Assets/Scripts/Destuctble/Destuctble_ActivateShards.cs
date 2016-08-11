using UnityEngine;
using System.Collections;
namespace Main{
	public class Destuctble_ActivateShards : MonoBehaviour {
		private Destructble_Master destructble_master;
		public string shardLayer = "Ignore Raycast";
		public string shardLayerAfter3Seconds = "Item";
		public GameObject shards;
		public bool shouldShardsDisapper;
		private float myMass;
		public float TimeForShardToStay = 10;

		void OnEnable(){
			SetInitialReferences();
			destructble_master.EventDestroyMe += ActivateShards;
		}

		void OnDisable(){
			destructble_master.EventDestroyMe -= ActivateShards;
		}

		void SetInitialReferences(){
			destructble_master = GetComponent<Destructble_Master> ();
			if (GetComponent<Rigidbody>() != null) {
				myMass = GetComponent<Rigidbody> ().mass;
			}
		}

		void ActivateShards()
		{
			if (shards != null) {
				shards.transform.parent = null;
				shards.SetActive (true);
			}
			foreach (Transform shard in shards.transform) {
				shard.tag = "Untagged";
				shard.gameObject.layer = LayerMask.NameToLayer (shardLayer);
				shard.GetComponent<Rigidbody> ().AddExplosionForce (myMass,transform.position,40,0,ForceMode.Impulse);
				//StartCoroutine ("ChangeLayer",shard);
				if (shouldShardsDisapper) {
					Destroy (shard.gameObject,TimeForShardToStay);
				}
			}
		}
		/*
		IEnumerator ChangeLayer(Transform shard){
			yield return new WaitForSeconds (3);
			print ("Chaning");
			shard.gameObject.layer = LayerMask.NameToLayer (shardLayerAfter3Seconds);
		}
		*/
	}
}
