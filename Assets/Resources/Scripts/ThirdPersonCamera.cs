﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

        private const float Y_ANGLE_MIN = -50.0f;
        private const float Y_ANGLE_MAX = 50.0f;

        public Transform lookAt;
        public Transform camTransform;
        public static Vector3 cameraDir;
        public bool invertY;

        private Camera cam;

        private float distance = 10.0f;
        private float currentX = 0.0f;
        private float currentY = 0.0f;
        private float sensivityX = 4.0f;
        private float sensivityY = 1.0f;

        public CursorLockMode cursorMode;

        private void Start() {
            Cursor.lockState = cursorMode;
            //Cursor.visible = false;
            camTransform = transform;
            cam = Camera.main;
        }

        private void Update() {
            currentX += Input.GetAxis("Mouse X");
            if (invertY) currentY -= Input.GetAxis("Mouse Y");
            else currentY += Input.GetAxis("Mouse Y");
            cameraDir = cam.transform.forward;

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }

        private void LateUpdate() {
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            //sets the position of the camera
            Vector3 newPosition = lookAt.position + rotation * dir;
            //if the camera is below a certain level (y==0.5)
            if (newPosition.y < 0.5f) {
                //set y to 2
                newPosition.y = 0.5f;
            }
            camTransform.position = newPosition;

            camTransform.LookAt(lookAt.position);
        }

    

}
