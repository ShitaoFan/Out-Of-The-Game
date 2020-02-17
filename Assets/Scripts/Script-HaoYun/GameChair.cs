using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameChair : MonoBehaviour
{
    CameraManager cameraManager;
    TriggerManager triggerManager;
    Renderer Rder1;
    Renderer Rder2;
    public GameObject GameChairPart1;
    public GameObject GameChairPart2;
    cursortest cursorTest;
    public bool arcadeUsedStatus = false;
    protected HighlightableObject ho;
    public ArcadeOutCase arcadeOutCase;
    public ArcadeOutCase arcadeOutCase1;
    // Start is called before the first frame update
    void Start()
    {
        Rder1 = GameChairPart1.GetComponent<Renderer>();
        Rder2 = GameChairPart2.GetComponent<Renderer>();
        triggerManager = FindObjectOfType<TriggerManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        cursorTest = FindObjectOfType<cursortest>();
        ho = gameObject.AddComponent<HighlightableObject>();
        arcadeOutCase = FindObjectOfType<ArcadeOutCase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerManager.seatTriggerCondition == false)
        {
            Rder1.material.DisableKeyword("_EMISSION");
            Rder2.material.DisableKeyword("_EMISSION");
            ho.Off();
            arcadeOutCase.MouseOut();
            arcadeOutCase1.MouseOut();
        }
    }
    void OnMouseDown()
    {
        if (triggerManager.seatTriggerCondition == true)
        {
            cameraManager.characterCamera.enabled = false;
            cameraManager.arcadeCamera.enabled = true;
            cursorTest.cursorCondition = false;
            arcadeUsedStatus = true;
        }
    }
    void OnMouseOver()
    {
        if (triggerManager.seatTriggerCondition == true)
        {
            Rder1.material.EnableKeyword("_EMISSION");
            Rder2.material.EnableKeyword("_EMISSION");
            ho.ConstantOn();
            arcadeOutCase.MouseIn();
            arcadeOutCase1.MouseIn();
        }
    }
    void OnMouseExit()
    {
        Rder1.material.DisableKeyword("_EMISSION");
        Rder2.material.DisableKeyword("_EMISSION");
        ho.Off();
        arcadeOutCase.MouseOut();
        arcadeOutCase1.MouseOut();
    }
}
