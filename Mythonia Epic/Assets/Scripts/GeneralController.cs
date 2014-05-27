using UnityEngine;
using System.Collections;

public class GeneralController : MonoBehaviour {

	private GameObject _general;

	private RaycastHit hit;

	public GameObject skillZeroObject;

	public GameObject menuPrefab;
	private GameObject menu;

	public bool usingSkill = false;
	private int skillUse;

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
				Skill(skillUse);
				usingSkill = false;
				}
			}

		if(Input.GetMouseButtonUp(0)){
			if(hit.transform != null){
				// add in different commands here
			if(hit.transform.name == "menu_move"){
					usingSkill = true;
					skillUse = 0;
				}}
			
				Destroy(menu);
			}

	}
	void Skill(int skillNumber){
		if (skillNumber == 0){
			Instantiate(skillZeroObject, hit.point + new Vector3(0,10,0), Quaternion.identity);
		}
	}



}