using UnityEngine;
using System.Collections;
namespace Main
{
	

	public class GameManager_ToggleMenu : MonoBehaviour {
		private GameManager_Master gamemanager_master;
		public GameObject Menu;
		// Use this for initialization
		void Start () {
			ToggleMenu ();
		}
		
		// Update is called once per frame
		void Update () {
			CheckForMenuToggleRequests ();
		}
		void OnEnable(){
			SetInitialRefrences ();
			gamemanager_master.GameOverEvent += ToggleMenu;
		}
		void OnDisable(){
			gamemanager_master.GameOverEvent -= ToggleMenu;
		}
		void SetInitialRefrences(){
			gamemanager_master = GetComponent<GameManager_Master> ();
		}
		void ToggleMenu(){
			if (Menu != null) {
				Menu.SetActive (!Menu.activeSelf);
				gamemanager_master.isMenuOn = !gamemanager_master.isMenuOn;
				gamemanager_master.CallEventMenuToggle ();

			} else
				Debug.LogWarning ("You need to assign a UI MENU in the inspector!");
		}
		void CheckForMenuToggleRequests(){
			if (Input.GetKeyUp(KeyCode.Escape) && !gamemanager_master.isGameOver && !gamemanager_master.isInventoryUiOn) {
				
				ToggleMenu ();
			}

		}

	}
}
