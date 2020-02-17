using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLeaveMenu : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update

    
    void OnMouseDown() {
        Debug.Log("Pressed primary button.");
        menu.SetActive(false);   
    }
}
