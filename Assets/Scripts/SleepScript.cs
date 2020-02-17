using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SleepScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startPoster;
    public GameObject laptopCamera;
    bool clickCondition = false;
    Vector3 previouslocalposition;
    Quaternion previousrotation;
    Vector3 previousScale;
    bool scaleCondition = true;
    public float rotSpeed = 20f;
    public Text Out;
    // Start is called before the first frame update
    void Start()
    {
        if (startPoster == null) // Is the variable 'pickupSpot' empty?
        {
            startPoster = GameObject.FindGameObjectWithTag("Poster2");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (clickCondition == true)
            Spin();
    }
    void OnMouseDown()
    {
        Out.enabled = false;
        // Click to pick up object.
        if (clickCondition == false)
        {
            previouslocalposition = transform.localPosition;
            previousrotation = transform.rotation;
            transform.parent = laptopCamera.transform;
            transform.localPosition = new Vector3(0.0f, 0.0f, 60.0f);
            transform.localRotation = Quaternion.Euler(0.0f, 90.0f, -80.0f);
            clickCondition = true;
            scaleCondition = false;
            Debug.LogWarning("Object is currently selected");
        }
        // Click to put down object
        else
        {
            transform.parent = null;
            transform.localPosition = previouslocalposition;
            transform.localRotation = previousrotation;
            clickCondition = false;
            scaleCondition = true;
            Debug.LogWarning("Object is not currently selected");
            //myCamera1.fieldOfView = 60;
        }
    }
    void OnMouseEnter()
    {
        if (scaleCondition == true)
        {
            previousScale = transform.localScale;
            transform.localScale = new Vector3(35.0f, 36.3f, 25.0f);
            Out.enabled = true;
            Debug.Log("OK");
        }
    }
    void OnMouseExit()
    {
        if (scaleCondition == true)
        {
            transform.localScale = previousScale;
            Out.enabled = false;

        }
    }
    void Spin()
    {
        if (Input.GetMouseButton(1))
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.right, rotX);
            Debug.Log("点击右键");
        }
    }
}
