using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheShiningPoster : MonoBehaviour
{
    // Start is called before the first frame update
    GameChair chairScript;
    TriggerManager triggerManager;
    StartPoster startPosterScript;
    MiddlePoster middlePosterScript;
    public GameObject shiningPoster;
    public GameObject Arcadecamera;
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
        if (shiningPoster == null) // Is the variable 'pickupSpot' empty?
        {
            shiningPoster = GameObject.FindGameObjectWithTag("Poster2");
        }
        triggerManager = FindObjectOfType<TriggerManager>();
        startPosterScript = FindObjectOfType<StartPoster>();
        middlePosterScript = FindObjectOfType<MiddlePoster>();
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
            middlePosterScript.clickToBack();
            pageTurn.Play();
        }
        // Click to put down object
        else if (clickCondition == true && chairScript.arcadeUsedStatus == true)
        {
            clickToBack();
            //startPosterScript.clickToSelect();
            //middlePosterScript.clickToSelect();
        }
    }
    void OnMouseEnter()
    {
        if (scaleCondition == true && chairScript.arcadeUsedStatus == true)
        {
            previousScale = transform.localScale;
            transform.localScale = new Vector3(35.0f, 36.3f, 25.0f);
            
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
    public void clickToSelect()
    {
        transform.parent = Arcadecamera.transform;
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

