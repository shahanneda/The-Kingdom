using UnityEngine;
using System.Collections;
namespace Main{
	public class Item_Sounds : MonoBehaviour {
		public float DefaultVolume;
		private Item_Master item_master;
		public AudioClip ThrowSound;
		public AudioClip Pickupsound;
		void OnEnable(){
			SetInitialReferences();
			item_master.EventObjectPickup += PlayPickupSound;
			item_master.EventObjectThrow += playThrowSound;
		}

		void OnDisable(){
			item_master.EventObjectPickup -= PlayPickupSound;
			item_master.EventObjectThrow -= playThrowSound;
		}

		void SetInitialReferences(){
			item_master = GetComponent<Item_Master> ();
		

		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void playThrowSound(){
			if (ThrowSound != null) {
				AudioSource.PlayClipAtPoint (ThrowSound,transform.position);
			}

		}
		void PlayPickupSound(){
			if (Pickupsound != null) {
				AudioSource.PlayClipAtPoint (Pickupsound,transform.position);
			}

		}
	}
}
