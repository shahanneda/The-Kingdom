using UnityEngine;
using System.Collections;
namespace Main{
	public class Test_GameOver : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown (KeyCode.O)) {
				GetComponent<GameManager_Master> ().CallGameOverEvent ();
			}
		}
	}
}
