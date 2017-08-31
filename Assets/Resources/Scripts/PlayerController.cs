using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody rBody;
    public float walkSpeed;
    Vector3 inputDir;
    Vector3 walkDir;
    GameObject projectilePrefab;
    //an angle representing the angle that the camera is turned on the xz plane
    float cameraAngle;
    //the point where the "web" hits the building. the hit distance is zero if it's not attached.
    RaycastHit grapplingPoint;
    public float grapplingForce;
    //a line renderer that 
	// Use this for initialization
	void Start () {
        rBody = this.GetComponent<Rigidbody>();
        projectilePrefab = Resources.Load("Prefab/Projectile") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        inputDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //forward is a unit vector in the xz plane that represents the players forward direction 
        Vector3 forward = ThirdPersonCamera.cameraDir;
        forward.y = 0;
        forward = forward.normalized;
        //right is a unit vector that is 90 degrees to the right of forward if you are looking down on the xz plane.
        Vector3 right = Vector3.Cross(Vector3.up, forward);
        right = right.normalized;
        //calculate walkDir from the input and the perspective of the player.
        walkDir = inputDir.z * forward + inputDir.x * right;
        rBody.AddForce(walkSpeed * walkDir);
        if(Input.GetButtonDown("Jump")) {
            print("Jump");
            rBody.AddForce(300 * Vector3.up);
        }
        

        if(Input.GetButtonDown("Fire1")) {
            Vector3 shotDir = (ThirdPersonCamera.cameraDir + (0.33f * Vector3.up));
            if (Physics.Raycast(transform.position, shotDir, out grapplingPoint, 2000)) {
                
            }
        }
        if (Input.GetButton("Fire1")) {
            GameObject clone = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            clone.name = "projectile";
            clone.transform.SetParent(this.transform);
            clone.GetComponent<Rigidbody>().AddForce((ThirdPersonCamera.cameraDir + (0.33f *Vector3.up)) * 50);
            Debug.DrawRay(transform.position, grapplingPoint.point, Color.green);
            rBody.AddForce((grapplingPoint.point-transform.position).normalized*grapplingForce);
        }
        if(Input.GetButtonUp("Fire1")) {
            grapplingPoint = new RaycastHit();
        }
	}
    
}
