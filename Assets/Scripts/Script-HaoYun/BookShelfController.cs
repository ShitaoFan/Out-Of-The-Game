using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class BookShelfController : MonoBehaviour
 {
    // Start is called before the first frame update
    TriggerManager triggerManager;
    CameraManager cameraManager;
    public Renderer rder;
    public GameObject bookshelf;
    public GameObject gameBoxes;
    public bool bookFocusStatus = false;
    cursortest cursorTest;
    protected HighlightableObject ho;
    void Start()
     {
        rder = bookshelf.GetComponent<Renderer>();
        triggerManager = FindObjectOfType<TriggerManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        cursorTest = FindObjectOfType<cursortest>();
        ho = gameObject.AddComponent<HighlightableObject>();
    }

     // Update is called once per frame
     void Update()
     {
        if (triggerManager.bookshelfTriggerCondition == false)
        {
            rder.material.DisableKeyword("_EMISSION");
            ho.Off();
        }
    }
     void OnMouseDown()
     {
        if (bookFocusStatus == false && triggerManager.bookshelfTriggerCondition == true)
        {
            cameraManager.bookshelfCamera.enabled = true;
            cameraManager.characterCamera.enabled = false;
            bookFocusStatus = true;
            cursorTest.cursorCondition = false;
            triggerManager.bookshelfTriggerCondition = false;
            gameBoxes.SetActive(true);
        }
        /*else if (bookFocusStatus == true && triggerManager.bookshelfTriggerCondition == true)
        {
            cameraManager.bookshelfCamera.enabled = false;
            cameraManager.characterCamera.enabled = true;
            bookFocusStatus = false;
            cursorTest.cursorCondition = 1;
        }*/
     }
     void OnMouseOver()
     {
         if (triggerManager.bookshelfTriggerCondition == true)
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
