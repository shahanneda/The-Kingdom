using UnityEngine;
using System.Collections;
namespace Main{
	public class GameManager_PanelInstructionss : MonoBehaviour {
		public GameObject panelIstructions;
		private GameManager_Master gamemanager_master;
		// Use this for initialization
		void Start () {
			gamemanager_master = GetComponent<GameManager_Master> ();
			gamemanager_master.GameOverEvent += SetOffPanelInstruction;
		}
		
		void OnEnable(){

		}
		void OnDisable(){

		}
		void SetOffPanelInstruction(){
			if(panelIstructions){
				panelIstructions.SetActive (false);
			}
		}
	}
}
