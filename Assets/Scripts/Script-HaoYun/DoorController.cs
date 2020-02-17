using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update

    TriggerManager triggerManager;
    AudioSource door;
    Renderer rder1;
    Renderer rder2;
    Renderer rder3;
    Renderer rder4;
    Renderer rder5;
    Renderer rder6;
    public GameObject doorCenter;
    public GameObject doorPart1;
    public GameObject doorPart2;
    public GameObject doorPart3;
    public GameObject doorPart4;
    public GameObject doorPart5;
    public GameObject doorPart6;
    bool clickCondition = false;
    public Animator doorAnimator;
    protected HighlightableObject ho;

    Vector3 offPosition = new Vector3(-482.6212f, 4.35714f, 1057.607f);
    Vector3 onPosition = new Vector3(-400.3f, 4.35714f, -756.5f);
    Quaternion offRotation = Quaternion.Euler(0.155f, -61.261f, 0.207f);
    Quaternion onRotation = Quaternion.Euler(0.155f, 44.15f, 0.207f);
    void Start()
    {
        rder1 = doorPart1.GetComponent<Renderer>();
        rder2 = doorPart2.GetComponent<Renderer>();
        rder3 = doorPart3.GetComponent<Renderer>();
        rder4 = doorPart4.GetComponent<Renderer>();
        rder5 = doorPart5.GetComponent<Renderer>();
        rder6 = doorPart6.GetComponent<Renderer>();
        door = GetComponent<AudioSource>();
        doorAnimator = doorCenter.GetComponent<Animator>();
        triggerManager = FindObjectOfType<TriggerManager>();
        ho = gameObject.AddComponent<HighlightableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerManager.doorTriggerCondition == false)
        {
            rder1.material.DisableKeyword("_EMISSION");
            rder2.material.DisableKeyword("_EMISSION");
            rder3.material.DisableKeyword("_EMISSION");
            rder4.material.DisableKeyword("_EMISSION");
            rder5.material.DisableKeyword("_EMISSION");
            rder6.material.DisableKeyword("_EMISSION");
            ho.Off();
        }
    }
    void OnMouseDown()
    {
        /*if (clickCondition == false)
        {
            transform.position = onPosition;
            transform.rotation = onRotation;
          //transform.position = Vector3.Lerp(offPosition, onPosition, Time.deltaTime);
          //transform.rotation = Quaternion.Lerp(offRotation, onRotation, Time.deltaTime);
            clickCondition = true;

            Debug.Log("on");
        }
        else
        {
            transform.position = offPosition;
            transform.rotation = offRotation;
          //transform.position = Vector3.Lerp(onPosition, offPosition, Time.deltaTime);
          //transform.rotation = Quaternion.Lerp(onRotation, offRotation, Time.deltaTime);
            clickCondition = false;
            Debug.Log("off");
        }*/
        if(triggerManager.doorTriggerCondition == true)
        {
            doorAnimator.SetBool("OpenError", true);
            door.Play();
        }
        /*if (clickCondition == true)
        {
            doorAnimator.SetBool("OpenDoor",true);
        }*/
    }

    void OnMouseOver()
    {
        if (triggerManager.doorTriggerCondition == true)
        {
            rder1.material.EnableKeyword("_EMISSION");
            rder2.material.EnableKeyword("_EMISSION");
            rder3.material.EnableKeyword("_EMISSION");
            rder4.material.EnableKeyword("_EMISSION");
            rder5.material.EnableKeyword("_EMISSION");
            rder6.material.EnableKeyword("_EMISSION");
            ho.ConstantOn();
        }
        }
    void OnMouseExit()
    {
        rder1.material.DisableKeyword("_EMISSION");
        rder2.material.DisableKeyword("_EMISSION");
        rder3.material.DisableKeyword("_EMISSION");
        rder4.material.DisableKeyword("_EMISSION");
        rder5.material.DisableKeyword("_EMISSION");
        rder6.material.DisableKeyword("_EMISSION");
        ho.Off();
    }
}
