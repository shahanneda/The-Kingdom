using UnityEngine;
using System.Collections;
namespace Main{
	public class Destructble_Sound : MonoBehaviour {
		private Destructble_Master destructble_master;
		public float volume;
		public AudioClip clip;
		void OnEnable(){
			SetInitialReferences();
			destructble_master.EventDestroyMe += PlaySound;

		}

		void OnDisable(){
			destructble_master.EventDestroyMe -= PlaySound;
		}

		void SetInitialReferences(){
			destructble_master = GetComponent<Destructble_Master> ();
		}
		void PlaySound(){
			if (clip != null) {
				AudioSource.PlayClipAtPoint(clip,transform.position,volume);
			}
		}


	}
}
