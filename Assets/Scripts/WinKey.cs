using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinKey : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 offset;
    Vector3 mousePos1;
    
    public float mouseSpeed = 0.226f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        mousePos1 = Input.mousePosition * mouseSpeed;
        
    }
    void OnMouseDown()
    {
        mousePos = mousePos1;
        offset = transform.position - mousePos;
    }
    void OnMouseDrag()
    {
        transform.position = new Vector3(mousePos1.x + offset.x, mousePos1.y + offset.y, 0f);
    }
    void OnMouseUp()
    {

    }
}
