using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair2 : MonoBehaviour
{
    // Start is called before the first frame update
    TriggerManager triggerManager;
    CameraManager cameraManager;
    ScenesManager sceneManager;
    AudioManager audioManager;
    CursorManager cursorManager;
    //public Camera LaptopCamera;
    //public Camera CameraWakeUp;
    //public Camera CharactorCamera;
    Vector3 previouslocalposition;
    Quaternion previousrotation;
    Vector3 previousScale;
    Renderer rder;
    public Texture2D cursora;
    public CursorMode cursorMode = CursorMode.Auto;
    cursortest cursorTest;
    public bool chairUsedCondition = true;
    protected HighlightableObject ho;
    void Start()
    {
   
        rder = GetComponent<Renderer>();
        cursorTest = FindObjectOfType<cursortest>();
        triggerManager = FindObjectOfType<TriggerManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        sceneManager = FindObjectOfType<ScenesManager>();
        audioManager = FindObjectOfType<AudioManager>();
        cursorManager = FindObjectOfType<CursorManager>();
        ho = gameObject.AddComponent<HighlightableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerManager.chairTriggerCondition == false)
        {

            rder.material.DisableKeyword("_EMISSION");
            ho.Off();
        }
    }
    void OnMouseDown()
    {
        if (triggerManager.chairTriggerCondition == true)
        {
            cameraManager.laptopCamera.enabled = true;
            cameraManager.characterCamera.enabled = false;
    
            cursorTest.cursorCondition = false;
            chairUsedCondition = true;
        }
    }
    void OnMouseEnter()
    {
        if (triggerManager.chairTriggerCondition == true)
        {
           
            rder.material.EnableKeyword("_EMISSION");
            ho.ConstantOn();
        }
    }
    void OnMouseExit()
    {
        rder.material.DisableKeyword("_EMISSION");
        ho.Off();
    }
}
