using UnityEngine;
using System.Collections;
namespace shahan
{
	

	public class Detection : MonoBehaviour {
		private RaycastHit hit;
		private LayerMask detectionLayer;
		float CheckRate =0.5f;
		float nextCheck;
		float range = 5;
		// Use this for initialization
		void Start () {
			detectionLayer = 1 << 9 | 1<< 8;
		}
		
		// Update is called once per frame
		void Update () {
			DetectItems ();
		}
		void DetectItems(){
			if (Time.time > nextCheck) {
				
				nextCheck = Time.time + CheckRate;
				if (Physics.Raycast(transform.position,transform.forward,out hit , range,detectionLayer)) {
					
				}
			}
		}
	}

}