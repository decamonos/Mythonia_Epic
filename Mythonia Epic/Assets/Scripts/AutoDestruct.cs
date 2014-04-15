using UnityEngine;
using System.Collections;

public class AutoDestruct : MonoBehaviour {

	public float expireTime = 5.0f;
	
	
	// Use this for initialization
	void Start () {
		StartCoroutine(expireAfterTime(expireTime));
	}
	
	
	IEnumerator expireAfterTime(float time) {
		yield return new WaitForSeconds (time);
		
		Destroy(transform.gameObject);
	}
}