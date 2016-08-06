using UnityEngine;
using System.Collections;
namespace Main{
	public class Enemy_Animation : MonoBehaviour {
		private Enemy_Master enemy_master;
		private Animator animator;
		void OnEnable(){
			SetInitialReferences();
			enemy_master.EventEnemyReachedNavTarget += SetAnimationToIdle;
			enemy_master.EventEnemyAtack += SetAnimationToAttack;
			enemy_master.EventEnemyWalking += SetAnimationToWalk;
			enemy_master.EventEnemyDie += DisableAnimator;;
			enemy_master.DeductEnemyHealth += SetAnimationToHit;
		}

		void OnDisable(){
			enemy_master.EventEnemyReachedNavTarget -= SetAnimationToIdle;
			enemy_master.EventEnemyAtack -= SetAnimationToAttack;
			enemy_master.EventEnemyWalking -= SetAnimationToWalk;
			enemy_master.EventEnemyDie -= DisableAnimator;;
			enemy_master.DeductEnemyHealth -= SetAnimationToHit;
		}

		void SetInitialReferences(){
			enemy_master = GetComponent<Enemy_Master> ();
			if (GetComponent<Animator> () != null) {
				animator = GetComponent<Animator> ();
			}

		}
		void SetAnimationToWalk(){
			if(animator != null ){
				if (animator.enabled) {
					animator.SetBool ("IsWalking",true);
				}
			}
		}
		void SetAnimationToIdle(){
			if(animator != null ){
				if (animator.enabled) {
					animator.SetBool ("IsWalking",false);
				}
			}
		}

		void SetAnimationToHit(int dummy){
			if(animator != null ){
				if (animator.enabled) {
					animator.SetTrigger ("Hit");
				}
			}
		}
		void SetAnimationToAttack(){
			if(animator != null ){
				if (animator.enabled) {
					animator.SetTrigger ("Attack");
				}
			}
		}
	
		void DisableAnimator(){
			if(animator != null ){
				animator.enabled = false;
			}
		}

	}
}
