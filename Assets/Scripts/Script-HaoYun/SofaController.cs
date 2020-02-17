using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaController : MonoBehaviour
{
    // Start is called before the first frame update
    TriggerManager triggerManager;
    CameraManager cameraManager;
    ScenesManager sceneManager;
    AudioManager audioManager;
    CursorManager cursorManager;
    public Renderer rder1;
    public Renderer rder2;
    public Renderer rder3;
    public GameObject sofaMainPart;
    public GameObject sofaPart1;
    public GameObject sofaPart2;
    Chair ChairController;
    cursortest cursorTest;
    public bool tvUsedStatus = false;
    protected HighlightableObject ho;
    void Start()
    {
        rder1 = sofaMainPart.GetComponent<Renderer>();
        rder2 = sofaPart1.GetComponent<Renderer>();
        rder3 = sofaPart2.GetComponent<Renderer>();
        ChairController = FindObjectOfType<Chair>();
        cursorTest = FindObjectOfType<cursortest>();
        cameraManager = FindObjectOfType<CameraManager>();
        sceneManager = FindObjectOfType<ScenesManager>();
        audioManager = FindObjectOfType<AudioManager>();
        cursorManager = FindObjectOfType<CursorManager>();
        triggerManager = FindObjectOfType<TriggerManager>();
        ho = gameObject.AddComponent<HighlightableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerManager.sofaTriggerCondition == false)
        {
            rder1.material.DisableKeyword("_EMISSION");
            rder2.material.DisableKeyword("_EMISSION");
            rder3.material.DisableKeyword("_EMISSION");
            ho.Off();
        }
    }
    void OnMouseDown()
    {
        if(triggerManager.sofaTriggerCondition == true)
        {
            cameraManager.televisionCamera.enabled = true;
            cameraManager.characterCamera.enabled = false;
            cursorTest.cursorCondition = false;
            tvUsedStatus = true;
        }
    }
    void OnMouseOver()
    {
        if (triggerManager.sofaTriggerCondition == true)
        {
            rder1.material.EnableKeyword("_EMISSION");
            rder2.material.EnableKeyword("_EMISSION");
            rder3.material.EnableKeyword("_EMISSION");
            Debug.Log("沙发亮");
            ho.ConstantOn();
        }
    }
    void OnMouseExit()
    {
        rder1.material.DisableKeyword("_EMISSION");
        rder2.material.DisableKeyword("_EMISSION");
        rder3.material.DisableKeyword("_EMISSION");
        ho.Off();
    }
}
