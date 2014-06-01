using UnityEngine;
using System.Collections;

public class Attack : ScriptableObject {
	public enum Status {Neutral, Stunned, Slowed};
	
	public string attackName = "Untitled";
	public Status statusEffect = Status.Neutral;
	public static int damage = 10;

	public int attackSpeed = 2;
	public float lastAttack;


	void Awake(){
		lastAttack = Time.time;
	}


	public virtual void MeleeAttack(Transform attackSource,Transform attackTarget){
		if (attackTarget != null){
			if (Vector3.Distance(attackSource.position, attackTarget.position) <= 1.5 && lastAttack <= Time.time - attackSpeed){
				ApplyDamage(attackTarget, attackSource);
			}
		}
	}

	public virtual void ApplyDamage(Transform target, Transform source = null, int multiplier = 1){

		target.GetComponent<UnitController>().health -= damage * multiplier;
		
	}



}
