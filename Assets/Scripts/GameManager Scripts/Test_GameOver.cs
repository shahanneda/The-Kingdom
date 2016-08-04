using UnityEngine;
using System.Collections;
namespace Main{
	public class Test_GameOver : MonoBehaviour {
		private Player_Master player_master;
		// Use this for initialization
		void Start () {
			player_master = GameManager_References._player.GetComponent<Player_Master>();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetKeyDown (KeyCode.O)) {
				
				player_master.CallEventPlayerHealthDeduction (1);
			}
		}
	}
}
