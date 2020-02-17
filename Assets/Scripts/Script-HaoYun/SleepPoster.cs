using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SleepPoster : MonoBehaviour
{
    // Start is called before the first frame update
    Chair chairScript;
    TriggerManager triggerManager;
    StartPoster startPosterScript;
    MiddlePoster middlePosterScript;
    public GameObject sleepPoster;
    public GameObject laptopCamera;
    public bool clickCondition = false;
    Vector3 previousPosition;
    Quaternion previousrotation;
    Vector3 previousScale;
    AudioSource pageTurn;
    bool scaleCondition = true;
    public float rotSpeed = 20f;
    public Text Out;

    // Start is called before the first frame update
    void Start()
    {
        if (sleepPoster == null) // Is the variable 'pickupSpot' empty?
        {
            sleepPoster = GameObject.FindGameObjectWithTag("Poster2");
        }
        triggerManager = FindObjectOfType<TriggerManager>();
        startPosterScript = FindObjectOfType<StartPoster>();
        middlePosterScript = FindObjectOfType<MiddlePoster>();
        chairScript = FindObjectOfType<Chair>();
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
        Out.enabled = false;
        // Click to pick up object.
        if (clickCondition == false && chairScript.chairUsedCondition == true)
        {
            clickToSelect();
            startPosterScript.clickToBack();
            middlePosterScript.clickToBack();
            pageTurn.Play();
        }
        // Click to put down object
        else if (clickCondition == true && chairScript.chairUsedCondition == true)
        {
            clickToBack();
            //startPosterScript.clickToSelect();
            //middlePosterScript.clickToSelect();
        }
    }
    void OnMouseEnter()
    {
        if (scaleCondition == true && chairScript.chairUsedCondition == true)
        {
            previousScale = transform.localScale;
            transform.localScale = new Vector3(35.0f, 36.3f, 25.0f);
            Out.enabled = true;
            Debug.Log("OK");
        }
    }
    void OnMouseExit()
    {
        if (scaleCondition == true && chairScript.chairUsedCondition == true)
        {
            transform.localScale = previousScale;
            Out.enabled = false;

        }
    }
    public void clickToSelect()
    {
        transform.parent = laptopCamera.transform;
        transform.localPosition = new Vector3(0.0f, 0.0f, 60.0f);
        transform.localRotation = Quaternion.Euler(0.0f, 90.0f, -80.0f);
        clickCondition = true;
        scaleCondition = false;
        middlePosterScript.clickCondition = true;
        startPosterScript.clickCondition = true;
    }
    public void clickToBack()
    {
        transform.parent = null;
        transform.position = previousPosition;
        transform.localRotation = previousrotation;
        clickCondition = false;
        scaleCondition = true;
        //myCamera1.fieldOfView = 60;
    }
    void Spin()
    {
        if (Input.GetMouseButton(1))
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            transform.Rotate(Vector3.right, rotX);
        }
    }

    public void PosterSwitchTrigger()
    {
        if (clickCondition == true)
        {
            triggerManager.middlePosterSwitchTrigger = false;
            triggerManager.startPosterSwitchTrigger = false;
            triggerManager.sleepPosterSwitchTrigger = true;
        }
        else
        {
            triggerManager.startPosterSwitchTrigger = true;
            triggerManager.middlePosterSwitchTrigger = true;
            triggerManager.sleepPosterSwitchTrigger = false;
        }
    }
}