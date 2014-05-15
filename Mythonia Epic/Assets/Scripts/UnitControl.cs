using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(NavMeshAgent))]

/* I had to rewrite the movement code since there was a few redundant
variables and a missing brace I could not find for the life of me.
this code is a lot more functional and modular. It is stll all placeholder.*/

public class UnitControl : MonoBehaviour {

	private UnitControl[] squadControl;

	//Unit Specific Values

	public bool Champion = false;
	public bool General = false;

	public int health = 100;
	public int attackPower = 50;
	public int attackSpeed = 2;
	private float lastAttack;


	enum status : int { stunned=1, sleep, poisoned, burned };

	public int currentStatus;

	//Combat Values
	public bool isFriendly = false;
	private bool attacking = false;
	public Transform attackSelection;
	public GameObject attackMenu;

	//Movement based values
	public float movementSpeed = 5.0f;
	public bool selected = false;
	public GameObject menu;
	private Transform selectionMarker;
	private bool moving = false;
	private Vector3 targetPoint = Vector3.zero;

	
	void Start(){
		squadControl = transform.parent.GetComponentsInChildren<UnitControl>();
		lastAttack = Time.time;
		selectionMarker = transform.FindChild("Selection Marker");
	}
	
	void Update(){

		if ( currentStatus == (int)status.stunned){
			transform.renderer.material.color = Color.yellow;
		}

		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


		if (health <= 0){
			Destroy(transform.gameObject);
		}


		if(Physics.Raycast( ray, out hit, Mathf.Infinity)){
			if(SelectionCheck(hit)){
				TargetSelection(hit);
				AttackSelection(hit);
			}
		}
		
		if(moving){
			GetComponent<NavMeshAgent>().destination = targetPoint;
		}
		if(attacking && attackSelection != null && lastAttack <= Time.time - attackSpeed){
			if (Vector3.Distance(transform.position, attackSelection.position) <= 1.5){
				ApplyDamage(attackSelection, attackPower);
				transform.renderer.material.color = Color.green;
				lastAttack = Time.time;
			}
		}
	}
	
	bool SelectionCheck(RaycastHit hit){
		if(Input.GetMouseButtonDown(1) && selected){
			foreach (UnitControl control in squadControl){
				control.selected = false;
			}
		}if(Input.GetMouseButtonDown(0) && hit.transform == transform && !selected && isFriendly == true){
			//selected = true;
			foreach (UnitControl control in squadControl){
				control.selected = true;
			}
		}
		
		if(selected){
			selectionMarker.renderer.enabled = true;
		}else{
			selectionMarker.renderer.enabled = false;
		}
		
		return selected;
	}
	
	void TargetSelection(RaycastHit hit){
		if(Input.GetMouseButtonDown(0) && hit.transform.tag == "Ground"){
			moving = true;
			targetPoint = hit.point;
			Instantiate(menu, hit.point + (hit.normal * 0.01f), Quaternion.LookRotation(hit.normal + new Vector3(-90,0,0)));
		}
	}

	void AttackSelection( RaycastHit hit){
		if (Input.GetMouseButtonDown(0) && hit.transform.tag == "Unit" && hit.transform.GetComponent<UnitControl>().isFriendly != true){
			attacking = true;
			moving = true;
			attackSelection = hit.transform;
			targetPoint = hit.transform.position;
			Instantiate(attackMenu, Camera.main.WorldToScreenPoint(hit.point) + (hit.normal * 0.01f), Quaternion.LookRotation(hit.normal + new Vector3(-90,0,0)));
		}
	}
	void ApplyDamage(Transform target, int damage)
	{
		target.GetComponent<UnitControl>().health -= damage;
	}
}