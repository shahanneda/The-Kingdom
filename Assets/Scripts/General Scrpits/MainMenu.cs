using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace Main{
	public class MainMenu : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		public void PlayGame(){
			
			SceneManager.LoadScene (1);

		}
		public void Exit(){
			Application.Quit();
		}
	}
}