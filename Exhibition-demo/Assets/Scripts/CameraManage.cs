using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManage : MonoBehaviour
{
    public Camera camera1st;

    public Camera camera3rd;
    // Start is called before the first frame update
    void Start()
    {
        camera1st.enabled = true;
        camera3rd.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))  
        {
            if (camera1st.enabled == true)
            {
                camera1st.enabled = false;
                camera3rd.enabled = true;
            }
            else
            {
                camera1st.enabled = true;
                camera3rd.enabled = false;
            }
        }
        
        
    }
}
