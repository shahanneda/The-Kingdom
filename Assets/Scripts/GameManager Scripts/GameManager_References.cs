using UnityEngine;
using System.Collections;
namespace Main{
	public class GameManager_References : MonoBehaviour {
		public string playerTag;
		public static string PlayerTag;
		public string enemyTag;
		public static string EnemyTag;
		public static GameObject _player;
		void OnEnable(){
			
			_player = GameObject.FindGameObjectWithTag (playerTag);
			PlayerTag = playerTag;
			EnemyTag = enemyTag;
			if (playerTag == "") {
				Debug.LogWarning ("Please type in name of player tag");
			}
			if (enemyTag == "") {
				Debug.LogWarning ("Please type in name of enemy tag");
			}
			if (!_player) {
				Debug.LogWarning ("Please Link Player");
			}
		}
	}
}
