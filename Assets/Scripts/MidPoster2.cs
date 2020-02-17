using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MidPoster2 : MonoBehaviour
{
    // Start is called before the first frame update
    Chair2 chairScript;
    TriggerManager triggerManager;
    StartPoster2 startPosterScript;
    SleepPoster2 sleepPosterScript;
    public GameObject Poster2;
    public GameObject laptopCamera;
    public bool clickCondition = false;
    Vector3 previousPosition;
    Quaternion previousrotation;
    Vector3 previousScale;
    AudioSource pageTurn;
    bool scaleCondition = true;
    public float rotSpeed = 20f;
    public Text credits;
    // Start is called before the first frame update
    void Start()
    {
        if (Poster2 == null) // Is the variable 'pickupSpot' empty?
        {
            Poster2 = GameObject.FindGameObjectWithTag("Poster2");
        }
        triggerManager = FindObjectOfType<TriggerManager>();
        startPosterScript = FindObjectOfType<StartPoster2>();
        sleepPosterScript = FindObjectOfType<SleepPoster2>();
        chairScript = FindObjectOfType<Chair2>();
        pageTurn = GetComponent<AudioSource>();
        previousPosition = transform.position;
        previousrotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (clickCondition == true)
        {
            Spin();
        }
    }
    void OnMouseDown()
    {
        credits.enabled = false;
        // Click to pick up object.
        if (clickCondition == false)
        {
            clickToSelect();
            startPosterScript.clickToBack();
            sleepPosterScript.clickToBack();
            pageTurn.Play();
        }
        // Click to put down object
        else
        {
            clickToBack();
            //startPosterScript.clickToSelect();
            //sleepPosterScript.clickToSelect();
        }
    }
    void OnMouseEnter()
    {
        if (scaleCondition == true )
        {
            previousScale = transform.localScale;
            transform.localScale = new Vector3(30.0f, 28.0f, 20.0f);
            credits.enabled = true;
            Debug.Log("OK");
        }
    }
    void OnMouseExit()
    {
        if (scaleCondition == true)
        {
            transform.localScale = previousScale;
            credits.enabled = false;
        }
    }
    /*void OnMouseDrag()
    {
        if (Input.GetMouseButton(1))
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
            transform.RotateAround(Vector3.up, -rotX);
            transform.RotateAround(Vector3.right, rotY);
            Debug.Log("点击右键");
        }
    }*/
    void Spin()
    {
        if (Input.GetMouseButton(1))
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.right, rotX);
            Debug.Log("点击右键");
        }
    }
    public void clickToSelect()
    {
        transform.parent = laptopCamera.transform;
        transform.localPosition = new Vector3(0.0f, 0.0f, 40.0f);
        transform.localRotation = Quaternion.Euler(0.0f, 90.0f, -80.0f);
        clickCondition = true;
        scaleCondition = false;
        triggerManager.middlePosterSwitchTrigger = true;
    }
    public void clickToBack()
    {
        transform.parent = null;
        transform.position = previousPosition;
        transform.localRotation = previousrotation;
        clickCondition = false;
        scaleCondition = true;
        Debug.LogWarning("Object is not currently selected");
        //myCamera1.fieldOfView = 60;
    }
    public void PosterSwitchTrigger()
    {
        if (clickCondition == true)
        {
            triggerManager.middlePosterSwitchTrigger = true;
            triggerManager.startPosterSwitchTrigger = false;
            triggerManager.sleepPosterSwitchTrigger = false;
        }
        else
        {
            triggerManager.middlePosterSwitchTrigger = false;
            triggerManager.startPosterSwitchTrigger = true;
            triggerManager.sleepPosterSwitchTrigger = true;
        }
    }
}
