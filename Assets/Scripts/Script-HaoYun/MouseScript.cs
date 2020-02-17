using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseScript : MonoBehaviour
{
   float horizontalSpeed = 10f;
    float verticalSpeed = 10f;
    

     GameObject hand;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");

        this.transform.localPosition += new Vector3(h, v, 0);

        if(Input.GetAxis("Mouse X")<0){
     //Code for action on mouse moving left
     print("Mouse moved left");
 }
 if(Input.GetAxis("Mouse X")>0){
     //Code for action on mouse moving right
     print("Mouse moved right");
 }
    
}
}