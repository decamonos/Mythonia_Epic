using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {
	
	public float rotateSpeed = 10;
	public bool x = false;
	public bool y = false;
	public bool z = false;
	
	void Update () {
		Vector3 rotation = Vector3.zero;
		
		if(x){
			rotation.x = rotateSpeed;
		}if(y){
			rotation.y = rotateSpeed;
		}if(z){
			rotation.z = rotateSpeed;
		}
		
		transform.Rotate(rotation * rotateSpeed * Time.deltaTime);
	}
}
