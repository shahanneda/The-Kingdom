using UnityEngine;
using System.Collections;
namespace shahan
{

	public class GameManager_CurserToggle : MonoBehaviour {
		private bool isCurserLocked= false;
		// Use this for initialization
		void Start () {
			toggleCurserLocked ();
		}
		
		// Update is called once per frame
		void Update () {
			CheckForInput ();
			CheckIfCurserShouldBeLocked ();
		}
		void toggleCurserLocked(){
			isCurserLocked = !isCurserLocked;
		}
		void CheckForInput(){
			if (Input.GetKeyDown(KeyCode.Escape)) {
				toggleCurserLocked ();
			}
		}
		void CheckIfCurserShouldBeLocked(){
			if (isCurserLocked) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			} else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		}
	}

}