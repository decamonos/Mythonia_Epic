using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public enum Status {Neutral, Stunned, Slowed};
	
	public string attackName = "Untitled";
	public Status statusEffect = Status.Neutral;
	public int baseDamage = 10;
	private Camera gameCamera;
	private RaycastHit hit;
	private Ray ray;

	void Awake(){
		ray = gameCamera.ScreenPointToRay(Input.mousePosition);
	}

	public virtual void ApplyDamage(Transform target){
		target.GetComponent<SquadController>().squadHealth -= baseDamage;
	}



}
