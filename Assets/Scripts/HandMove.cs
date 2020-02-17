using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMove : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontalSpeed = 0.5f;
    float verticalSpeed = 0.5f;
    

    public GameObject rightHand;
    public GameObject Mouse;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        Mouse.transform.localPosition += new Vector3(h, 0, v);

        if(Mouse.transform.position.x < -1027.71f)
        {
            Mouse.transform.position = new Vector3(-1027.71f, Mouse.transform.position.y, Mouse.transform.position.z);
        }
        if (Mouse.transform.position.x > -991.9f)
        {
            Mouse.transform.position = new Vector3(-991.9f, Mouse.transform.position.y, Mouse.transform.position.z);
        }
        if (Mouse.transform.position.z < 460.0f)
        {
            Mouse.transform.position = new Vector3(Mouse.transform.position.x, Mouse.transform.position.y, 460.0f);
        }
        if (Mouse.transform.position.z > 498.0f)
        {
            Mouse.transform.position = new Vector3(Mouse.transform.position.x, Mouse.transform.position.y, 498.0f);
        }
    }
}
