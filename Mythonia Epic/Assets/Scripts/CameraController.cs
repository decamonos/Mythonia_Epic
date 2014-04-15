using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public float movementBorder = 5.0f; //How close in pixels to the edge of the screen till movement begins.
	public float movementSpeed = 2.5f;

	void Start () {
		Screen.showCursor = true;
		Screen.lockCursor = false;
	}
	
	void Update () {
		transform.position += MouseMovement();
	}
	
	Vector3 MouseMovement(){
		Vector3 movement = Vector3.zero;
		
		if(Input.mousePosition.x < movementBorder){
			movement.x = -movementSpeed * Time.deltaTime;
		}if(Input.mousePosition.x > Screen.width - movementBorder){
			movement.x = movementSpeed * Time.deltaTime;
		}if(Input.mousePosition.y < movementBorder){
			movement.z = -movementSpeed * Time.deltaTime;
		}if(Input.mousePosition.y > Screen.height - movementBorder){
			movement.z = movementSpeed * Time.deltaTime;
		}
		
		return movement;
	}
}