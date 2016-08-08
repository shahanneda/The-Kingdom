using UnityEngine;
using System.Collections;
namespace Main{
	public class Gun_Shoot : MonoBehaviour {
		private Gun_Master gun_master;
		private Transform myTransform;
		private Transform camTransform;
		private RaycastHit hit;
		public float Range;
		private float OffsetFactor = 7;
		private Vector3 StartPosition;
		void OnEnable(){
			SetInitialReferences();
			gun_master.EventPlayerInput += OpenFire;
			gun_master.EventSpeedCaptured += SetStartOfShootingPosition;
		}

		void OnDisable(){
			gun_master.EventPlayerInput -= OpenFire;
			gun_master.EventSpeedCaptured -= SetStartOfShootingPosition;
		}

		void SetInitialReferences(){
			gun_master = GetComponent<Gun_Master> ();
			myTransform = transform;
			camTransform = myTransform.parent;
		}

		void OpenFire(){
			Debug.Log("OpenFireCalled");
			if (Physics.Raycast(camTransform.TransformPoint(StartPosition),camTransform.forward,out hit,Range)) {
				gun_master.CallEventShotDefualt (hit.point, hit.transform);
				if (hit.transform.CompareTag(GameManager_References.EnemyTag)) {
					Debug.Log("ShotEnemy");
					gun_master.CallEventShotEnemy (hit.point,hit.transform);

				}
			}
		}
		void SetStartOfShootingPosition(float playerSpeed){
			float Offset = playerSpeed / OffsetFactor;
			StartPosition = new Vector3 (Random.Range (-Offset, Offset), Random.Range (-Offset, Offset), 1);
		}
	}
}
