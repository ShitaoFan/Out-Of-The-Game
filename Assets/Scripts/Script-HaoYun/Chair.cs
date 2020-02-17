using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
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
    Renderer Rder;
    public Texture2D cursora;
    public CursorMode cursorMode = CursorMode.Auto;
    cursortest cursorTest;
    public bool chairUsedCondition = false;
    protected HighlightableObject ho;
    void Start()
    {
        //LaptopCamera.enabled = false;
        //CameraWakeUp.enabled = true;
        //CharactorCamera.enabled = true;
        Rder = GetComponent<Renderer>();
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
            //transform.position = previouslocalposition;
            //transform.rotation = previousrotation;
            Rder.material.DisableKeyword("_EMISSION");
            ho.Off();
        }
    }
    void OnMouseDown() 
    {
        if(triggerManager.chairTriggerCondition == true)
        {
            cameraManager.laptopCamera.enabled = true;
            cameraManager.characterCamera.enabled = false;
            //cursortest.SetMouseToAnyOfScreenPosition() = false;
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = false;
            //Cursor.SetCursor(cursora, Vector2.zero, cursorMode);
            cursorTest.cursorCondition = false;
            chairUsedCondition = true;
        }
    }
    void OnMouseEnter() 
    {
        if (triggerManager.chairTriggerCondition == true)
        {
            //previouslocalposition = transform.position;
            //previousrotation = transform.rotation;

            //transform.position = new Vector3(-1393.598f,4.693665f,324.7501f);
            //transform.rotation = Quaternion.Euler(0.0f,42.123f,0.0f);
            Rder.material.EnableKeyword("_EMISSION");
            ho.ConstantOn();
        }
    }
    void OnMouseExit()
    {
        Rder.material.DisableKeyword("_EMISSION");
        ho.Off();
    }
}
