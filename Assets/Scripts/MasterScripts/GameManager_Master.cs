using UnityEngine;
using System.Collections;
namespace Main{
		public class GameManager_Master : MonoBehaviour {
			public delegate void GameManagerEventHandler();
			public event GameManagerEventHandler MenuToggleEvent;
			public event GameManagerEventHandler InventoryToggleUiEvent;
			public event GameManagerEventHandler RestartLevelEvent;
			public event GameManagerEventHandler GoToMenuSceneEvent;
			public event GameManagerEventHandler GameOverEvent;

			public bool isGameOver;
			public bool isInventoryUiOn;
			public bool isMenuOn;
			// Use this for initialization
			public void CallEventMenuToggle(){
			

				if (MenuToggleEvent != null) {
				
					MenuToggleEvent ();
				}
			}
			public void CallInventoryToggleUiEvent(){
				if (InventoryToggleUiEvent != null) {
					InventoryToggleUiEvent ();
				}
			}
			public void CallRestartLevelEvent(){
				if (RestartLevelEvent != null) {
					RestartLevelEvent ();
				}
			}public void CallGoToMenuSceneEvent(){
				if (GoToMenuSceneEvent != null) {
					GoToMenuSceneEvent ();
				}
		}public void CallGameOverEvent(){
				if (GameOverEvent != null) {
					GameOverEvent ();
				}
			
		}
	}
}
