using UnityEngine;
using System.Collections;

public class MeleeAttack : Attack {

	public Transform target;

	private Transform _thisUnit;

	private Ray ray;
	private RaycastHit hit;

	// Use this for initialization
	void Start () {
		//_thisUnit = transform;
		//ray.origin = _thisUnit.position;
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
