using UnityEngine;
using System.Collections;
namespace Main{
	//[RequireComponent (typeof (Item_Tag))]
	//[RequireComponent (typeof (Item_Pickup))]
	//[RequireComponent (typeof (ItemThrow))]
	//[RequireComponent (typeof (Item_Name))]

	public class Item_Master : MonoBehaviour {
		private Player_Master player_master;
		public delegate void GeneralEventHandler ();
		public event GeneralEventHandler EventObjectThrow;
		public event GeneralEventHandler EventObjectPickup;
		public delegate void PickUpActionEventHandler(Transform item);
		public event PickUpActionEventHandler EventPickupAction;

		void OnEnable(){
			SetInitialReferences ();
		}
		void OnDisable(){

		}
		void SetInitialReferences(){
			if(GameManager_References._player != null){
				player_master = GameManager_References._player.GetComponent<Player_Master> ();
			}
		}
		public void CallEventObjectThrow(){
			if (EventObjectThrow != null) {
				EventObjectThrow ();

			}
			//TODO MOVE ISIDE IF
			player_master.CallEventHandsEmpty ();
			player_master.CallEventInventoryChanged();
		}
		public void CallEventObjectPickup(){
			if (EventObjectPickup != null) {
				EventObjectPickup ();

			}
			//TODO MOVE ISIDE IF

			player_master.CallEventInventoryChanged ();

		}
		public void CallEventPickupAction(Transform item){
			if (EventPickupAction != null) {
				EventPickupAction (item);

			}
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
}
