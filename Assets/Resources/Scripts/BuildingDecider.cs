using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//stores the last building that entered the swing bubble and the playerController script will get that building when it shoots a web
public class BuildingDecider : MonoBehaviour {
	GameObject lastBuilding;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		//if it is a building
		if(other.tag == "Building") {
            //set it to the last building
			lastBuilding = other.gameObject;
        }
	}
	//returns the last building that entered the collider
	public GameObject GetBuilding() {
		return lastBuilding;
	}
}
