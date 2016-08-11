using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
namespace Main
{
	public class Gun_Ironsight : MonoBehaviour {
        public Camera weaponCam;
        public Vector3 aimPosition;
		private Vector3 normalPosition;
        public GameObject weaponGameObject;
        public string buttonName;
		public string button2Name;
		private Gun_Master gun_master;
		private FirstPersonController fpsController ;
		private float normalWalkSpeed;
		private float NormalRunSpeed;
		void OnEnable () 
		{
			SetInitialReferences ();
		
		}
		void Start(){
			normalPosition = GetComponent<Item_SetPosition> ().item_Local_Position;
			//SetInitialReferences ();
		}
		void SetInitialReferences(){
			if (transform.root.CompareTag(GameManager_References.PlayerTag)) {
				fpsController = transform.root.GetComponent<FirstPersonController> ();
				normalWalkSpeed = fpsController.m_WalkSpeed;
				NormalRunSpeed = fpsController.m_RunSpeed;
			}

			 
			gun_master = GetComponent<Gun_Master> ();

			if(weaponCam == null)
			{
				Debug.LogWarning("Camera not assigned in \"Ironsight\" script. The script will be disabled");
				this.enabled = false;
			}



		}
	
		void Update () 
		{
			if (transform.root.CompareTag(GameManager_References.PlayerTag)) {
				//if (Input.GetMouseButton(1))
				if (Input.GetButton(buttonName) || Input.GetButton(button2Name)  )

				{
					if (!gun_master.isReloading) {
						weaponGameObject.transform.localPosition = Vector3.Lerp(weaponGameObject.transform.localPosition, aimPosition, Time.deltaTime * 8);
						weaponCam.fieldOfView = Mathf.Lerp(weaponCam.fieldOfView, 45, Time.deltaTime * 10);
						Camera.main.fieldOfView = Mathf.Lerp(weaponCam.fieldOfView, 45, Time.deltaTime * 10);
						fpsController.m_RunSpeed = 0;
						fpsController.m_WalkSpeed = normalWalkSpeed / 3;
					}

				}
				else
				{
					weaponGameObject.transform.localPosition = Vector3.Lerp(weaponGameObject.transform.localPosition, normalPosition, Time.deltaTime * 8);
					weaponCam.fieldOfView = Mathf.Lerp(weaponCam.fieldOfView, 60, Time.deltaTime * 10);
					Camera.main.fieldOfView = Mathf.Lerp(weaponCam.fieldOfView, 60, Time.deltaTime * 10);
					if (fpsController != null) {
						fpsController.m_RunSpeed = NormalRunSpeed;
						fpsController.m_WalkSpeed = normalWalkSpeed;
					}

				}
			}
            
        }
	}
}


