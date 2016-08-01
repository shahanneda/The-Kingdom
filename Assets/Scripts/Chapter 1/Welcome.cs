using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Shahan {
public class Welcome : MonoBehaviour {
	
		private Text welcomeText;
		public string TextOne;
		public GameObject Panel;
		void Awake(){
			welcomeText = GameObject.FindGameObjectWithTag ("Welcome Text").GetComponent<Text>();
		}
		// Use this for initialization
		void Start () {
			//Invoke ("disableCanves", 3);
			SetText ();
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		public void SetText(){
			welcomeText.text = TextOne;
			StartCoroutine ("disableCanves");
		}
		IEnumerator disableCanves(){
			yield return new WaitForSeconds (1f);
			Panel.SetActive (false);

		}
	}
}
