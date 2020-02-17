using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVSwitch : MonoBehaviour
{
    protected HighlightableObject ho;
    CameraManager cameraManager;
    ScenesManager sceneManager;
    AudioManager audioManager;
    CursorManager cursorManager;
    Renderer Rder1;
    public GameObject TVSwitch1;
    Chair ChairController;
    cursortest cursorTest;
    SofaController SofaScript;
    // Start is called before the first frame update
    void Start()
    {
        Rder1 = TVSwitch1.GetComponent<Renderer>();
        ChairController = FindObjectOfType<Chair>();
        cursorTest = FindObjectOfType<cursortest>();
        SofaScript = FindObjectOfType<SofaController>();
        cameraManager = FindObjectOfType<CameraManager>();
        sceneManager = FindObjectOfType<ScenesManager>();
        audioManager = FindObjectOfType<AudioManager>();
        cursorManager = FindObjectOfType<CursorManager>();
        ho = gameObject.AddComponent<HighlightableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        cameraManager.televisionCamera.enabled = false;
        cameraManager.characterCamera.enabled = true;
        cursorTest.cursorCondition = true;
    }
    void OnMouseEnter()
    {
        Rder1.material.EnableKeyword("_EMISSION");
        ho.ConstantOn();
    }
    void OnMouseExit()
    {
        Rder1.material.DisableKeyword("_EMISSION");
        ho.ConstantOff();
    }
}
