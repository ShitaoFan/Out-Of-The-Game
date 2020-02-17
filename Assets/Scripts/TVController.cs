using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TVController : MonoBehaviour
{
    public MarioGameBox marioGameBox;
    TriggerManager triggerManager;
    CameraManager cameraManager;
    SofaController sofaScript;
    public GameObject tvScreen;
    public GameObject tvScreen2;
    public GameObject tvScreen3;
    public GameObject tvScreen4;
    public GameObject marioGameBox2;
    public GameObject OutOfGameBox2;
    float presentView;
    protected HighlightableObject ho;
    Renderer rder1;
    Renderer rder2;
    Renderer rder3;
    Renderer rder4;
    Renderer rder5;
    Renderer rder6;
    Renderer rder7;
    public GameObject tvPart1;
    public GameObject tvPart2;
    public GameObject tvPart3;
    public GameObject tvPart4;
    public GameObject tvPart5;
    public GameObject tvPart6;
    public GameObject tvPart7;
    bool hoStatus = true;
    bool zoomInStatus = false;
    // Start is called before the first frame update
    void Start()
    {
        marioGameBox = FindObjectOfType<MarioGameBox>();
        cameraManager = FindObjectOfType<CameraManager>();
        sofaScript = FindObjectOfType<SofaController>();
        ho = gameObject.AddComponent<HighlightableObject>();
        triggerManager = FindObjectOfType<TriggerManager>();
        rder1 = tvPart1.GetComponent<Renderer>();
        rder2 = tvPart2.GetComponent<Renderer>();
        rder3 = tvPart3.GetComponent<Renderer>();
        rder4 = tvPart4.GetComponent<Renderer>();
        rder5 = tvPart5.GetComponent<Renderer>();
        rder6 = tvPart6.GetComponent<Renderer>();
        rder7 = tvPart5.GetComponent<Renderer>();
        tvScreen.SetActive(false);
        tvScreen2.SetActive(false);
        tvScreen3.SetActive(true );
    }

    // Update is called once per frame
    void Update()
    {
        if (sofaScript.tvUsedStatus == true && zoomInStatus == true)
        {
            zoomOutIn();
            ZoomInFeedback();
        }
        /*if (triggerManager.tvTriggerCondition == false)
        {
            rder1.material.DisableKeyword("_EMISSION");
            rder2.material.DisableKeyword("_EMISSION");
            rder3.material.DisableKeyword("_EMISSION");
            rder4.material.DisableKeyword("_EMISSION");
            rder5.material.DisableKeyword("_EMISSION");
            rder6.material.DisableKeyword("_EMISSION");
            rder7.material.DisableKeyword("_EMISSION");
            rder8.material.DisableKeyword("_EMISSION");
            ho.Off();
        }*/
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "MarioGameBox2")
        {
            marioGameBox2.SetActive(false);
            tvScreen.SetActive(true);
            tvScreen2.SetActive(false);
            tvScreen3.SetActive(false);
            tvScreen4.SetActive(false);
            Debug.Log("消失吧，马里奥");
            FlashingOff();
            zoomInStatus = true;
            //tvScreen.transform.localPosition = tvScreen.transform.localPosition + new Vector3(0.0f, 0.0f, -0.31f);
        }
        else if (collision.collider.tag == "OutOfGameBox2")
        {
            OutOfGameBox2.SetActive(false);
            tvScreen.SetActive(false);
            tvScreen2.SetActive(true);
            tvScreen3.SetActive(false);
            tvScreen4.SetActive(false);
            FlashingOff();
            zoomInStatus = false;
            //tvScreen.transform.localPosition = tvScreen.transform.localPosition + new Vector3(0.0f, 0.0f, -0.31f);
        }
    }
    void zoomOutIn()
    {
        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (cameraManager.televisionCamera.fieldOfView <= 100)
            {
                cameraManager.televisionCamera.fieldOfView += 2;
                Debug.LogWarning("Zoom in");
            }
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (cameraManager.televisionCamera.fieldOfView > 40)
            {
                cameraManager.televisionCamera.fieldOfView -= 2;
                Debug.LogWarning("Zoom out");
            }
        }
    }
    void ZoomInFeedback()
    {

        if (cameraManager.televisionCamera.fieldOfView <= 40)
        {
            presentView = cameraManager.televisionCamera.fieldOfView;
            cameraManager.televisionCamera.fieldOfView = Mathf.Lerp(presentView, 10, 6.0f * Time.deltaTime);
            Debug.LogWarning("Pass");
        }
        if (cameraManager.televisionCamera.fieldOfView <= 10.5f)
        {

            SceneManager.LoadScene("Mario");
        }
    }
    /*void OnMouseOver()
    {
        if (triggerManager.tvTriggerCondition == true)
        {
            rder1.material.EnableKeyword("_EMISSION");
            rder2.material.EnableKeyword("_EMISSION");
            rder3.material.EnableKeyword("_EMISSION");
            rder4.material.EnableKeyword("_EMISSION");
            rder5.material.EnableKeyword("_EMISSION");
            rder6.material.EnableKeyword("_EMISSION");
            rder7.material.EnableKeyword("_EMISSION");
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
        rder7.material.DisableKeyword("_EMISSION");
        ho.ConstantOff();
    }*/
    public void FlashingOn()
    {
        rder1.material.EnableKeyword("_EMISSION");
        rder2.material.EnableKeyword("_EMISSION");
        rder3.material.EnableKeyword("_EMISSION");
        rder4.material.EnableKeyword("_EMISSION");
        rder5.material.EnableKeyword("_EMISSION");
        rder6.material.EnableKeyword("_EMISSION");
        rder7.material.EnableKeyword("_EMISSION");
        ho.FlashingOn();
    }
    public void FlashingOff()
    {
        rder1.material.DisableKeyword("_EMISSION");
        rder2.material.DisableKeyword("_EMISSION");
        rder3.material.DisableKeyword("_EMISSION");
        rder4.material.DisableKeyword("_EMISSION");
        rder5.material.DisableKeyword("_EMISSION");
        rder6.material.DisableKeyword("_EMISSION");
        rder7.material.DisableKeyword("_EMISSION");
        ho.FlashingOff();
    }
    public void ConstantOn()
    {
        rder1.material.EnableKeyword("_EMISSION");
        rder2.material.EnableKeyword("_EMISSION");
        rder3.material.EnableKeyword("_EMISSION");
        rder4.material.EnableKeyword("_EMISSION");
        rder5.material.EnableKeyword("_EMISSION");
        rder6.material.EnableKeyword("_EMISSION");
        rder7.material.EnableKeyword("_EMISSION");
        ho.ConstantOn();
    }
    public void ConstantOff()
    {
        rder1.material.DisableKeyword("_EMISSION");
        rder2.material.DisableKeyword("_EMISSION");
        rder3.material.DisableKeyword("_EMISSION");
        rder4.material.DisableKeyword("_EMISSION");
        rder5.material.DisableKeyword("_EMISSION");
        rder6.material.DisableKeyword("_EMISSION");
        rder7.material.DisableKeyword("_EMISSION");
        ho.ConstantOff();
    }
}
