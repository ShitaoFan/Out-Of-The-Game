using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartPoster2 : MonoBehaviour
{
    // Start is called before the first frame update
    Chair2 chairScript;
    TriggerManager triggerManager;
    MidPoster2 middlePosterScript;
    SleepPoster2 sleepPosterScript;
    public GameObject startPoster;
    public GameObject laptopCamera;
    public bool clickCondition = false;
    Vector3 previousPosition;
    Quaternion previousrotation;
    Vector3 previousScale;
    AudioSource flipPaper;
    bool scaleCondition = true;
    public float rotSpeed = 20f;
    public Text game;
    // Start is called before the first frame update
    void Start()
    {
        if (startPoster == null) // Is the variable 'pickupSpot' empty?
        {
            startPoster = GameObject.FindGameObjectWithTag("Poster2");
        }
        triggerManager = FindObjectOfType<TriggerManager>();
        middlePosterScript = FindObjectOfType<MidPoster2>();
        sleepPosterScript = FindObjectOfType<SleepPoster2>();
        chairScript = FindObjectOfType<Chair2>();
        flipPaper = GetComponent<AudioSource>();
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
        game.enabled = false;
        // Click to pick up object.
        if (clickCondition == false) 
        {
            clickToSelect();
            middlePosterScript.clickToBack();
            sleepPosterScript.clickToBack();
            flipPaper.Play();
        }
        // Click to put down object
        else 
        {
            clickToBack();
            //middlePosterScript.clickToSelect();
            //sleepPosterScript.clickToSelect();
        }
    }
    void OnMouseEnter()
    {
        if (scaleCondition == true )
        {
            previousScale = transform.localScale;
            transform.localScale = new Vector3(43.0f, 44.0f, 30.0f);
            game.enabled = true;
            Debug.Log("OK");
        }
    }

    void OnMouseExit()
    {
        if (scaleCondition == true )
        {
            transform.localScale = previousScale;
            game.enabled = false;
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
    public void clickToSelect()
    {
        transform.parent = laptopCamera.transform;
        transform.localPosition = new Vector3(0.0f, 0.0f, 60.0f);
        transform.localRotation = Quaternion.Euler(0.0f, 90.0f, -80.0f);
        clickCondition = true;
        scaleCondition = false;
    }
    public void clickToBack()
    {
        transform.parent = null;
        transform.position = previousPosition;
        transform.localRotation = previousrotation;
        clickCondition = false;
        scaleCondition = true;

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
    public void PosterSwitchTrigger()
    {
        if (clickCondition == true)
        {
            triggerManager.middlePosterSwitchTrigger = false;
            triggerManager.startPosterSwitchTrigger = true;
            triggerManager.sleepPosterSwitchTrigger = false;
        }
        else
        {
            triggerManager.startPosterSwitchTrigger = false;
            triggerManager.middlePosterSwitchTrigger = true;
            triggerManager.sleepPosterSwitchTrigger = true;
        }
    }
}