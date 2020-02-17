using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ArcadeController : MonoBehaviour
{
    GameChair gameChairScript;
    CameraManager cameraManager;
    float presentView;
    // Start is called before the first frame update
    void Start()
    {
        gameChairScript = FindObjectOfType<GameChair>();
        cameraManager = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameChairScript.arcadeUsedStatus == true)
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
            if (cameraManager.arcadeCamera.fieldOfView <= 100)
            {
                cameraManager.arcadeCamera.fieldOfView += 2;
                Debug.LogWarning("Zoom in");
            }
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (cameraManager.arcadeCamera.fieldOfView > 40)
            {
                cameraManager.arcadeCamera.fieldOfView -= 2;
                Debug.LogWarning("Zoom out");
            }
        }
    }
    void ZoomInFeedback()
    {

        if (cameraManager.arcadeCamera.fieldOfView <= 40)
        {
            presentView = cameraManager.arcadeCamera.fieldOfView;
            cameraManager.arcadeCamera.fieldOfView = Mathf.Lerp(presentView, 10, 6.0f * Time.deltaTime);
            Debug.LogWarning("Pass");
        }
        if (cameraManager.arcadeCamera.fieldOfView <= 10.5f)
        {

            SceneManager.LoadScene("Pong");
        }
    }
}
