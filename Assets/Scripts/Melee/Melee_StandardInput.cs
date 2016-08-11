using UnityEngine;
using System.Collections;
namespace Main{
	public class Melee_StandardInput : MonoBehaviour {
		private Melee_Master melee_master;
		private float nextSwing;
		public string atackButtonName;
		void OnEnable(){
			SetInitialReferences();
		}

		void OnDisable(){

		}

		void SetInitialReferences(){
			melee_master = GetComponent<Melee_Master> ();
		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			CheckIfWeaponShouldAttack ();
		}
		void CheckIfWeaponShouldAttack(){
			if (Time.timeScale > 0 && transform.root.CompareTag(GameManager_References.PlayerTag) && !melee_master.isInUse) {
				if (Input.GetButton(atackButtonName) && Time.time > nextSwing) {
					nextSwing = melee_master.SwingRate + Time.time;
					melee_master.isInUse = true;
					melee_master.CallEventPlayerInput();
				}
			}
		}
	}
}
