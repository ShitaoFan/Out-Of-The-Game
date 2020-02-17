using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public GameObject Eye;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TankUpdate();
        transfromLimit();
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
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 200, 0));
            //clearArrow(false);
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            if (Input.GetAxis("Mouse Y") < 0.1f && Input.GetAxis("Mouse Y") > -0.1f)
            {
                //bug.Log("Mouse Y");
                //  return;
            }
            Eye.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * -200, 0, 0));

        }
        //}
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 30.0f);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * 30.0f);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * Time.deltaTime * 30.0f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 30.0f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            
        }
    }
    void transfromLimit()
    {
        if (transform.position.x < -1094.5f)
        {
            transform.position = new Vector3(-1094.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.z < 411.81f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 411.81f);
        }
        if (transform.position.z > 505.93f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 505.93f);
        }
        if (transform.position.x > -906.8f)
        {
            transform.position = new Vector3(-906.8f, transform.position.y, transform.position.z);
        }
        if (Eye.transform.eulerAngles.x > 80f & Eye.transform.eulerAngles.x <= 180f)
        {
            Eye.transform.eulerAngles = new Vector3(80f, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }

}
