using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_StandardInput : MonoBehaviour {
		private Gun_Master gun_master;
		private float nextAttack;
		public float AtackRate;
		private Transform myTransfom;
		public bool isAutomatic;
		public bool hasBurstFire;

		public bool isBurstFireActive;
		public string AttackButtonName;
		public string ReloadButtonName;
		public string BurstFireButtonName;

		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
			myTransfom = transform;
			gun_master.isGunLoaded = true;

		}

		// Use this for initialization
		void Start () {
			SetInitialReferences();
		}
		
		// Update is called once per frame
		void Update () {
			CheckIfWeaponShouldAttack ();
			CheckForBurstFireToggle ();
			CheckForReloadRequast ();
		}
		void CheckIfWeaponShouldAttack(){
			if (Time.timeScale > 0 && Time.time > nextAttack && transform.root.CompareTag (GameManager_References.PlayerTag)) {
				if (isAutomatic && !isBurstFireActive) {
					if (Input.GetButton(AttackButtonName)) {
						
						AttemptAttack ();
					}
				}
				else if (isAutomatic && isBurstFireActive) {
					if(Input.GetButtonDown(AttackButtonName)){
						
						StartCoroutine (RunBurstFire());

					} 
				}
				else if (!isAutomatic) {
					if(Input.GetButtonDown(AttackButtonName)){
						
						AttemptAttack();
					}
				}
			}
		}
		void AttemptAttack(){
			nextAttack = Time.time + AtackRate;
			if (gun_master.isGunLoaded) {
				
				gun_master.CallEventPlayerInput ();

			} else {
				gun_master.CallEventGunNotUsable ();
			}
		}
		void CheckForReloadRequast(){
			if (Input.GetButtonDown(ReloadButtonName) && Time.timeScale > 0 && myTransfom.root.CompareTag(GameManager_References.PlayerTag)) {
				gun_master.CallEventRequestGunReload ();

			}
		}
		void CheckForBurstFireToggle(){
			if (Input.GetButtonDown(BurstFireButtonName) && Time.timeScale > 0 && 
				myTransfom.root.CompareTag(GameManager_References.PlayerTag)) {

				isBurstFireActive = !isBurstFireActive;
				gun_master.CallEventToggleBurstFire ();
			}
		}
		IEnumerator RunBurstFire(){
			
			AttemptAttack ();
			yield return new WaitForSeconds (AtackRate);

			AttemptAttack ();
			yield return new WaitForSeconds (AtackRate);

			AttemptAttack ();
			yield return new WaitForSeconds (AtackRate);
		}
	}
}
