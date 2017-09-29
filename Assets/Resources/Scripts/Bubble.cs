using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
    Rigidbody playerRigidbody;
    GameObject player;
	// Use this for initialization
	void Start () {
        playerRigidbody = transform.parent.GetComponent<Rigidbody>();
        player = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
	}

    private void OnTriggerStay(Collider other) {

        //if there is a building
        if(other.tag == "Building") {
            //add a force away from the building
            playerRigidbody.AddForce(((transform.position - other.gameObject.transform.position).normalized)*5);
        }
    }
}
