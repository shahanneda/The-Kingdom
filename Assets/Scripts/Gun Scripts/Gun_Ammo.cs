using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_Ammo : MonoBehaviour {
		private Player_Master player_master;
		private Gun_Master gun_master;
		private Player_AmmoBox ammoBox;
		private Animator animator;

		public int clipSize;
		public int CurrentAmmo;
		public string AmmoName;
		public float reloadTime;
		void OnEnable(){
			SetInitialReferences();
			StartingSanityCheck ();
			CheckAmmoStatus ();
			gun_master.EventPlayerInput += DeductAmmo;
			gun_master.EventPlayerInput += CheckAmmoStatus;
			gun_master.EventRequestGunReload += TryToReload ;
			gun_master.EventGunNotUsable += TryToReload;
			gun_master.EventRequestGunReset += ResetGunReloading;
			if (player_master != null) {
				player_master.EventAmmoChanged += UiAmmoUpdateRequast;
			}
			if (ammoBox != null) {
				StartCoroutine(UpdateAmmoUiWhenEnabling());
			}
		}

		void OnDisable(){
			gun_master.EventPlayerInput -= DeductAmmo;
			gun_master.EventPlayerInput -= CheckAmmoStatus;
			gun_master.EventRequestGunReload -= TryToReload ;
			gun_master.EventGunNotUsable -= TryToReload;
			gun_master.EventRequestGunReset -= ResetGunReloading;
			if (player_master != null) {
				player_master.EventAmmoChanged -= UiAmmoUpdateRequast;
			}
		}

		void SetInitialReferences(){
			

			gun_master = GetComponent<Gun_Master> ();
			if (GetComponent<Animator>()) {
				animator = GetComponent<Animator> ();
			}
			if (transform.root.GetComponent<Player_Master> ()) {
				player_master = transform.root.GetComponent<Player_Master> ();
			}
			if (transform.root.GetComponent<Player_AmmoBox>()) {
				ammoBox = transform.root.GetComponent<Player_AmmoBox> ();
			}


		}

		// Use this for initialization
		void Start () {
			SetInitialReferences ();
			StartCoroutine(UpdateAmmoUiWhenEnabling());

			if (player_master != null) {
				player_master.EventAmmoChanged -= UiAmmoUpdateRequast;
			}

		}
		
		void DeductAmmo(){
			CurrentAmmo--;
			UiAmmoUpdateRequast ();
		}
		void TryToReload(){
			
			
			for (int i = 0; i < ammoBox.typesOfAmmo.Count; i++) {
				if (ammoBox.typesOfAmmo[i].AmmoName ==AmmoName ) {
					print ("Trying To Reload");
					if (ammoBox.typesOfAmmo[i].AmmoCurrentCarried > 0 && CurrentAmmo != clipSize && !gun_master.isReloading) {
						
						gun_master.isReloading = true;
						gun_master.isGunLoaded = false;
						if (animator != null) {
							animator.SetTrigger ("Reload");
						}


					} else {
						StartCoroutine (ReloadWithoutAnimation());
					}
					break;
				}

			}

		}
		void CheckAmmoStatus(){
			if (CurrentAmmo <= 0) {
				CurrentAmmo = 0;
				gun_master.isGunLoaded = false;
			} else if (gun_master.isGunLoaded == false) {
				gun_master.isGunLoaded = true;
			}
		}
		void StartingSanityCheck(){
			if (CurrentAmmo > clipSize) {
				CurrentAmmo = clipSize;
			}
		}
		void UiAmmoUpdateRequast(){
			for (int i = 0; i < ammoBox.typesOfAmmo.Count; i++) {
				if (ammoBox.typesOfAmmo[i].AmmoName == AmmoName) {
					gun_master.CallEventAmmoChanged (CurrentAmmo,ammoBox.typesOfAmmo[i].AmmoCurrentCarried);
					break;
				}
			}
		}
		void ResetGunReloading(){
			gun_master.isReloading = false;
			CheckAmmoStatus ();
			UiAmmoUpdateRequast ();
		}
		public void OnReloadComplete(){
			for (int i = 0; i < ammoBox.typesOfAmmo.Count; i++) {
				if (ammoBox.typesOfAmmo[i].AmmoName == AmmoName) {
					int ammoTopUp = clipSize - CurrentAmmo;
					if (ammoBox.typesOfAmmo[i].AmmoCurrentCarried >= ammoTopUp) {
						CurrentAmmo += ammoTopUp;
						ammoBox.typesOfAmmo [i].AmmoCurrentCarried -= ammoTopUp;
					}
					else if (ammoBox.typesOfAmmo[i].AmmoCurrentCarried < ammoTopUp && ammoBox.typesOfAmmo[i] .AmmoCurrentCarried != 0) {
						CurrentAmmo += ammoBox.typesOfAmmo[i].AmmoCurrentCarried;
						ammoBox.typesOfAmmo[i].AmmoCurrentCarried = 0;
					}
					break;
				}
			}
			ResetGunReloading ();
		}
		IEnumerator ReloadWithoutAnimation(){
			yield return new WaitForSeconds (reloadTime);
			OnReloadComplete ();
		}
		IEnumerator UpdateAmmoUiWhenEnabling(){
			yield return new WaitForSeconds (0.5f);
			UiAmmoUpdateRequast ();
		}

			
	}
}
