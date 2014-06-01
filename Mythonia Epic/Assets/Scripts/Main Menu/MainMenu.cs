using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
	public GUISkin skin;
	public Texture2D background;
	
	private bool isOptions = false;

	private bool fullscreen;
	
	private Rect[] resolutions = new Rect[10];
	private int resolutionSelection = 0;

	public AudioClip confirm;
	public AudioClip back;
	
	// Use this for initialization
	
	void Awake(){
		fullscreen = Screen.fullScreen;
	
	}
	void Start () {
		Screen.showCursor = true;
		Screen.lockCursor = false;
		
		resolutions[0] = new Rect(0,0,800,600);
		resolutions[1] = new Rect(0,0,1024,768);
		resolutions[2] = new Rect(0,0,1280,720);
		resolutions[3] = new Rect(0,0,1280,800);
		resolutions[4] = new Rect(0,0,1336,768);
		resolutions[5] = new Rect(0,0,1400,1050);
		resolutions[6] = new Rect(0,0,1600,900);
		resolutions[7] = new Rect(0,0,1600,1200);
		resolutions[8] = new Rect(0,0,1920,1080);
		resolutions[9] = new Rect(0,0,1920,1200);
		
		QualitySettings.SetQualityLevel(5);
	}
	
	void OnGUI(){
		if(skin != null){
			GUI.skin = skin;
		}
		
		Debug.Log(resolutionSelection);
		
		GUI.skin.label.alignment = TextAnchor.UpperCenter;
		GUI.skin.button.alignment = TextAnchor.MiddleCenter;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
		GUI.Label(new Rect(Screen.width / 2 - 200, 270, 400, 70), "Mythonia Epic");
		
		if(!isOptions){
			if(GUI.Button(new Rect(Screen.width / 2 - 200, 300, 400, 100), "Play Game")){
				AutoFade.LoadLevel("testing", 0.5f, 0.5f, Color.black);
				audio.PlayOneShot(confirm);
			}if(GUI.Button(new Rect(Screen.width / 2 - 200, 375, 400, 100), "Options")){
				isOptions = true;
				audio.PlayOneShot(confirm);
			}if(GUI.Button(new Rect(Screen.width / 2 - 200, 450, 400, 100), "Exit")){
				audio.PlayOneShot(back);
				Application.Quit();
			}
		}else{
			if(GUI.Button(new Rect(Screen.width / 2 - 200, 580, 400, 50), "Back")){
				audio.PlayOneShot(back);
				isOptions = false;
			}
			
			GUI.Box(new Rect(Screen.width / 2 - 200, 310, 400, 225), "");
			
			GUI.Label(new Rect(Screen.width / 2 - 190, 320, 380, 70), "Resolution");
			GUI.Box(new Rect(Screen.width / 2 - 135, 360, 270, 50), "");
			
			if(GUI.Button(new Rect(Screen.width / 2 - 190, 360, 60, 60), "<") && resolutionSelection - 1 >= 0){
				audio.PlayOneShot(confirm);
				resolutionSelection--;
			}if(GUI.Button(new Rect(Screen.width / 2 + 130, 360, 60, 60), ">") && resolutionSelection + 1 <= resolutions.Length - 1){
				audio.PlayOneShot(confirm);
				resolutionSelection++;
			}
			
			//Resolution Logic
			GUI.skin = null;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			GUI.Label(new Rect(Screen.width / 2 - 135, 365, 270, 25), "Current : " + Screen.width + "x" + Screen.height);
			GUI.Label(new Rect(Screen.width / 2 - 135, 380, 270, 25), "New : " + resolutions[resolutionSelection].width + "x"
																		       + resolutions[resolutionSelection].height);
			
			GUI.skin = skin;
			//END LOGIC
			
			GUI.Label(new Rect(Screen.width / 2 - 190, 420, 380, 70), "Fullscreen");
			GUI.Box(new Rect(Screen.width / 2 - 135, 460, 270, 50), "");
			
			if(GUI.Button(new Rect(Screen.width / 2 - 190, 460, 60, 60), "<")){
				fullscreen = !fullscreen;
				audio.PlayOneShot(confirm);
			}if(GUI.Button(new Rect(Screen.width / 2 + 130, 460, 60, 60), ">")){
				fullscreen = !fullscreen;
				audio.PlayOneShot(confirm);
			}
			
			//Fullscreen Logic
			GUI.skin = null;
			GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			
			string ft = "";
			if(fullscreen){
				ft = "Yes";
			}else{
				ft = "No";
			}
			
			GUI.Label(new Rect(Screen.width / 2 - 135, 460, 270, 50), ft);
			
			GUI.skin = skin;
			//END LOGIC
			
			if(GUI.Button(new Rect(Screen.width / 2 - 200, 540, 400, 50), "Apply")){
				Screen.SetResolution((int)resolutions[resolutionSelection].width, (int)resolutions[resolutionSelection].height, fullscreen);
				audio.PlayOneShot(confirm);
			}
		
		}
	
	}
}