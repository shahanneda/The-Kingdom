using UnityEngine;
using System.Collections;
namespace shahan{
	public class CubeEventTrigger : MonoBehaviour {
		private GameManager_EventMaster eventMaster;
		void OnTriggerEnter(Collider coll){
			if (coll.CompareTag("Player")) {
				eventMaster.CallMyGeneralEvent ();
			}


		}
		// Use this for initialization
		void Start () {
			eventMaster = GameObject.Find ("GameManager").GetComponent<GameManager_EventMaster> ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}