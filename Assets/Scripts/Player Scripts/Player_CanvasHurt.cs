using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace Main{
	public class Player_CanvasHurt : MonoBehaviour {
		public GameObject HurtCanvas;
		private Player_Master player_master;
		public float timeToKeeppHurtEffect;
		public GameObject[] bloodEffects;
		public Image Redimage;
		private Player_Health player_health;
		// Use this for initialization
		void OnEnable(){
			player_master = GetComponent<Player_Master> ();
			player_master.EventPlayerHealthDeduction += TurnOnHealthEffect;
			player_health = GetComponent<Player_Health> ();
		}
		void OnDisable(){
			player_master.EventPlayerHealthDeduction -= TurnOnHealthEffect;
		}
		void TurnOnHealthEffect(int dummy){
			if(player_health.playerHealth != 0 ){
				Color r_color = Redimage.color;
				float i = 100 - player_health.playerHealth;
				i -= 50;
				if (i < 0) {
					i = 0;
				}
				r_color.a = i/100;

				Redimage.color = r_color;
			}
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
