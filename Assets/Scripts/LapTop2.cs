using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapTop2 : MonoBehaviour
{
    CameraManager3 cameraManager;
    ScenesManager sceneManager;
    AudioManager audioManager;
    CursorManager cursorManager;
    StartPoster2 startPosterScript;
    MidPoster2 middlePosterScript;
    SleepPoster2 sleepPosterScript;
    LampLight2 lamplightScript;
    float presentView;
    Chair2 chairScript;
    public GameObject laptopScreen;
    public Material laptopMaterial_1;
    public Material laptopMaterial_2;
    public Renderer laptopScreenRenderer;
    cursortest cursorScript;
    // Start is called before the first frame update
    void Start()
    {
        //laptopCamera.enabled = false;
        //cameraWakeUp.enabled = false;
        //charactorCamera.enabled = true;
        chairScript = FindObjectOfType<Chair2>();
        cameraManager = FindObjectOfType<CameraManager3>();
        sceneManager = FindObjectOfType<ScenesManager>();
        audioManager = FindObjectOfType<AudioManager>();
        cursorManager = FindObjectOfType<CursorManager>();
        laptopScreenRenderer = laptopScreen.GetComponent<Renderer>();
        startPosterScript = FindObjectOfType<StartPoster2>();
        middlePosterScript = FindObjectOfType<MidPoster2>();
        sleepPosterScript = FindObjectOfType<SleepPoster2>();
        lamplightScript = FindObjectOfType<LampLight2>();
        cursorScript = FindObjectOfType<cursortest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chairScript.chairUsedCondition == true)
        {
            zoomOutIn();
            ZoomInFeedback();
        }
    }
    void zoomOutIn()
    {
        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (cameraManager.laptopCamera.fieldOfView <= 100)
            {
                cameraManager.laptopCamera.fieldOfView += 2;
                Debug.LogWarning("Zoom in");
            }
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (cameraManager.laptopCamera.fieldOfView > 42)
            {
                cameraManager.laptopCamera.fieldOfView -= 2;
                Debug.LogWarning("Zoom out");
            }
            if (cameraManager.laptopCamera.fieldOfView > 40 && startPosterScript.clickCondition == false
            && middlePosterScript.clickCondition == false && sleepPosterScript.clickCondition == false && lamplightScript.lightCondition == true)
            {
                cameraManager.laptopCamera.fieldOfView -= 2;
                Debug.LogWarning("Zoom out");
            }
            //Switch scene
        }
    }
    void ZoomInFeedback()
    {

        if (cameraManager.laptopCamera.fieldOfView <= 40)
        {
            presentView = cameraManager.laptopCamera.fieldOfView;
            cameraManager.laptopCamera.fieldOfView = Mathf.Lerp(presentView, 10, 6.0f * Time.deltaTime);
            Debug.LogWarning("Pass");
        }
        if (cameraManager.laptopCamera.fieldOfView <= 10.5f)
        {

            SceneManager.LoadScene("Hao Yun");
            cursorScript.cursorCondition = false;
        }
    }
}
