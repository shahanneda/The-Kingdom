using UnityEngine;
using System.Collections;
namespace Main{
	public class GameManager_ToggleCurser : MonoBehaviour {
		private GameManager_Master gamemanager_master;
		private bool isCurserLocked = true;
		void OnEnable(){
			SetInitialReferences ();
			gamemanager_master.MenuToggleEvent += ToggleCurserState;
			gamemanager_master.InventoryToggleUiEvent += ToggleCurserState;
		}
		void OnDisable(){

		}
		void SetInitialReferences(){
			gamemanager_master = GetComponent<GameManager_Master> ();
		}
		void ToggleCurserState(){
			isCurserLocked = !isCurserLocked;	
		}
		void CheckIfCurserShouldBeLocked(){
			if (isCurserLocked) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			} else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			/*
			if (isCurserLocked) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}else 
				Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			*/
		}
		
		// Update is called once per frame
		void Update () {
			CheckIfCurserShouldBeLocked ();
		}
	}
}
