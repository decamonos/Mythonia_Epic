using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Camera gameCamera;
	public Vector3 offset = new Vector3(0, 4, -9);
	public float clickMovementSpeed = 3.0f;
	public float mouseMovementSpeed = 3.0f;
	public float keyboardMovementSpeed = 5.0f;
	public float screenBoundary = 10.0f;
	public int groundLayer = 9;
	
	private Vector3 desiredPosition;
	private float distance = 0;
	private int layerMask;
	

	void Start () {
		Screen.showCursor = true;
		Screen.lockCursor = false;
		if(gameCamera == null){gameCamera = Camera.main;}
		desiredPosition = gameCamera.transform.position;
		layerMask = 1 << groundLayer;
	}
	
	void Update () {
		ClickMovement();
		MouseMovement();
		KeyboardMovement();
		gameCamera.transform.position = Vector3.Lerp(gameCamera.transform.position, desiredPosition, clickMovementSpeed * Time.deltaTime);
	}
	
	void ClickMovement(){
		RaycastHit hit;
		
		if(Input.GetMouseButtonUp(2) &&  Physics.Raycast(gameCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask)){
			if(!Physics.Raycast(gameCamera.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, ~layerMask)){
				desiredPosition = hit.point + offset;
				distance = Vector3.Distance(gameCamera.transform.position, desiredPosition);
			}
		}
	}
	
	void MouseMovement(){
		if(Input.mousePosition.x < screenBoundary){desiredPosition.x -= mouseMovementSpeed * Time.deltaTime;}
		if(Input.mousePosition.x > Screen.width - screenBoundary){desiredPosition.x += mouseMovementSpeed * Time.deltaTime;}
		if(Input.mousePosition.y < screenBoundary){desiredPosition.z -= mouseMovementSpeed * Time.deltaTime;}
		if(Input.mousePosition.y > Screen.height - screenBoundary){desiredPosition.z += mouseMovementSpeed * Time.deltaTime;}
	}
	
	void KeyboardMovement(){
		if(Input.GetKey(KeyCode.A)){desiredPosition.x -= keyboardMovementSpeed * Time.deltaTime;}
		if(Input.GetKey(KeyCode.D)){desiredPosition.x += keyboardMovementSpeed * Time.deltaTime;}
		if(Input.GetKey(KeyCode.W)){desiredPosition.z += keyboardMovementSpeed * Time.deltaTime;}
		if(Input.GetKey(KeyCode.S)){desiredPosition.z -= keyboardMovementSpeed * Time.deltaTime;}
	}
}