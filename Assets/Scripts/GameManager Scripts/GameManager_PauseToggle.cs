using UnityEngine;
using System.Collections;
namespace Main
{
	
	public class GameManager_PauseToggle: MonoBehaviour {
		private GameManager_Master gamemanager_master;
		private bool isPause;
		void OnEnable(){
			SetInitialReferences ();

			gamemanager_master.MenuToggleEvent += TogglePause;
			gamemanager_master.InventoryToggleUiEvent += TogglePause;
		}
		void OnDisable(){
			gamemanager_master.MenuToggleEvent -= TogglePause;
			gamemanager_master.InventoryToggleUiEvent -= TogglePause;
		}
		void SetInitialReferences(){
			gamemanager_master = GetComponent<GameManager_Master> ();
		}
		void TogglePause(){
			
			if (isPause) {
				Time.timeScale = 1;
				isPause = false;
			} else {
				Time.timeScale = 0;
				isPause = true;
			}
		}

	}
}