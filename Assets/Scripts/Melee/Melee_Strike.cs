using UnityEngine;
using System.Collections;
namespace Main{
	public class Melee_Strike : MonoBehaviour {
		private Melee_Master mm;
		public int Dmg = 25;
		private float nextSwingTime;
		private Item_Master item_master;
		void SetInitialReferences(){
			if (GetComponent<Item_Master>() != null) {
				item_master = GetComponent<Item_Master> ();
			}
		}
		void OnEnable(){
			SetInitialReferences ();
			if (item_master != null) {
				item_master.EventObjectThrow += ResetMelee;
			}
		}
		void OnDisable(){
			item_master.EventObjectThrow -= ResetMelee;
		}
		// Use this for initialization
		void Start () {
			SetInitialReferences ();
			mm = GetComponent<Melee_Master> ();


		}
		void OnCollisionEnter(Collision coll){
			if (coll.gameObject != GameManager_References._player && mm.isInUse && Time.time > nextSwingTime) {
				nextSwingTime = Time.time + mm.SwingRate;
				coll.transform.SendMessage ("ProcessDamage",Dmg,SendMessageOptions.DontRequireReceiver);
				mm.CallEventHit (coll,coll.transform);
			}
		}
		void ResetMelee(){
			mm.isInUse = false;
		}
			

	}
}
