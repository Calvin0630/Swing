using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody rBody;
    public float walkSpeed;
    Vector3 walkDir;
	// Use this for initialization
	void Start () {
        rBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        walkDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        print(ThirdPersonCamera.cameraDir);
        rBody.AddForce(walkSpeed * walkDir);
        if (Input.GetButton("Fire1")) print("Hello");
	}
}
