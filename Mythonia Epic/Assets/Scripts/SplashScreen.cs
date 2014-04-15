using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	
	public float time;
	public string level;
	
	
	void Start () {
		Screen.showCursor = false;
		Screen.lockCursor = true;
		StartCoroutine(wait());
	}
	
	// Use this for initialization
	IEnumerator wait () {
		yield return new WaitForSeconds(time);
		
		AutoFade.LoadLevel(level, 0.5f, 0.5f, Color.black);
	}

}
