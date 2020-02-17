using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToBed : MonoBehaviour
{
    // Start is called before the first frame update
   private void OnMouseDown() 
   {
       SceneManager.LoadScene("Hao Yun");
   }
}
