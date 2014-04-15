using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class PlayerCommand : MonoBehaviour {
	public List<GameObject[]> unitsStore = new List<GameObject[]>();

	public bool isMenu = false;
	private GameObject[] unitSpawns;

	//Mythonian Units
	public GameObject unitArcher;
	public GameObject unitMage;
	

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Use this for initialization
	void Start () {
		unitSpawns = GameObject.FindGameObjectsWithTag("Unit_Spawn");
		if (unitSpawns == null){
			isMenu = true;
		}


		unitsStore.Add( new GameObject[9]);
		unitsStore.Add( new GameObject[9]);
		unitsStore[0][0] = unitMage;
		unitsStore[0][1] = unitMage;
		unitsStore[0][2] = unitMage;
		unitsStore[0][3] = unitMage;
		unitsStore[1][0] = unitArcher;
		unitsStore[1][1] = unitArcher;
		unitsStore[1][2] = unitArcher;
		unitsStore[1][3] = unitArcher;
		print (unitsStore[0][0].name);

		
		if (isMenu = false){
		
		}
//unitSquads = new GameObject[Mathf.Ceil(UnitsStore.ToArray().Length * 1.0f /10)][10]
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SpawnUnits() {
		//Finds all spawn points and spawns available units


	}
}

