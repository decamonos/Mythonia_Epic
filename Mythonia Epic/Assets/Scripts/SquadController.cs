using UnityEngine;
using System.Collections;

public class SquadController : MonoBehaviour {
	public enum Race {Fae, Mogorc, Elf, Shetal, Mythonian, Drog};
	public enum Type {Archer, Mage};
	public enum State {Neutral, Stunned, Slowed};
	
	public Race squadRace = Race.Fae;
	public Type squadType = Type.Archer;
	public State squadState = State.Neutral;
	public int squadHealth = 100;

	public bool selected = false;

	public GameObject menuPrefab;
	
	private GameObject menu;

	private Ray ray;
	private RaycastHit hit;
	private Transform currentTarget;
	
	void Start () {

	}
	
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(selected == false && Input.GetMouseButton(0)){
			if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
				currentTarget = hit.transform;
			}
			if (currentTarget.tag == "Unit"){
				if (currentTarget.parent.FindChild("Squad") == transform){
					selected = true;}}
		}
		if(selected == true && Input.GetMouseButton(1)){
			if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
				currentTarget = hit.transform;
			}
			if (currentTarget.tag == "Unit"){
				if (currentTarget.parent.FindChild("Squad") == transform){
					selected = false;}}
		}
		
		if(menu != null && Input.GetMouseButtonUp(0)){
			Destroy(menu);
		}
	
		//if(Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)){
			//if(hit.transform.parent == transform.parent){
				//selected = true;
			//}
		
		if(selected && Input.GetMouseButtonDown(0)){
			if(Physics.Raycast(ray, out hit, Mathf.Infinity)){
				currentTarget = hit.transform;
			}
			if (hit.transform.tag == "Ground"){
			transform.position = hit.point + new Vector3(0, 0.1f, 0);
			menu = Instantiate(menuPrefab, hit.point + (hit.normal * 0.01f), Quaternion.LookRotation(hit.normal + new Vector3(-90,0,0))) as GameObject;
			}}
		}
		


	 void Target(){

		// This is an escape to return the current target if no raycast can be found, without this an error occurs.
	}

}
