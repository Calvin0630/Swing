using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody rBody;
    public float walkSpeed;
    Vector3 walkDir;
    //an angle representing the angle that the camera is turned on the xz plane
    float cameraAngle;
	// Use this for initialization
	void Start () {
        rBody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        walkDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        print("CameraDir: " + ThirdPersonCamera.cameraDir);
        //camera angle = cos(^-1) z/hypoteneuse
        cameraAngle = 
        print("Camera Angle: " + cameraAngle);
        rBody.AddForce(walkSpeed * walkDir);
        if (Input.GetButton("Fire1")) print("Hello");
	}
}
