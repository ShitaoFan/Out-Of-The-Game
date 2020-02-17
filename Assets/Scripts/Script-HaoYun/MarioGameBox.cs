using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioGameBox : MonoBehaviour
{
    TVController tvScript;
    CameraManager cameraManager;
    BookShelfController bookShelfScript;
    AudioSource superMario;
    public Renderer marioRder;
    public GameObject marioGameBox;
    public GameObject marioGameBox2;
    public GameObject marioPointLight;
    public GameObject characterCamera;
    public GameObject tv;
    public bool selectstatus = false;
    cursortest cursorTest;
    protected HighlightableObject ho;
    Vector3 previousPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        marioRder = marioGameBox.GetComponent<Renderer>();
        cameraManager = FindObjectOfType<CameraManager>();
        cursorTest = FindObjectOfType<cursortest>();
        ho = gameObject.AddComponent<HighlightableObject>();
        tvScript = FindObjectOfType<TVController>();
        bookShelfScript = FindObjectOfType<BookShelfController>();
        superMario =GetComponent<AudioSource>();
        previousPosition = marioGameBox.transform.localPosition;
    }
        // Update is called once per frame
        void Update()
    {
        
    }
    void OnMouseDown()
    {
        clickToSelect();
        tvScript.FlashingOn();
        bookShelfScript.gameBoxes.SetActive(false);
        bookShelfScript.bookFocusStatus = false;


    }
    void OnMouseEnter()
    {
        if (selectstatus == false)
        {
            marioGameBox.transform.localPosition = marioGameBox.transform.localPosition + new Vector3(-35.0f, 0f, 0f);
            marioRder.material.EnableKeyword("_EMISSION");
            ho.ConstantOn();
            superMario.Play();
        }
    }
    void OnMouseExit()
    {
        if (selectstatus == false)
        {
            marioGameBox.transform.localPosition = previousPosition;
            marioRder.material.DisableKeyword("_EMISSION");
            ho.ConstantOff();
        }
    }
    public void clickToSelect()
    {
        selectstatus = true;
        cameraManager.bookshelfCamera.enabled = false;
        cameraManager.characterCamera.enabled = true;
        //marioGameBox.transform.parent = characterCamera.transform;
        //marioGameBox.SetActive(false);
        marioGameBox2.SetActive(true);
        marioPointLight.SetActive(true);
        cursorTest.cursorCondition = true;
        //transform.localPosition = new Vector3(-9.4063f, -0.0148f, 0.392f);
        //transform.localRotation = Quaternion.Euler(3.983f, 180.0f, 0f);
        //transform.localScale = new Vector3(0.002229537f, 0.002229537f, -0.002229537f);

    }
    /*public void clickToBack()
    {
        transform.parent = null;
        //transform.position = previousPosition;
        //transform.localRotation = previousrotation;
    }*/
}
