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
	
	void Start () {
	
	}
	
	void Update () {
		RaycastHit hit;
		
		if(selected && Input.GetMouseButtonUp(1)){
			selected = false;
		}
	
		if(Input.GetMouseButtonUp(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)){
			if(hit.transform.parent == transform.parent){
				selected = true;
			}
			
			if(selected && hit.transform.tag == "Ground"){
				transform.position = hit.point + new Vector3(0, 0.1f, 0);
			}
		}
	}
}
