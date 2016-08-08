using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_Sounds : MonoBehaviour {
		private Gun_Master gun_master;
		private Transform mytransform;
		public float shootvolume = 0.4f;
		public float reloadVolume = 0.5f;
		public AudioClip[] ShootSound;
		public AudioClip reloadSound;

		void OnEnable(){
			SetInitialReferences();
			gun_master.EventPlayerInput += PlayShootSound;

		}

		void OnDisable(){
			gun_master.EventPlayerInput -= PlayShootSound;
		}

		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
			mytransform = transform;
		}
		void PlayShootSound(){
			if (ShootSound.Length > 0 ) {
				int index = Random.Range (0,ShootSound.Length);
				AudioSource.PlayClipAtPoint (ShootSound[index],mytransform .position,shootvolume);
			}

		}
		public void PlayReloadSound ()//Called By Reload Animation
		{

			if (reloadSound != null) {
				AudioSource.PlayClipAtPoint (reloadSound,mytransform.position,reloadVolume);
			}
		}
	}
}
