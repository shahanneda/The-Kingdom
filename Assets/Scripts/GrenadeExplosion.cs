using UnityEngine;
using System.Collections;

public class GrenadeExplosion : MonoBehaviour {
	private Collider[] hitColliders;
	public float blastRadius;
	public float power;
	public LayerMask blastLayers;

	void OnCollisionEnter(Collision coll){
		Debug.Log (coll.contacts[0].point.ToString());
		StartCoroutine("ExplosionWork",coll.contacts[0].point);
		Renderer rend = GetComponent<Renderer>();
		rend.material.SetColor("_Color", Color.red);

	}
	IEnumerator ExplosionWork(Vector3 point){
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
		hitColliders = Physics.OverlapSphere (point,blastRadius,blastLayers);


		foreach (var coll in hitColliders) {
			Debug.Log (coll.name);
		
			if (coll.GetComponent<Rigidbody>() ) {
				coll.GetComponent<Rigidbody> ().isKinematic = false;
				coll.GetComponent<Rigidbody> ().AddExplosionForce(power,point,blastRadius,1,ForceMode.Impulse);
			}
		}
	}
}
