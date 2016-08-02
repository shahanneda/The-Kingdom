using UnityEngine;
using System.Collections;
namespace Main{
	public class GameManager_GameOver : MonoBehaviour {
		public GameObject panel;

		private GameManager_Master gamemanager_master;
		// Use this for initialization

		void SetInitialRefrences(){
			gamemanager_master = GetComponent<GameManager_Master> ();
		}
		void OnEnable(){
			SetInitialRefrences ();
			gamemanager_master.GameOverEvent += GameOver;
		}
		void OnDisable(){
			gamemanager_master.GameOverEvent -= GameOver;
		}
		void GameOver(){
			if (!panel) {
				return;
			}
			panel.SetActive (true);
			gamemanager_master.isGameOver = true;
		}
	
	}
}