using UnityEngine;
using System.Collections;

public class ThrowGrenade : MonoBehaviour {
	public GameObject Grenade;
	public float propulsionForce;
	float fireRate = 0.3f;
	float nextFire;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1")) {
			InstantiateGrenade();
		}
	}
	void InstantiateGrenade(){
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;		
			GameObject grenade = Instantiate (Grenade, transform.TransformPoint (0, 0, 0.5f), transform.rotation) as GameObject;
			Destroy (grenade, 5);
			grenade.GetComponent<Rigidbody> ().AddForce (transform.forward * propulsionForce, ForceMode.Impulse);
		}
	}
}
