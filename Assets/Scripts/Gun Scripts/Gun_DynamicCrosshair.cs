using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_DynamicCrosshair : MonoBehaviour {
		private Gun_Master gun_master;
		public Transform canvasDynamicCrosshhair;
		private Transform playerTransform;
		private Transform weaponCamara;
		private float PlayerSpeed;
		private float nextCaptureInerval;
		private float captureInterval = 0.3f;
		private Vector3 LastPostion;
		public Animator CrosshairAnimator;
		public string weaponCamaraName;

		void CapturePlayerSpeed(){
			if (Time.time > nextCaptureInerval) {
				nextCaptureInerval = Time.time + captureInterval;
				PlayerSpeed = (playerTransform.position - LastPostion).magnitude / captureInterval;
				LastPostion = playerTransform.position;
				gun_master.CallEventSpeedCaptured (PlayerSpeed);
			}
		}
		void ApplySpeedToAnimations(){
			if (CrosshairAnimator != null) {
				CrosshairAnimator.SetFloat ("Speed",PlayerSpeed);
			}
		}
		void FindWeaponCamara(Transform transformToSearch){
			
			if (transformToSearch != null) {
				if (transformToSearch.name == weaponCamaraName) {
					weaponCamara = transformToSearch;
					return;
				}
				foreach (Transform item in transformToSearch) {
					FindWeaponCamara (item);
				}
			}
		}
		void SetCamaraOnDynamicCrosshairCanvas(){
			
			if (canvasDynamicCrosshhair != null && weaponCamara != null) {
				
				canvasDynamicCrosshhair.GetComponent<Canvas> ().renderMode = RenderMode.ScreenSpaceCamera;
				canvasDynamicCrosshhair.GetComponent<Canvas> ().worldCamera = weaponCamara.GetComponent<Camera> ();
			}
		}
		void SetPlaneDistanceOnDynamicCrosshair(){
			if (canvasDynamicCrosshhair != null ) {
				canvasDynamicCrosshhair.GetComponent<Canvas> ().planeDistance = 1;
			}
		}


		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
			playerTransform = GameManager_References._player.transform;
			FindWeaponCamara (playerTransform);
			SetCamaraOnDynamicCrosshairCanvas ();
			SetPlaneDistanceOnDynamicCrosshair ();

		}

		// Use this for initialization
		void Start () {
			SetInitialReferences();
			playerTransform = GameManager_References._player.transform;
			FindWeaponCamara (playerTransform);
			SetCamaraOnDynamicCrosshairCanvas ();
			SetPlaneDistanceOnDynamicCrosshair ();
		}
		
		// Update is called once per frame
		void Update () {
			CapturePlayerSpeed ();;
			ApplySpeedToAnimations ();
		}
	}
}
