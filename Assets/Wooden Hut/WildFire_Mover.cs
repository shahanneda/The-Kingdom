using UnityEngine;
using System.Collections;
namespace Main{
	public class WildFire_Mover : MonoBehaviour {
		public GameObject target;
		void OnEnable(){
			SetInitialReferences();
		}

		void OnDisable(){

		}

		void SetInitialReferences(){

		}

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			float step = 10 * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

		}
	}
}
