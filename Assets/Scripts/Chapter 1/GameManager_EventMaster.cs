using UnityEngine;
using System.Collections;
namespace shahan {
	

	public class GameManager_EventMaster : MonoBehaviour {
		public delegate void GeneralEvent();
		public event GeneralEvent myGeneralEvent;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		public void CallMyGeneralEvent(){
			if (myGeneralEvent != null) {
				myGeneralEvent ();
			}
		}

	}
}
