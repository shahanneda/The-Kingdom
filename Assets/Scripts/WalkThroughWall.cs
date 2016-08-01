using UnityEngine;
using System.Collections;
namespace shahan
{
	

	public class WalkTroughWall : MonoBehaviour {
		void OnEnable(){
			gameObject.layer = LayerMask.NameToLayer ("Not Solid");
		}
		void OnDisable(){
			
		}
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}
