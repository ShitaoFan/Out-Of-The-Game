using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampLight2 : MonoBehaviour
{
    Chair2 chairScript;
    TriggerManager triggerManager;
    CameraManager cameraManager;
    ScenesManager sceneManager;
    AudioManager audioManager;
    CursorManager cursorManager;
    LapTop2 laptopScript;
    AudioSource window10On;
    public GameObject lampLight;
    public bool lightCondition = false;
    // Start is called before the first frame update
    void Start()
    {
        laptopScript = FindObjectOfType<LapTop2>();
        triggerManager = FindObjectOfType<TriggerManager>();
        chairScript = FindObjectOfType<Chair2>();
        window10On = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (lightCondition == false )
        {
            lampLight.SetActive(true);
            laptopScript.laptopScreenRenderer.material = laptopScript.laptopMaterial_2;
            lightCondition = true;
            window10On.Play();
            Debug.Log("灯开");
        }
        else
        {
            lampLight.SetActive(false);
            laptopScript.laptopScreenRenderer.material = laptopScript.laptopMaterial_1;
            lightCondition = false;
            Debug.Log("灯灭");
        }
    }
}
