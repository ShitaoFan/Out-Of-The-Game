using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfGame : MonoBehaviour
{
    CameraManager cameraManager;
    DoorController doorScript;
    WinKey winKeyScript;
    Vector3 mousePos;
    Vector3 offset;
    Vector3 mousePos1;
    public GameObject outOfGame;
    public GameObject menu;
    public float mouseSpeed = 0.226f;
    // Start is called before the first frame update
    void Start()
    {
        winKeyScript = FindObjectOfType<WinKey>();
        doorScript = FindObjectOfType<DoorController>();
        cameraManager = FindObjectOfType<CameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos1 = Input.mousePosition * mouseSpeed;
        if (Input.GetMouseButton(1))   
        {
        menu.SetActive(true);
        }  
    }
    void OnMouseDown()
    {
        mousePos = mousePos1;
        offset = transform.position - mousePos;
    }
    void OnMouseDrag()
    {
        outOfGame.transform.position = new Vector3(mousePos1.x + offset.x, mousePos1.y + offset.y, 0f);
    }
    void OnMouseUp()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bin")
        {
            outOfGame.SetActive(false);
            //Invoke("senceChange",1f);
            SceneManager.LoadScene("Shitao Fan");
            cameraManager.doorStatus = true;
        }
    }
    public void sceneChange()
    {
        SceneManager.LoadScene("Shitao Fan");
    }
    public void OpenDoor()
    {
        doorScript.doorAnimator.SetBool("OpenDoor", true);
        cameraManager.doorCamera.enabled = false;
        cameraManager.doorCamera.enabled = true;
    }
    public void WakeUp()
    {
        cameraManager.doorCamera.enabled = true;
        cameraManager.doorCamera.enabled = false;
    }

}
