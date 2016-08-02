using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace Main
{
	

public class GameManager_RestartLevel : MonoBehaviour {
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
			gamemanager_master.RestartLevelEvent += RestartLevel;
	}
	void OnDisable(){
			gamemanager_master.RestartLevelEvent -= RestartLevel;
	}
		void RestartLevel(){
			SceneManager.LoadScene (SceneManager.GetActiveScene().name.ToString());
	}
}
}
