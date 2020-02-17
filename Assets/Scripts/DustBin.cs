using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBin : MonoBehaviour
{
    
    private Renderer _renderer;
    public GameObject menu;
    public GameObject background;
    public bool isMenuOpen = false;
    public Material basicMat, highlightMat;
    
    int tap;
    
void Start() 
{
       _renderer = GetComponent<Renderer>();
}


 
void OnMouseOver() 
{

        _renderer.material = highlightMat;
        Debug.Log("OnMouseEnter");

       if (Input.GetMouseButton(1))   
    {
        menu.SetActive(true);
        Debug.Log("R mouse click");
        isMenuOpen = true;
    }  
}

void Update() {
    {
        if (isMenuOpen)
        {
            background.GetComponent<BoxCollider>().enabled =true;
        }
    }
}


void OnMouseExit() 
{
        Debug.Log("OnMouseoff");
        _renderer.material = basicMat;

        
      
}
    //void OnMouseoff()
   // {
  //      if (Input.GetMouseButton(0))   
    
   //     menu.SetActive(false);
    //    Debug.Log("L mouse click");
    
   // }
    
     
 
 
    //  void OnPointerClick(PointerEventData eventData)
    // {
    //     if (eventData.clickCount == 2) {
    //         Debug.Log ("double click");
    //     }
    // }

    }




