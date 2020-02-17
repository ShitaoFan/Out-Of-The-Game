using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager3 : MonoBehaviour
{
    public GameObject camera;
    public Camera laptopCamera;
    public Camera arcadeCamera;
    public Camera televisionCamera;
    public Camera bookshelfCamera;
    public Camera characterCamera;
    public Camera wakeupCamera;
    public Camera doorCamera;
    public Camera coffeeCamera;
    public bool doorStatus = false;
    Scene currentScene;
    DoorController doorScript;
    cursortest cursorTest;
    void Start()
    {
        if (laptopCamera == null) // Is the variable 'laptopCamera' empty?
        {
            laptopCamera = GameObject.FindGameObjectWithTag("LaptopCamera").GetComponent<Camera>() as Camera;
        }
        if (arcadeCamera == null)
        {
            arcadeCamera = GameObject.FindGameObjectWithTag("ArcadeCamera").GetComponent<Camera>() as Camera;
        }
        if (televisionCamera == null)
        {
            televisionCamera = GameObject.FindGameObjectWithTag("TelevisionCamera").GetComponent<Camera>() as Camera;
        }
        if (bookshelfCamera == null)
        {
            bookshelfCamera = GameObject.FindGameObjectWithTag("BookshelfCamera").GetComponent<Camera>() as Camera;
        }
        if (characterCamera == null)
        {
            characterCamera = GameObject.FindGameObjectWithTag("CharacterCamera").GetComponent<Camera>() as Camera;
        }
        if (wakeupCamera == null)
        {
            wakeupCamera = GameObject.FindGameObjectWithTag("WakeUpCamera").GetComponent<Camera>() as Camera;
        }
        if (coffeeCamera == null)
        {
            coffeeCamera = GameObject.FindGameObjectWithTag("CoffeeCamera").GetComponent<Camera>() as Camera;
        }
        cursorTest = FindObjectOfType<cursortest>();
        Menu();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OpenDoor()
    {
        laptopCamera.enabled = false;

        arcadeCamera.enabled = false;

        televisionCamera.enabled = false;

        bookshelfCamera.enabled = false;

        characterCamera.enabled = false;

        wakeupCamera.enabled = false;

        doorCamera.enabled = true;

        doorScript.doorAnimator.SetBool("OpenDoor", true);
    }
    void WakeUp()
    {
        laptopCamera.enabled = false;

        arcadeCamera.enabled = false;

        televisionCamera.enabled = false;

        bookshelfCamera.enabled = false;

        characterCamera.enabled = false;

        wakeupCamera.enabled = true;

        doorCamera.enabled = false;

        doorStatus = false;

        cursorTest.cursorCondition = true;
    }
    void Menu()
    {
        laptopCamera.enabled = true;

        arcadeCamera.enabled = false;

        televisionCamera.enabled = false;

        bookshelfCamera.enabled = false;

        characterCamera.enabled = false;

        wakeupCamera.enabled = false;

        doorCamera.enabled = false;

        doorStatus = false;

        cursorTest.cursorCondition = false;
    }
}
