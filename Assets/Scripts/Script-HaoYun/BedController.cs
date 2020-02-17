using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{
    TriggerManager triggerManager;
    CameraManager cameraManager;
    ScenesManager sceneManager;
    AudioManager audioManager;
    CursorManager cursorManager;
    public Renderer BedRder;
    public GameObject Bed;
    public GameObject CharacterWakeup;
    public GameObject CharacterOnfloor;
    public bool CharacterCondition = false;
    protected HighlightableObject ho;
    // Start is called before the first frame update
    void Start()
    {
        BedRder = Bed.GetComponent<Renderer>();
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
        if (triggerManager.ladderTriggerCondition == false) //|| triggerManager.lowerLadderTriggerCondition == true)
        {
            BedRder.material.DisableKeyword("_EMISSION");
            ho.Off();
        }
    }
    void OnMouseDown()
    {
        if(CharacterCondition == false && triggerManager.ladderTriggerCondition == true)
        {
            CharacterWakeup.SetActive(false);
            CharacterOnfloor.SetActive(true);
            cameraManager.wakeupCamera.enabled = false;
            cameraManager.characterCamera.enabled = true;
            CharacterCondition = true;
            CharacterWakeup.transform.localPosition = new Vector3(40.34679f, 23.02411f, -53.82552f);
            CharacterWakeup.transform.rotation = Quaternion.Euler(0f, 261.289f, 0f);
            triggerManager.ladderTriggerCondition = false;
            BedRder.material.DisableKeyword("_EMISSION");
            Debug.Log("下床");
        }
        else if(CharacterCondition == true && triggerManager.ladderTriggerCondition == true)
        {
            CharacterWakeup.SetActive(true);
            CharacterOnfloor.SetActive(false);
            cameraManager.wakeupCamera.enabled = true;
            cameraManager.characterCamera.enabled = false;
            CharacterCondition = false;
            CharacterOnfloor.transform.localPosition = new Vector3(20.22f, -9.51f, -34.99f);
            CharacterOnfloor.transform.rotation = Quaternion.Euler(-0.149f, -6.962f, -0.508f);
            triggerManager.ladderTriggerCondition = false;
            BedRder.material.DisableKeyword("_EMISSION");
            Debug.Log("上床");
        }
    }
    void OnMouseOver()
    {
        if (triggerManager.ladderTriggerCondition == true) //|| triggerManager.lowerLadderTriggerCondition == true)
        {
            BedRder.material.EnableKeyword("_EMISSION");
            ho.ConstantOn();
        }
    }
    void OnMouseExit()
    {
        //if (triggerManager.ladderTriggerCondition == true) //|| triggerManager.lowerLadderTriggerCondition == true)
        BedRder.material.DisableKeyword("_EMISSION");
        ho.Off();
    }
}
