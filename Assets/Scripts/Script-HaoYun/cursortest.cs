using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursortest : MonoBehaviour
{
    public Texture2D cursora;
    public Texture2D cursorb;
    public Texture2D cursorc;
    public Texture2D cursord;
    public Texture2D cursore;
    public Texture2D cursorf;
    public CursorMode cursorMode = CursorMode.Auto;
    public bool cursorCondition = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cursorCondition == false)
        {
            CursorA();
        }
        else
        {
            CursorB();
        }
        /*else if (cursorCondition == 2)
        {
            CursorC();
        }
        /*else if (cursorCondition == 3)
        {
            CursorD();
        }
        else if (cursorCondition == 4)
        {
            CursorE();
        }
        else if (cursorCondition == 5)
        {
            CursorF();
        }*/

    }
    public void CursorB()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        Cursor.SetCursor(cursorb, Vector2.zero, cursorMode);
    }
    public void CursorA()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.SetCursor(cursora, Vector2.zero, cursorMode);
        Debug.Log("解开摄像头");
    }
    public void CursorC()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.SetCursor(cursorc, Vector2.zero, cursorMode);
        Debug.Log("解开摄像头");
    }
    public void CursorD()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.SetCursor(cursord, Vector2.zero, cursorMode);
        Debug.Log("解开摄像头");
    }
    public void CursorE()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.SetCursor(cursore, Vector2.zero, cursorMode);
        Debug.Log("解开摄像头");
    }
    public void CursorF()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Cursor.SetCursor(cursorf, Vector2.zero, cursorMode);
        Debug.Log("解开摄像头");

    }
}