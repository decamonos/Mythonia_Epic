using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Camera gameCamera;
	public float clickMovementSpeed = 3.0f;
	public float mouseMovementSpeed = 3.0f;
	public float keyboardMovementSpeed = 5.0f;
	public float screenBoundary = 10.0f;
	public int groundLayer = 9;
	
	private float desiredX;
	private int layerMask;
	

	void Start () {
		Screen.showCursor = true;
		Screen.lockCursor = false;
		if(gameCamera == null){gameCamera = Camera.main;}
		desiredX = gameCamera.transform.position.x;
		layerMask = 1 << groundLayer;
	}
	
	void Update () {
		ClickMovement();
		MouseMovement();
		KeyboardMovement();
		
		Vector3 desiredPosition = gameCamera.transform.position;
		desiredPosition.x = Mathf.Lerp(desiredPosition.x, desiredX, clickMovementSpeed * Time.deltaTime);
		gameCamera.transform.position = desiredPosition;
	}
	
	void ClickMovement(){
		RaycastHit hit;
		
		if(Input.GetMouseButtonUp(2) &&  Physics.Raycast(gameCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask)){
			if(!Physics.Raycast(gameCamera.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, ~layerMask)){
				desiredX = hit.point.x;
			}
		}
	}
	
	void MouseMovement(){
		if(Input.mousePosition.x < screenBoundary){desiredX -= mouseMovementSpeed * Time.deltaTime;}
		if(Input.mousePosition.x > Screen.width - screenBoundary){desiredX += mouseMovementSpeed * Time.deltaTime;}
	}
	
	void KeyboardMovement(){
		if(Input.GetKey(KeyCode.A)){desiredX -= keyboardMovementSpeed * Time.deltaTime;}
		if(Input.GetKey(KeyCode.D)){desiredX += keyboardMovementSpeed * Time.deltaTime;}
	}
}