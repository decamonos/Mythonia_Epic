using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {
	public Transform squad;
	public int positionInFormation = 1;
	
	private Transform unitPosition;

	void Start () {
		unitPosition = transform.parent.FindChild("Squad").FindChild("Unit Position " + positionInFormation);
	}
	
	
	void Update () {
		transform.GetComponent<NavMeshAgent>().destination = unitPosition.position;
		
		if(transform.parent.FindChild("Squad").GetComponent<SquadController>().selected){
			transform.FindChild("Selection Marker").renderer.enabled = true;
		}else{
			transform.FindChild("Selection Marker").renderer.enabled = false;
		}
		
	}

	public Transform Target(){
		if(Physics.Raycast(Ray, out hit, Mathf.Infinity)){
			return hit.transform;
		}
		}

}
