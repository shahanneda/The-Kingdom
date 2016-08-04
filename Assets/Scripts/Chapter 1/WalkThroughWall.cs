using UnityEngine;
using System.Collections;
namespace shahan
{
	

	public class WalkThroughWall : MonoBehaviour {
		private GameManager_EventMaster eventMaster;
		private Color myColor = new Color (0.5f,1,0.5f,0.3f);
		void OnEnable(){
			SetRefrenses();
			eventMaster.myGeneralEvent += SetNotSolid;
		}
		void SetRefrenses(){
			eventMaster = GameObject.Find ("GameManager").GetComponent<GameManager_EventMaster>();
		}
		void OnDisable(){
			
		}
		public void SetNotSolid(){
			
			gameObject.layer = LayerMask.NameToLayer ("Not Solid");
			gameObject.GetComponent<Renderer> ().material.SetColor ("_Color",myColor);
		}
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
