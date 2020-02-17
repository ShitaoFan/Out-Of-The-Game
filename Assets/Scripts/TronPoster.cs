using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TronPoster : MonoBehaviour
{
    // Start is called before the first frame update
    GameChair chairScript;
    TriggerManager triggerManager;
    MiddlePoster middlePosterScript;
    SleepPoster sleepPosterScript;
    public GameObject startPoster;
    public GameObject arcadeCamera;
    public bool clickCondition = false;
    Vector3 previousPosition;
    Quaternion previousrotation;
    Vector3 previousScale;
    AudioSource flipPaper;
    bool scaleCondition = true;
    public float rotSpeed = 20f;
    void Start()
    {
        if (startPoster == null)
        {
        startPoster = GameObject.FindGameObjectWithTag("Poster2");
        }
        triggerManager = FindObjectOfType<TriggerManager>();
        middlePosterScript = FindObjectOfType<MiddlePoster>();
        sleepPosterScript = FindObjectOfType<SleepPoster>();
        chairScript = FindObjectOfType<GameChair>();
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
        
        // Click to pick up object.
        if (clickCondition == false && chairScript.arcadeUsedStatus == true) 
        {
            clickToSelect();
            middlePosterScript.clickToBack();
            sleepPosterScript.clickToBack();
            flipPaper.Play();
        }
        // Click to put down object
        else if (clickCondition == true && chairScript.arcadeUsedStatus == true)
        {
            clickToBack();
           
        }
    }
    void OnMouseEnter() 
    {
       if(scaleCondition == true && chairScript.arcadeUsedStatus == true)
       {
        previousScale = transform.localScale;
        transform.localScale = new Vector3(38.0f,44.0f,28.0f);
       
        Debug.Log("OK");
       }
    }

    void OnMouseExit() 
    {
        if(scaleCondition == true && chairScript.arcadeUsedStatus == true)
       {
        transform.localScale = previousScale;
        
       }
    }
    
    public void clickToSelect()
    {
        transform.parent = arcadeCamera.transform;
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
