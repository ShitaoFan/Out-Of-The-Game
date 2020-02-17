using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Coffee : MonoBehaviour
{
    CameraManager cameraManager;
    cursortest cursorTest;
    Chair gameChairScript;
    float presentView;
    bool clickCoffee = false;
    protected HighlightableObject ho;
    // Start is called before the first frame update
    void Start()
    {
          cameraManager = FindObjectOfType<CameraManager>();
          cursorTest = FindObjectOfType<cursortest>();
          gameChairScript = FindObjectOfType<Chair>();
          ho = gameObject.AddComponent<HighlightableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(clickCoffee == true)
        {
            zoomOutIn();
            ZoomInFeedback();
        }
        
    }
    void OnMouseDown() 
    {
        cameraManager.characterCamera.enabled = false;
        cameraManager.laptopCamera.enabled = false;
        cameraManager.coffeeCamera.enabled = true;
        //cursorTest.cursorCondition = false;
        clickCoffee = true;
        //cameraManager.ara
    }
    

    void zoomOutIn()
    {
        //Zoom out
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (cameraManager.coffeeCamera.fieldOfView <= 100)
            {
                cameraManager.coffeeCamera.fieldOfView += 2;
                Debug.LogWarning("Zoom in");
            }
        }
        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (cameraManager.coffeeCamera.fieldOfView > 40)
            {
                cameraManager.coffeeCamera.fieldOfView -= 2;
                Debug.LogWarning("Zoom out");
            }
        }
    }
    void ZoomInFeedback()
    {

        if (cameraManager.coffeeCamera.fieldOfView <= 40)
        {
            presentView = cameraManager.coffeeCamera.fieldOfView;
            cameraManager.coffeeCamera.fieldOfView = Mathf.Lerp(presentView, 10, 6.0f * Time.deltaTime);
            Debug.LogWarning("Pass");
        }
        if (cameraManager.coffeeCamera.fieldOfView <= 10.5f)
        {

            SceneManager.LoadScene("Hao Yun");
        }
    }
    void OnMouseEnter()
    {
        ho.ConstantOn();
    }
    void OnMouseExit()
    {
       ho.ConstantOff();
    }
}
