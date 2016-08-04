using UnityEngine;
using System.Collections;
namespace Main{
	public class ItemThrow : MonoBehaviour {
		private Item_Master item_master;
		private Transform myTransform;
		private Rigidbody myRigidbody;
		private Vector3 throwDirection;
		public bool canBeThrown;
		public string throwButtonName;
		public float ThrowForce;
	

		void SetInitialReferences(){
			item_master = GetComponent<Item_Master> ();

			myTransform = transform;
			myRigidbody = GetComponent<Rigidbody> ();
		}

		// Use this for initialization
		void Start () {
			SetInitialReferences();
		}
		
		// Update is called once per frame
		void Update () {
			CheckForThrowInput ();
		}
		void CheckForThrowInput(){
			if (throwButtonName != null) {
				
				if (canBeThrown && Input.GetButton(throwButtonName) && Time.timeScale > 0 && myTransform.root.CompareTag(GameManager_References.PlayerTag) && gameObject.activeSelf) {
					
					CarryOutThrowActions ();

				}
			}
		}
		void CarryOutThrowActions(){
			throwDirection = myTransform.parent.forward;

			myTransform.SetParent (null);

			item_master.CallEventObjectThrow ();
			HurlItem ();

		}
		void HurlItem(){
			
			myRigidbody.AddForce (throwDirection * ThrowForce, ForceMode.Impulse);
		}

	}
}
