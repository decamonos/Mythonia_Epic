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

	private RaycastHit hit;
	private Transform currentTarget;
	
	private string raycastHitName = "";
	
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
			}
			
			Destroy(menu);
		}
		
		if(Input.GetMouseButtonUp(1) && selected){
			selected = false;
		}
	}
	
	
	void OnGUI(){
		GUI.Label(new Rect(10,10, 200, 30), raycastHitName);
	}
}
