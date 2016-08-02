using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Main{
	public class Player_Health : MonoBehaviour {
		private GameManager_Master gameManager_Master;
		private Player_Master player_master;
		public int playerHealth;
		public Text healthText;
		 
		void OnEnable(){
			SetInitialReferences ();
			SetUI();
			player_master.EventPlayerHealthIncrease += IncreaseHealth;
			player_master.EventPlayerHealthDeduction += DeductHealth;

		}
		void SetInitialReferences(){
			gameManager_Master = GameObject.Find ("GameManager").GetComponent<GameManager_Master> ();
			player_master = GetComponent<Player_Master> ();
		}
		void OnDisable(){
			player_master.EventPlayerHealthIncrease -= IncreaseHealth;
			player_master.EventPlayerHealthDeduction -= DeductHealth;
		}
		// Use this for initialization
		void Start () {
			StartCoroutine ("testHealthDeduction");
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		IEnumerator testHealthDeduction(){
			yield return new WaitForSeconds (4);
			DeductHealth (100);

		}
		void DeductHealth(int healthChange){
			playerHealth -= +healthChange;
			if (playerHealth <= 0) {
				playerHealth = 0;

				gameManager_Master.CallGameOverEvent ();
			} 
		}
		void IncreaseHealth(int healthChange){
			playerHealth += healthChange;
			if(playerHealth >= 100){
				playerHealth = 100;
			}
		}
		void SetUI(){
			if (healthText) {
				healthText.text = playerHealth.ToString ();
			}
		} 
	}
}
