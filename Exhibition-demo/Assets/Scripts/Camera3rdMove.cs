using UnityEngine;
using System.Collections;
//using DG.Tweening;
using System;
using Unity.Collections;
public class Camera3rdMove : MonoBehaviour
{
    public Transform mainCamera; 
    public Transform targetPos;
    public Quaternion Rotation;
    public float Distance;
    private void Start()
    {
        //mainCamera = Camera.main.transform;
        //InitCameraRotateAround();
    }
    private void Update()
    {
        camerarotate();
        camerazoom();
    }
    
    private void camerarotate() //Rotating
    {
        
        var mouse_x = Input.GetAxis("Mouse X");
        var mouse_y = -Input.GetAxis("Mouse Y");
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.RotateAround(targetPos.transform.position, Vector3.up, mouse_x*5);//Horizontal rotation
            transform.RotateAround(targetPos.transform.position, transform.right, mouse_y*5);//Vertical rotation
            Rotation = transform.rotation;
        }
    }
 
    private void camerazoom() //Zooming
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.Translate(Vector3.forward*0.5f);
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            transform.Translate(Vector3.forward*-0.5f);
        Distance = Vector3.Distance(transform.position, targetPos.position);
    }

}
