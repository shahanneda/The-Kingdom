using UnityEngine;
using System.Collections;
namespace Main{
	public class Melee_Sound : MonoBehaviour {
		private Melee_Master melee_mster;
		private Transform myTransform;
		public float SwingSoundVolume = 0.5f;
		public AudioClip swingSound;
		public float strikeSoundVolume = 0.5f;
		public AudioClip strikeSound;
		void OnEnable(){
			SetInitialReferences();
			melee_mster.EventHit += PlayStrikeSound;
		}

		void OnDisable(){
			melee_mster.EventHit -= PlayStrikeSound;
		}


		void SetInitialReferences(){
			myTransform = transform;
			melee_mster = GetComponent<Melee_Master> ();
		}

		void PlaySwingSound(){
			if (swingSound !=null) {
				AudioSource.PlayClipAtPoint (swingSound,myTransform.position,SwingSoundVolume);
			}
		}
		void PlayStrikeSound(Collision dummy, Transform dumym){
			if (strikeSound !=null) {
				AudioSource.PlayClipAtPoint (strikeSound,myTransform.position,strikeSoundVolume);
			}
		}
	}
}
