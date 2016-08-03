using UnityEngine;
using System.Collections;
namespace Main{
	public class Player_CanvasHurt : MonoBehaviour {
		public GameObject HurtCanvas;
		private Player_Master player_master;
		public float timeToKeeppHurtEffect;
		public GameObject[] bloodEffects;
		// Use this for initialization
		void OnEnable(){
			player_master = GetComponent<Player_Master> ();
			player_master.EventPlayerHealthDeduction += TurnOnHealthEffect;
		}
		void OnDisable(){
			player_master.EventPlayerHealthDeduction -= TurnOnHealthEffect;
		}
		void TurnOnHealthEffect(int dummy){
			if (HurtCanvas != null) {
				StopAllCoroutines ();

				//HurtCanvas.SetActive (true);
				StartCoroutine ("StartBloodEffect");


			}
		}

		IEnumerator StartBloodEffect(){
			for (int i = 0; i < bloodEffects.Length; i++) {
				yield return new WaitForSeconds (timeToKeeppHurtEffect/bloodEffects.Length);
				bloodEffects [i].SetActive(true);
				if (i != 0) {
					bloodEffects [i-1].SetActive(false);
				}
			}
		}
		/*
		IEnumerator StartBloodEffect(){
			yield return new WaitForSeconds (timeToKeeppHurtEffect/ bloodEffects.Length);
			HurtCanvas.SetActive (false);
		}
*/
	}
}
