using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SquadController : MonoBehaviour {
	public enum Race {Fae, Mogorc, Elf, Shetal, Mythonian, Drog};
	public enum Type {Archer, Mage};
	public enum State {Neutral, Stunned, Slowed};
	
	public Race squadRace = Race.Fae;
	public Type squadType = Type.Archer;
	public State squadState = State.Neutral;
	public int squadHealth = 100;

	public List<Transform> squad = new List<Transform>();
	public List<Transform> squadTarget = new List<Transform>();
	public bool isAttacking = false;
	public bool attackCheck = false;

	public bool selected = false;

	public GameObject menuPrefab;
	
	private GameObject menu;

	private RaycastHit hit;
	private Transform currentTarget;
	
	private string raycastHitName = "";


	void Start () {
		for (int i = 0; i < transform.parent.childCount; i++){
			currentTarget = transform.parent.GetChild(i).transform;
			if (currentTarget.tag == "Unit"){
				squad.Add(currentTarget);
			}
		}
		//Debug to see if units were getting added properly without adding the squad object
		//foreach(Transform unit in squad){
			//Debug.Log(unit);
		//}
	}
	void Update () {

		Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);
		
		if(hit.transform != null){
			raycastHitName = hit.transform.name;
		}else{
			raycastHitName = "None";
		}
		
		if(Input.GetMouseButtonDown(0) && hit.transform != null){
			if(!selected && hit.transform.tag == "Unit" && hit.transform.parent.FindChild("Squad") == transform){
				selected = true;
			}else if(selected){
				if(hit.transform.tag == "Ground"){
					menu = Instantiate(menuPrefab, hit.point + (hit.normal * 0.01f), Quaternion.LookRotation(hit.normal + new Vector3(-90,0,0))) as GameObject;
				}else if(hit.transform.tag == "Unit" && hit.transform.parent.FindChild("Squad") != transform){
					selected = false;
				}
			}
		}
		
		if(Input.GetMouseButtonUp(0)){
			if(selected && hit.transform.name == "menu_move"){
				transform.position = hit.point + new Vector3(0, 0.1f, 0);
				isAttacking = false;
			}
			if(selected && hit.transform.name == "menu_1"){
				//transform.position = hit.point + new Vector3(0, 0.1f, 0);
				isAttacking = true;
			}
			
			Destroy(menu);
		}
		
		if(Input.GetMouseButtonUp(1) && selected){
			selected = false;
		}

		if (isAttacking == true){

			if (attackCheck == false){
				if(Input.GetMouseButton(0) && hit.transform.tag == "Unit" && hit.transform.GetComponent<UnitController>().isFriendly != true){
					for (int i = 0; i < hit.transform.parent.childCount; i++){
						currentTarget = hit.transform.parent.GetChild(i).transform;
						if (currentTarget.tag == "Unit"){
							squadTarget.Add(currentTarget);
						}
					}
					attackCheck = true;
				}
			}

			if (attackCheck == true){
				//The following line works
				//Debug.Log("Not a DICKINS!");
				//Everything in this for statement magically stops working
				for (int i = 0; i < squadTarget.Count; i++){
					if (squadTarget[i] == null){
						squadTarget.RemoveAt(i);
					}
					if (squadTarget[i] != null){
					transform.GetChild(i).position = squadTarget[i].position;
					squad[i].GetComponent<UnitController>().meleeAttack.MeleeAttack(squad[i], squadTarget[i]);
					}
				}
			}
		}
		else{
			for(int i = 0; i == 9; i++){
				// reassimalate squad pos here
			}
		}

	}



	void OnGUI(){
		GUI.Label(new Rect(10,10, 200, 30), raycastHitName);

	}
}
