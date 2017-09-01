using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
    Rigidbody playerRigidbody;
    GameObject player;
	// Use this for initialization
	void Start () {
        playerRigidbody = transform.GetComponentInParent<Rigidbody>();
        player = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
	}

    private void OnTriggerEnter(Collider other) {

        //if (LayerMask.NameToLayer("Environment") == other.gameObject.layer) print(other.name);
        if(other.tag == "Building") {
            playerRigidbody.AddForce((transform.position - other.gameObject.transform.position).normalized*30);
        }
    }
}
