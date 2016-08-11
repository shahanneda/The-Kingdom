using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_Master : MonoBehaviour {
		public delegate void GeneralEventHandler();
		public event GeneralEventHandler EventPlayerInput;
		public event GeneralEventHandler EventRequestGunReset;
		public event GeneralEventHandler EventGunNotUsable;
		public event GeneralEventHandler EventRequestGunReload;
		public event GeneralEventHandler EventToggleBurstFire;

		public delegate void GunHitEventHandler(Vector3 hitPosition, Transform hitTransform);
		public event GunHitEventHandler EventShotDefualt;
		public event GunHitEventHandler EventShotEnemy;
		public delegate void GunAmmoEventHandler (int CurrentAmmo,int carriedAmmo);
		public event GunAmmoEventHandler EventAmmoChanged;
		public delegate void GunCrosshairEventHandler(float speed);
		public event GunCrosshairEventHandler EventSpeedCaptured;

		public bool isGunLoaded;
		public bool isReloading;

		public void CallEventRequestGunReset(){
			if (EventRequestGunReset !=null) {
				EventRequestGunReset ();
			}
		}
		public void CallEventPlayerInput(){
			if (EventPlayerInput !=null) {
				EventPlayerInput ();
			}
		}public void CallEventGunNotUsable(){
			if (EventGunNotUsable !=null) {
				EventGunNotUsable ();
			}
		}public void CallEventRequestGunReload(){
			if (EventRequestGunReload !=null) {
				EventRequestGunReload ();
			}
		}public void CallEventToggleBurstFire(){
			if (EventToggleBurstFire !=null) {
				EventToggleBurstFire ();
			}
		}public void CallEventShotDefualt(Vector3 hitPosition, Transform hitTransform){
			if (EventShotDefualt !=null) {
				EventShotDefualt (hitPosition,hitTransform);
			}
		}
		public void CallEventShotEnemy(Vector3 hitPosition, Transform hitTransform){
			if (EventShotEnemy !=null) {
				EventShotEnemy (hitPosition,hitTransform);
			}
		}
		public void CallEventAmmoChanged(int CurrentAmmo,int carriedAmmo){
			if (EventAmmoChanged !=null) {
				EventAmmoChanged (CurrentAmmo,carriedAmmo);
			}
		}
		public void CallEventSpeedCaptured(float speed){
			if (EventSpeedCaptured !=null) {
				EventSpeedCaptured (speed);
			}
		}
	}
}
