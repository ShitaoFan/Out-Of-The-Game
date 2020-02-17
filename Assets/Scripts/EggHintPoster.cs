using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggHintPoster : MonoBehaviour
{
    // Start is called before the first frame update
    GameChair chairScript;
    TriggerManager triggerManager;
    StartPoster startPosterScript;
    SleepPoster sleepPosterScript;
    public GameObject Poster2;
    public GameObject arcadeCamera;
    public bool clickCondition = false;
    Vector3 previousPosition;
    Quaternion previousrotation;
    Vector3 previousScale;
    AudioSource pageTurn;
    bool scaleCondition = true;
    public float rotSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        if (Poster2 == null) // Is the variable 'pickupSpot' empty?
        {
            Poster2 = GameObject.FindGameObjectWithTag("Poster2");
        }
        triggerManager = FindObjectOfType<TriggerManager>();
        startPosterScript = FindObjectOfType<StartPoster>();
        sleepPosterScript = FindObjectOfType<SleepPoster>();
        chairScript = FindObjectOfType<GameChair>();
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
        
        // Click to pick up object.
        if (clickCondition == false && chairScript.arcadeUsedStatus == true)
        {
            clickToSelect();
            startPosterScript.clickToBack();
            sleepPosterScript.clickToBack();
            pageTurn.Play();
        }
        // Click to put down object
        else if (clickCondition == true && chairScript.arcadeUsedStatus == true)
        {
            clickToBack();
            //startPosterScript.clickToSelect();
            //sleepPosterScript.clickToSelect();
        }
    }
    void OnMouseEnter()
    {
        if (scaleCondition == true && chairScript.arcadeUsedStatus == true)
        {
            previousScale = transform.localScale;
            transform.localScale = new Vector3(62.0f, 72.0f, 42.0f);
            
            Debug.Log("OK");
        }
    }
    void OnMouseExit()
    {
        if (scaleCondition == true && chairScript.arcadeUsedStatus == true)
        {
            transform.localScale = previousScale;
            
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
        transform.parent = arcadeCamera.transform;
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
        if(clickCondition == true)
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
