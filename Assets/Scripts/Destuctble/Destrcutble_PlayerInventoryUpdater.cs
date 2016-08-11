using UnityEngine;
using System.Collections;
namespace Main{
	public class Destrcutble_PlayerInventoryUpdater : MonoBehaviour {
		private Destructble_Master destructble_master;
		private Player_Master player_master;
		void OnEnable(){
			SetInitialReferences();
			destructble_master.EventDestroyMe += ForcePlayerInventoryUpdate;
		}


		void OnDisable(){
			destructble_master.EventDestroyMe -= ForcePlayerInventoryUpdate;
		}

		void SetInitialReferences(){
			
			destructble_master = GetComponent<Destructble_Master> ();
			if (GetComponent<Item_Master>() == null) {
				Destroy (this);
			}
			player_master = GameManager_References._player.GetComponent<Player_Master> ();
		}

		// Use this for initialization
		void Start () {
			SetInitialReferences ();
		}
		
		void ForcePlayerInventoryUpdate(){
			if (player_master != null) {
				player_master.CallEventInventoryChanged ();
			}
		}
	}
}
