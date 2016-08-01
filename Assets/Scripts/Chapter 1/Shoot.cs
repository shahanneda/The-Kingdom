using UnityEngine;
using System.Collections;
namespace Shahan
{
	

	public class Shoot : MonoBehaviour {
		float fireRate = 0.3f;
		float nextFire;
		public float range;
		private RaycastHit Hit;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			CheckForInput ();
		}
		void CheckForInput(){
			if (Input.GetButton("Fire1")&& Time.time>nextFire) {
				nextFire = Time.time + fireRate;
				print ("Hello");
				Debug.DrawRay (transform.position,transform.forward,Color.red,3f);
				if (Physics.Raycast(transform.TransformPoint(0,0,1),transform.forward,out Hit,range)){
					print(Hit.collider.name);

				}
				
			}
		}
	}
}