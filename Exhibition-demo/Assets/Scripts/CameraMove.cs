using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    
        public float mouseSpeed = 100f;
        
        public Transform playerBody;
    
        float xRotation = 0f;
        // Start is called before the first frame update
        void Start()
        {
            
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * mouseSpeed * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSpeed * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -40f, 40f);//Vertical adjustment range of the camera
    
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
    
        }
}
