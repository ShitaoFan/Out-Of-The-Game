using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamplight : MonoBehaviour
{
    Chair chairScript;
    TriggerManager triggerManager;
    CameraManager cameraManager;
    ScenesManager sceneManager;
    AudioManager audioManager;
    CursorManager cursorManager;
    Laptop laptopScript;
    AudioSource window10On;
    public GameObject lampLight;
    public bool lightCondition = false;
    // Start is called before the first frame update
    void Start()
    {
        laptopScript = FindObjectOfType<Laptop>();
        triggerManager = FindObjectOfType<TriggerManager>();
        chairScript = FindObjectOfType<Chair>();
        window10On = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (lightCondition == false && chairScript.chairUsedCondition == true)
        {
            lampLight.SetActive(true);
            laptopScript.laptopScreenRenderer.material = laptopScript.laptopMaterial_2;
            lightCondition = true;
            window10On.Play();
            Debug.Log("灯开");
        }
        else if (lightCondition == true && chairScript.chairUsedCondition == true)
        {
            lampLight.SetActive(false);
            laptopScript.laptopScreenRenderer.material = laptopScript.laptopMaterial_1;
            lightCondition = false;
            Debug.Log("灯灭");
        }
    }
}
