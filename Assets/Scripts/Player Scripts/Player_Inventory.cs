using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
namespace Main{
	public class Player_Inventory : MonoBehaviour {
		public Transform InventoryPlayerParent;
		public Transform InventoryUIParent;
		public GameObject UiButton;

		private Player_Master player_Master;
		private GameManager_ToggleInventoryUI inventoryUiScript;
		private float timeToPlaceInHands = 0.3f;
		private Transform currentlyHeldItem;
		private int counter;
		private string buttonText;
		private List<Transform> listInventory = new List<Transform>();
		void OnEnable(){
			SetInitialReferences ();
			UpdateInventoryListAndUI ();
			CheckIfHandsEmpty ();
			DeactivateAllInventoyItems ();
			player_Master.EventInventoryChanged += UpdateInventoryListAndUI;
			player_Master.EventInventoryChanged += CheckIfHandsEmpty;
			player_Master.EventHandsEmpty += ClearHands;

		}

		void OnDisable(){

			player_Master.EventInventoryChanged -= UpdateInventoryListAndUI;
			player_Master.EventInventoryChanged -= CheckIfHandsEmpty;
			player_Master.EventHandsEmpty -= ClearHands;

		}
		void SetInitialReferences(){
			inventoryUiScript = GameObject.Find ("GameManager").GetComponent<GameManager_ToggleInventoryUI> ();
			player_Master = GetComponent<Player_Master> ();
		}
		void UpdateInventoryListAndUI(){
			counter = 0;
			listInventory.Clear ();
			listInventory.TrimExcess();
			ClearInventoryUI ();
			foreach (Transform child in InventoryPlayerParent) {
				if (child.CompareTag ("Item")) {
					listInventory.Add (child);
					GameObject go = Instantiate (UiButton) as GameObject;
					buttonText = child.name;
					go.GetComponentInChildren<Text> ().text = buttonText;

					int index = counter;
					go.GetComponent<Button> ().onClick.AddListener (delegate {ActivateInventoryItem(index);	});
					go.GetComponent<Button>().onClick.AddListener(inventoryUiScript.ToggleInventoryUI);
					go.transform.SetParent (InventoryUIParent,false);
					counter++;
				}
			}
		}
		void CheckIfHandsEmpty(){
			if (currentlyHeldItem == null && listInventory.Count > 0) {
				StartCoroutine (PlaceItemInHands(listInventory[listInventory.Count-1]));
			}
		}
		void ClearHands(){
			currentlyHeldItem = null;
		}
		void ClearInventoryUI(){
			foreach (Transform child in InventoryUIParent) {
				Destroy (child.gameObject);
			}
		}
		public void ActivateInventoryItem(int inventoryIndex){
			DeactivateAllInventoyItems ();
			StartCoroutine ("PlaceItemInHands",listInventory[inventoryIndex]);
		}
		void DeactivateAllInventoyItems(){
			foreach (Transform child in InventoryPlayerParent) {
				if (child.CompareTag ("Item")) {
					child.gameObject.SetActive (false);
				}
			}
		}
		IEnumerator PlaceItemInHands(Transform itemTransform){
			yield return new WaitForSeconds (timeToPlaceInHands);
			currentlyHeldItem = itemTransform;
			currentlyHeldItem.gameObject.SetActive (true);
		}

	}
}
