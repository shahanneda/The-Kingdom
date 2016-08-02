using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace Main
{

	public class GameManager_GoToMainMEnu : MonoBehaviour {
		private GameManager_Master gamemanager_master;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		void SetInitialRefrences(){
			gamemanager_master = GetComponent<GameManager_Master> ();
		}
		void OnEnable(){
			SetInitialRefrences ();
			gamemanager_master.GoToMenuSceneEvent += GoToMenuScene;
		}
		void OnDisable(){
			gamemanager_master.GoToMenuSceneEvent -= GoToMenuScene;
		}
		void GoToMenuScene(){
			SceneManager.LoadScene (0);
		}
	}
}
