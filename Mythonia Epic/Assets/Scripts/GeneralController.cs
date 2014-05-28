using UnityEngine;
using System.Collections;

public class GeneralController : MonoBehaviour {

	private GameObject _general;

	private RaycastHit hit;

	//attack Object
	public GameObject skillZeroObject;

	//Maybe other object skills?
	//public GameObject skillThreeObject;

	public GameObject menuPrefab;
	private GameObject menu;

	public bool usingSkill = false;
	private int skillUse;

	public enum statToChange : int{none = 0, attackSpeed, moveSpeed, other};
	public statToChange stat;
	public int statValueChange = 0;
	public int altStatValueChange = 0;

	// Use this for initialization
	void Start () {
		_general = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);
		if (Input.GetMouseButtonDown(0) && hit.transform != null){

				if(hit.transform.tag == "General"){
					menu = Instantiate(menuPrefab, hit.point + (hit.normal * 0.01f), Quaternion.LookRotation(hit.normal + new Vector3(-90,0,0))) as GameObject;
				}

				if (usingSkill == true){
				Skill(skillUse, (int)stat);
				usingSkill = false;
				}
			}

		if(Input.GetMouseButtonUp(0)){
			if(hit.transform != null){
				// add in different commands here
				if(hit.transform.name == "menu_0"){
					usingSkill = true;
					skillUse = 0;
				}
				//buff
				if(hit.transform.name == "menu_1"){
					usingSkill = true;
					skillUse = 1;
				}
				//debuff
				if(hit.transform.name == "menu_2"){
					usingSkill = true;
					skillUse = 2;
				}
				if(hit.transform.name == "menu_3"){
					usingSkill = true;
					skillUse = 3;
				}
			}
			
				Destroy(menu);
			}

	}
	// Usage: Skill( Skill to be used by number, conditional modifier for the skill to user (I.E. Amount to buff/debuff by), Conditional modifier on a skill by skill basis, to modify which values are altered (I.E. setting to 1 will alter attack speed on skill 1));
	void Skill(int skillNumber, int modifier){
		if (skillNumber == 0){
			Instantiate(skillZeroObject, hit.point + new Vector3(0,10,0), Quaternion.identity);
		}

		//buff
		if (skillNumber == 1){
			//Attack Speed
			if (modifier == 1){
			}
			// Move Speed
			if (modifier == 2){
				if (hit.transform != null){
					if (hit.transform.tag == "Unit"){
						foreach( NavMeshAgent Navs in hit.transform.parent.GetComponentsInChildren<NavMeshAgent>()){
							Navs.speed += statValueChange;
						//GetComponent<NavMeshAgent>().speed += amount;
						}
					}
				}
			}
			//other
			if (modifier == 3){
			}
		}

		//Debuff
		if (skillNumber == 2){
			//Attack Speed
			if (modifier == 1){
			}
			// Move Speed
			if (modifier == 2){
				if (hit.transform != null){
					if (hit.transform.tag == "Unit"){
						foreach( NavMeshAgent Navs in hit.transform.parent.GetComponentsInChildren<NavMeshAgent>()){
							Navs.speed -= altStatValueChange;
							//GetComponent<NavMeshAgent>().speed += amount;
						}
					}
				}
			}
			//other
			if (modifier == 3){
			}
		}
		if (skillNumber == 4){
		}
	}



}