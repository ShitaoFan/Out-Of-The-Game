using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binMenuHighlight : MonoBehaviour
{
     Renderer rend;
   
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver() 
    {
        
        rend.enabled = true;
    }

     void OnMouseExit() 
    {
         rend.enabled = false;
    }
     void OnMouseDown() 
    {
       Application.Quit(); 
       Debug.Log("Quit");
    }
}
