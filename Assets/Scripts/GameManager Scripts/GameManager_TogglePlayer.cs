using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
namespace Main
{
	

	public class GameManager_TogglePlayer : MonoBehaviour {

		public FirstPersonController fpsC;
		private GameManager_Master gamemanager_master;
		void OnEnable(){
			SetInitialReferences ();
			gamemanager_master.MenuToggleEvent += TogglePlayerControl;
			gamemanager_master.InventoryToggleUiEvent += TogglePlayerControl;
		}
		void OnDisable(){
			gamemanager_master.MenuToggleEvent -= TogglePlayerControl;
			gamemanager_master.InventoryToggleUiEvent -= TogglePlayerControl;
		}
		void SetInitialReferences(){
			gamemanager_master = GetComponent<GameManager_Master> ();
		}
		void TogglePlayerControl(){
			
			if (fpsC) {
				
				fpsC.enabled = !fpsC.enabled;
			}
		}
	}
}