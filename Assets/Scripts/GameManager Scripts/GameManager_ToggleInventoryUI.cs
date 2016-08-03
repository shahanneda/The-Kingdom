using UnityEngine;
using System.Collections;
namespace Main{
	public class GameManager_ToggleInventoryUI : MonoBehaviour {
		[Tooltip("Does this gamemode have an inventory???")]public bool hasInventory;
		public GameObject inventoryUi;
		public string toggleInventoryButton;
		private GameManager_Master gamemanager_master;
		// Use this for initialization
		void Start () {
			SetInitialReferences ();
		}
		
		// Update is called once per frame
		void Update () {
			CheckForInventoryUI ();
		}
		void SetInitialReferences(){
			gamemanager_master = GetComponent<GameManager_Master> ();
		}
		public void ToggleInventoryUI(){
			if (inventoryUi != null) {
				inventoryUi.SetActive (!inventoryUi.activeSelf);
				gamemanager_master.isInventoryUiOn = !gamemanager_master.isInventoryUiOn;
				gamemanager_master.CallInventoryToggleUiEvent ();
			}
		}
		void CheckForInventoryUI(){
			if (Input.GetButtonUp(toggleInventoryButton) && !gamemanager_master.isMenuOn && hasInventory) {
				ToggleInventoryUI ();
			}
		}
	}
}
