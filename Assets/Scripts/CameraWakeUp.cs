using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWakeUp : MonoBehaviour
{
   

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    float moveSpeed = 2;
    public GameObject camera;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");

        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    }
    private void TankUpdate()
    {
    
        if (Input.GetAxis("Mouse X") != 0)
        {
            //Debug.Log(Input.GetAxis("Mouse X"));
            if (Input.GetAxis("Mouse X") < 0.1f && Input.GetAxis("Mouse X") > -0.1f)
            {
                // return;
            }
            camera.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 200, 0));
            //clearArrow(false);
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            if (Input.GetAxis("Mouse Y") < 0.1f && Input.GetAxis("Mouse Y") > -0.1f)
            {
                //bug.Log("Mouse Y");
                //  return;
            }
            camera.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * -200, 0, 0));

        }
        //}
        if (Input.GetKey(KeyCode.W))
        {
            camera.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
           
        }
        if (Input.GetKey(KeyCode.S))
        {
            camera.transform.Translate(-Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
         
        }
        if (Input.GetKey(KeyCode.A))
        {
            camera.transform.Translate(-Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
           
        }
        if (Input.GetKey(KeyCode.D))
        {
            camera.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            
        }

        
    }

}
