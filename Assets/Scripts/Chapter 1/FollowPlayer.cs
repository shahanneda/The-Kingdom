using UnityEngine;
using System.Collections;
namespace Shahan{
	public class FollowPlayer : MonoBehaviour {
		public LayerMask detectionLayer;
		private Transform myTransform;
		private NavMeshAgent myAgent;
		private Collider[] hitColliders;
		private float checkRate;
		private float nextCheck;
		private float range = 10;
		// Use this for initialization
		void Start () {
			checkRate = Random.Range (0.8f,1.2f);
			myTransform = transform;
			myAgent = GetComponent<NavMeshAgent> ();

		}

		// Update is called once per frame
		void Update () {
			CheckAndFollow ();
		}
		void CheckAndFollow(){
			if (myAgent.enabled == false) {
				return;
			}
			if (Time.time > nextCheck) {
				nextCheck = Time.time + checkRate;
				hitColliders = Physics.OverlapSphere (myTransform.position,range,detectionLayer);
				if(hitColliders != null){
					myAgent.SetDestination (hitColliders[0].transform.position);
				}
			}
		}
	}
}