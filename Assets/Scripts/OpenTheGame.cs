using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTheGame : MonoBehaviour
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
     SceneManager.LoadScene("Hao Yun");
     //SceneManager.LoadScene("New FanShitao");
    }
}
