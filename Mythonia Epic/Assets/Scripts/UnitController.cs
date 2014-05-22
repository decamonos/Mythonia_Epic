using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {
	public Transform squad;
	public int positionInFormation = 1;
	
	private Transform unitPosition;

	private Ray ray;
	private RaycastHit hit;
	private Camera gameCamera;

	private Transform currentTarget;

	void Start () {
		gameCamera = Camera.main;
		ray = gameCamera.ScreenPointToRay(Input.mousePosition);
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
		if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
			return hit.transform;
		}
		// This is an escape to return the current target if no raycast can be found, without this an error occurs.
		return currentTarget;
		}

}
