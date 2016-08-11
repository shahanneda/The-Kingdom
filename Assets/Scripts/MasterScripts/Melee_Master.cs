using UnityEngine;
using System.Collections;
namespace Main{
	public class Melee_Master : MonoBehaviour {

		public delegate void GeneralEventHandler();
		public event GeneralEventHandler EventMeleePlayerInput;
		public event GeneralEventHandler EventMeleeReset;

		public delegate void  MeleeHitEventHandler(Collision hitCollison , Transform hitTransform);
		public event MeleeHitEventHandler EventHit;
		public bool isInUse = false;
		public float SwingRate = 0.5f;

		public void CallEventPlayerInput(){
			if (EventMeleePlayerInput != null) {
				EventMeleePlayerInput();
			}
		}
		public void CallEventMeleeReset(){
			if (EventMeleeReset != null) {
				EventMeleeReset();
			}
		}

		public void CallEventHit(Collision _hitCollison , Transform _hitTransform){
			if (EventHit != null) {
				EventHit(_hitCollison,_hitTransform);
			}
		}

	}
}
