using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour {

	public AudioClip grunt;

	public Transform squad;
	public int positionInFormation = 1;
	
	private Transform unitPosition;

	private Ray ray;
	private RaycastHit hit;
	private Camera gameCamera;

	public int health = 100;

	public Attack meleeAttack;

	public bool isFriendly = false;

	public bool autoRetaliate = true;
	void Start () {
		meleeAttack = ScriptableObject.CreateInstance<Attack>();
		gameCamera = Camera.main;
		unitPosition = transform.parent.FindChild("Squad").FindChild("Unit Position " + positionInFormation);
	}
	
	
	void Update () {

		if ( health <= 0){
			Destroy(gameObject);
			Destroy(unitPosition.gameObject);
		}

		Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);

		transform.GetComponent<NavMeshAgent>().destination = unitPosition.position;
		
		if(transform.parent.FindChild("Squad").GetComponent<SquadController>().selected){
			transform.FindChild("Selection Marker").renderer.enabled = true;
		}else{
			transform.FindChild("Selection Marker").renderer.enabled = false;
		}
		
	}


	

}
